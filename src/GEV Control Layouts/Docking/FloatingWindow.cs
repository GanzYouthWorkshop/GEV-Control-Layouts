using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Docking
{
    [Browsable(false)]
    internal partial class FloatingWindow : Form, IFloatingWindow, IGCLControl
    {
        #region Win32 API
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        #endregion

        private DockState m_DockState;
        private bool m_StartFloating;
        private bool m_IsFloating;
        private GCLDockingContainer m_DockExtender;


        public DockState DockState
        {
            get { return this.m_DockState; }
        }
        public bool DockOnHostOnly { get; set; }
        public bool DockOnInside { get; set; }
        public GCLDockablePanel ContainedPanel { get; set; }
        public bool UseThemeColors { get; set; } = true;


        public event EventHandler Docking;

        public FloatingWindow(GCLDockingContainer provider)
        {
            this.m_DockExtender = provider;
            this.m_DockState.OriginalDockingParent = provider;
            InitializeComponent();
        }

        #region Override
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                DockWindow();
            }
            base.WndProc(ref m);
        }

        protected override void OnResizeEnd(EventArgs e)
        {

            if (this.m_DockExtender.Overlay.Visible == true && this.m_DockExtender.Overlay.DockHostControl != null) //ok found new docking position
            {
                this.m_DockState.OriginalDockingParent = this.m_DockExtender.Overlay.DockHostControl;
                this.m_DockState.OriginalBounds = this.m_DockState.Container.RectangleToClient(this.m_DockExtender.Overlay.Bounds);
                this.m_DockState.OriginalDockStyle = this.m_DockExtender.Overlay.Dock;
                this.m_DockExtender.Overlay.Hide();
                DockWindow(); // dock the container
            }
            this.m_DockExtender.Overlay.DockHostControl = null;
            this.m_DockExtender.Overlay.Hide();
            base.OnResizeEnd(e);
        }

        protected override void OnMove(EventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            Point pt = Cursor.Position;
            Point pc = PointToClient(pt);
            if (pc.Y < 0 || pc.Y > 21)
            {
                return;
            }
            if (pc.X < -1 || pc.X > Width)
            {
                return;
            }

            Control t = this.m_DockExtender.FindDockHost(this, pt);
            if (t == null || this.Controls.Contains(t))
            {
                this.m_DockExtender.Overlay.Hide();
            }
            else
            {
                this.SetOverlay(t, pt);
            }
            base.OnMove(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color back = this.UseThemeColors ? GCLColors.PanelBackground : this.ContainedPanel.BackColor;
            Color border = this.UseThemeColors ? GCLColors.Border : this.ContainedPanel.BackColor;

            e.Graphics.Clear(back);
            using (Pen p = new Pen(border))
            {
                e.Graphics.DrawRectangle(p, e.ClipRectangle);
            }
        }
        #endregion

        #region FloatingWindow funcionality
        public new void Show()
        {
            if (!this.Visible && this.m_IsFloating)
            {
                base.Show(/*this.m_DockState.OriginalDockHost*/);
            }

            this.m_DockState.Container.Show();
        }

        public new void Show(IWin32Window win)
        {
            Show();
        }

        public new void Hide()
        {
            if (this.Visible)
            {
                base.Hide();
            }

            this.m_DockState.Container.Hide();
        }
        #endregion

        #region Helpers

        /// <summary>
        /// determines the client area of the control. The area of docked controls are excluded
        /// </summary>
        /// <param name="c">the control to which to determine the client area</param>
        /// <returns>returns the docking area in screen coordinates</returns>
        private Rectangle GetDockingArea(Control c)
        {
            Rectangle r = c.Bounds;

            if (c.Parent != null)
            {
                r = c.Parent.RectangleToScreen(r);
            }

            Rectangle rc = c.ClientRectangle;

            int borderwidth = (r.Width - rc.Width) / 2;
            r.X += borderwidth;
            r.Y += (r.Height - rc.Height) - borderwidth;

            if (!this.DockOnInside)
            {
                rc.X += r.X;
                rc.Y += r.Y;
                return rc;
            }

            foreach (Control cs in c.Controls)
            {
                if (!cs.Visible) continue;
                switch (cs.Dock)
                {
                    case DockStyle.Left:
                        rc.X += cs.Width;
                        rc.Width -= cs.Width;
                        break;

                    case DockStyle.Right:
                        rc.Width -= cs.Width;
                        break;

                    case DockStyle.Top:
                        rc.Y += cs.Height;
                        rc.Height -= cs.Height;
                        break;

                    case DockStyle.Bottom:
                        rc.Height -= cs.Height;
                        break;

                    default:
                        break;
                }
            }
            rc.X += r.X;
            rc.Y += r.Y;

            return rc;
        }

        /// <summary>
        /// This method will check if the overlay needs to be displayed or not
        /// for display it will position the overlay
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p">position of cursor in screen coordinates</param>
        private void SetOverlay(Control c, Point pc)
        {

            Rectangle r = GetDockingArea(c);
            Rectangle rc = r;

            float rx = (pc.X - r.Left) / (float)(r.Width);
            float ry = (pc.Y - r.Top) / (float)(r.Height);

            this.m_DockExtender.Overlay.Dock = DockStyle.None; // keep floating

            // this section determines when the overlay is to be displayed.
            // it depends on the position of the mouse cursor on the client area.
            // the overlay is currently only shown if the mouse is moving over either the Northern, Western, 
            // Southern or Eastern parts of the client area.
            // when the mouse is in the center or in the NE, NW, SE or SW, no overlay preview is displayed, hence
            // allowing the user to dock the container.

            // dock to left, checks the Western area
            if (rx > 0 && rx < ry && rx < 0.25 && ry < 0.75 && ry > 0.25)
            {
                r.Width = r.Width / 2;
                if (r.Width > this.Width)
                    r.Width = this.Width;

                this.m_DockExtender.Overlay.Dock = DockStyle.Left; // dock to left
            }

            // dock to the right, checks the Easter area
            if (rx < 1 && rx > ry && rx > 0.75 && ry < 0.75 && ry > 0.25)
            {
                r.Width = r.Width / 2;
                if (r.Width > this.Width)
                    r.Width = this.Width;
                r.X = rc.X + rc.Width - r.Width;
                this.m_DockExtender.Overlay.Dock = DockStyle.Right;
            }

            // dock to top, checks the Northern area
            if (ry > 0 && ry < rx && ry < 0.25 && rx < 0.75 && rx > 0.25)
            {
                r.Height = r.Height / 2;
                if (r.Height > this.Height)
                    r.Height = this.Height;
                this.m_DockExtender.Overlay.Dock = DockStyle.Top;
            }

            // dock to the bottom, checks the Southern area
            if (ry < 1 && ry > rx && ry > 0.75 && rx < 0.75 && rx > 0.25)
            {
                r.Height = r.Height / 2;
                if (r.Height > this.Height)
                    r.Height = this.Height;
                r.Y = rc.Y + rc.Height - r.Height;
                this.m_DockExtender.Overlay.Dock = DockStyle.Bottom;
            }

            if (this.m_DockExtender.Overlay.Dock != DockStyle.None)
            {
                this.m_DockExtender.Overlay.Bounds = r;
            }
            else
            {
                this.m_DockExtender.Overlay.Hide();
            }

            if (!this.m_DockExtender.Overlay.Visible && this.m_DockExtender.Overlay.Dock != DockStyle.None)
            {
                this.m_DockExtender.Overlay.DockHostControl = c;
                this.m_DockExtender.Overlay.Show(this.m_DockState.OriginalDockHost);
                BringToFront();
            }
        }

        internal void Attach(DockState dockState)
        {
            // track the handle's mouse movements
            this.m_DockState = dockState;
            Text = this.m_DockState.Handle.Text;
            this.m_DockState.Handle.MouseMove += new MouseEventHandler(Handle_MouseMove);
            this.m_DockState.Handle.MouseHover += new EventHandler(Handle_MouseHover);
            this.m_DockState.Handle.MouseLeave += new EventHandler(Handle_MouseLeave);
        }

        /// <summary>
        /// makes the docked control floatable in this Floaty form
        /// </summary>
        /// <param name="dockState"></param>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        private void MakeFloatable(DockState dockState, int offsetx, int offsety)
        {
            Point ps = Cursor.Position;
            this.m_DockState = dockState;
            Text = this.m_DockState.Handle.Text;

            Size sz = this.m_DockState.Container.Size;
            if (this.m_DockState.Container.Equals(this.m_DockState.Handle))
            {
                sz.Width += 18;
                sz.Height += 28;
            }
            if (sz.Width > 600) sz.Width = 600;
            if (sz.Height > 600) sz.Height = 600;



            this.m_DockState.OriginalDockingParent = this.m_DockState.Container.Parent;
            this.m_DockState.OriginalBounds = this.m_DockState.Container.Bounds;
            this.m_DockState.OriginalDockStyle = this.m_DockState.Container.Dock;
            this.m_DockState.Container.Parent = this;
            this.m_DockState.Container.Dock = DockStyle.Fill;

            this.ContainedPanel = this.m_DockState.Container as GCLDockablePanel;
            this.Text = this.ContainedPanel.Title;

            (this.m_DockState.Handle as DockablePanelHeader).OwnerIsFloating = true;

            //_dockState.Handle.Visible = false; // hide it for now
            if (this.m_DockState.Splitter != null)
            {
                this.m_DockState.Splitter.Visible = false; // hide splitter
                this.m_DockState.Splitter.Parent = this;
            }
            // allow redraw of floaty and container
            //Application.DoEvents();  

            // this is kind of tricky
            // disable the mousemove events of the handle
            SendMessage(this.m_DockState.Handle.Handle.ToInt32(), WM_LBUTTONUP, 0, 0);
            ps.X -= offsetx;
            ps.Y -= offsety;


            this.Bounds = new Rectangle(ps, sz);
            this.m_IsFloating = true;
            Show();
            // enable the mousemove events of the new floating form, start dragging the form immediately
            SendMessage(this.Handle.ToInt32(), WM_SYSCOMMAND, SC_MOVE | 0x02, 0);
        }

        /// <summary>
        /// this will dock the floaty control
        /// </summary>
        private void DockWindow()
        {
            // bring dockhost to front first to prevent flickering
            this.m_DockState.OriginalDockHost?.TopLevelControl.BringToFront();
            this.Hide();
            this.m_DockState.Container.Visible = false; // hide it temporarely
            this.m_DockState.Container.Parent = this.m_DockState.OriginalDockingParent;
            this.m_DockState.Container.Dock = this.m_DockState.OriginalDockStyle;
            this.m_DockState.Container.Bounds = this.m_DockState.OriginalBounds;
            this.m_DockState.Container.Visible = true; // it's good, show it
            (this.m_DockState.Handle as DockablePanelHeader).OwnerIsFloating = false;

            if (this.DockOnInside)
                this.m_DockState.Container.BringToFront(); // set to front

            //show splitter
            if (this.m_DockState.Splitter != null && this.m_DockState.OriginalDockStyle != DockStyle.Fill && this.m_DockState.OriginalDockStyle != DockStyle.None)
            {
                this.m_DockState.Splitter.Parent = this.m_DockState.OriginalDockingParent;
                this.m_DockState.Splitter.Dock = this.m_DockState.OriginalDockStyle;
                this.m_DockState.Splitter.Visible = true; // show splitter

                if (this.DockOnInside)
                {
                    this.m_DockState.Splitter.BringToFront();
                }
                else
                {
                    this.m_DockState.Splitter.SendToBack();
                }
            }

            if (!this.DockOnInside)
            {
                this.m_DockState.Container.SendToBack(); // set to back
            }

            this.m_IsFloating = false;

            if (Docking != null)
            {
                Docking.Invoke(this, new EventArgs());
            }
        }

        private void DetachHandle()
        {
            this.m_DockState.Handle.MouseMove -= new MouseEventHandler(Handle_MouseMove);
            this.m_DockState.Handle.MouseHover -= new EventHandler(Handle_MouseHover);
            this.m_DockState.Handle.MouseLeave -= new EventHandler(Handle_MouseLeave);
            this.m_DockState.Container = null;
            this.m_DockState.Handle = null;
        }

        #endregion

        #region Event handlers
        private void Handle_MouseHover(object sender, EventArgs e)
        {
            this.m_StartFloating = true;
        }

        private void Handle_MouseLeave(object sender, EventArgs e)
        {
            this.m_StartFloating = false;
        }

        private void Handle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.m_StartFloating)
            {
                Point ps = this.m_DockState.Handle.PointToScreen(new Point(e.X, e.Y));
                MakeFloatable(this.m_DockState, e.X, e.Y);
            }
        }
        #endregion

        public void PerformOnMove()
        {
            this.OnMove(new EventArgs());
        }
    }
}
