using GEV.Layouts.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool UseFormTheming { get; set; } = true;

        public Color MenuColor { get; set; } = GCLColors.PanelBackground;
        public Color ActiveColor { get; set; } = GCLColors.AccentColor1;
        public Color SelectedTextColor { get; set; } = GCLColors.PrimaryText;
        public Color TextColor { get; set; } = GCLColors.SecondaryText;

        private Size m_TempItemSize;

        public new Size ItemSize
        {
            get
            {
                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                    case TabAlignment.Bottom:
                        return base.ItemSize;
                    case TabAlignment.Left:
                    case TabAlignment.Right:
                        return new Size(base.ItemSize.Height, base.ItemSize.Width);
                }
                return new Size(1,1);
            }

            set
            {
                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                    case TabAlignment.Bottom:
                        base.ItemSize = value;
                        break;
                    case TabAlignment.Left:
                    case TabAlignment.Right:
                        base.ItemSize = new Size(value.Height, value.Width);
                        break;
                }

            }
        }

        public bool TabHandlerVisible
        {
            get { return this.m_TabHandlerVisible; }
            set
            {
                this.m_TabHandlerVisible = value;
                if(!this.m_TabHandlerVisible && !this.DesignMode)
                {
                    this.m_TempItemSize = this.ItemSize;
                    this.ItemSize = new Size(0, 1);
                }
                else
                {
                    //this.ItemSize = this.m_TempItemSize;
                }
            }
        }
        private bool m_TabHandlerVisible = true;

        public GCLTabControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);

            this.DoubleBuffered = true;
            this.Appearance = TabAppearance.FlatButtons;
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(150, 55);
            this.m_TempItemSize = this.ItemSize;
            this.Multiline = false;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
        }


        private const int TCM_ADJUSTRECT = 0x1328;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == TCM_ADJUSTRECT)
            {
                RECT rect = (RECT)(m.GetLParam(typeof(RECT)));

                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                        rect.Left = this.Left;
                        rect.Right = this.Right;

                        rect.Top = this.Top + this.ItemSize.Height;
                        rect.Bottom = this.Bottom;
                        break;

                    default:
                        rect.Left = this.Left + this.ItemSize.Width;
                        rect.Right = this.Right + this.Margin.Right;

                        rect.Top = this.Top - this.Margin.Top;
                        rect.Bottom = this.Bottom + this.Margin.Bottom;
                        break;
                }
                Marshal.StructureToPtr(rect, m.LParam, true);
                return;
            }

            base.WndProc(ref m);
        }

        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Brush selected = new SolidBrush(this.ActiveColor))
            using (Brush selectedText = new SolidBrush(this.SelectedTextColor))
            using (Brush text = new SolidBrush(this.TextColor))
            {
                e.Graphics.Clear(this.MenuColor);

                for (int i = 0; i < this.TabCount; i++)
                {
                    Rectangle r = this.GetTabRect(i);
                    r.X -= 2;
                    r.Y -= 2;

                    Rectangle sel = r;
                    switch (this.Alignment)
                    {
                        case TabAlignment.Top:
                            sel.Y = sel.Height - 5;
                            break;
                        default:
                            r.Y = i * this.ItemSize.Height;
                            r.Width = this.ItemSize.Width;
                            r.Height = this.ItemSize.Height;
                            sel.X = sel.Width - 10;
                            break;
                    }

                    if (i == this.SelectedIndex)
                    {
                        e.Graphics.FillRectangle(selected, sel);
                        e.Graphics.DrawString(this.TabPages[i].Text.ToUpper(), this.Font, selectedText, r, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        e.Graphics.DrawString(this.TabPages[i].Text.ToUpper(), this.Font, text, r, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                }
            }
        }
    }
}
