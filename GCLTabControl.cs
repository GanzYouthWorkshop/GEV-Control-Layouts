using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLTabControl : TabControl
    {
        public GCLTabControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.DoubleBuffered = true;
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(55, 150);
            this.Multiline = false;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            this.Alignment = TabAlignment.Left;
        }


        private const int TCM_ADJUSTRECT = 0x1328;

        protected override void WndProc(ref Message m)
        {
            // Hide the tab headers at run-time
            if (m.Msg == TCM_ADJUSTRECT)//&& !DesignMode)
            {
                RECT rect = (RECT)(m.GetLParam(typeof(RECT)));
                rect.Left = this.Left - this.Margin.Left + 150;
                rect.Right = this.Right + this.Margin.Right;

                rect.Top = this.Top - this.Margin.Top;
                rect.Bottom = this.Bottom + this.Margin.Bottom;
                Marshal.StructureToPtr(rect, m.LParam, true); return;
            }

            // call the base class implementation
            base.WndProc(ref m);
        }

        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Bitmap bkg = new Bitmap(this.Width, this.Height))
            using (Graphics g = Graphics.FromImage(bkg))
            using (Brush b = new SolidBrush(Color.FromArgb(234, 237, 241)))
            {
                g.Clear(Color.SlateGray);

                //g.FillRectangle(Brushes.LightGray, new Rectangle(0, 37, this.Width, 3));

                for (int i = 0; i < this.TabCount; i++)
                {
                    Rectangle r = this.GetTabRect(i);
                    r.X -= 2;
                    r.Y -= 2;

                    if (i == this.SelectedIndex)
                    {
                        g.FillRectangle(b, r);
                        g.DrawString(this.TabPages[i].Text.ToUpper(), this.Font, Brushes.Black, r, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        //g.FillRectangle(Brushes.Beige, r);
                        g.DrawString(this.TabPages[i].Text.ToUpper(), this.Font, Brushes.White, r, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                    }
                    //g.DrawString(this.TabPages[i].Text.ToUpper(), this.Font, Brushes.LightGray, r.X, r.Y + 4);
                }

                e.Graphics.DrawImage(bkg, new Point(0, 0));
            }
        }
    }
}
