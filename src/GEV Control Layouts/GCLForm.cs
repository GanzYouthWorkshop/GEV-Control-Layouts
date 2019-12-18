using GEV.Layouts.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public partial class GCLForm : Form, IGCLControl
    {
        public bool UseThemeColors { get; set; } = true;
        public bool HideStartMenuOnMaximize { get; set; } = false;

        public Color BorderColor { get; set; } = GCLColors.Border;

        protected override CreateParams CreateParams
        {
            get
            {
                if (m_previousExStyle == -1)
                {
                    m_previousExStyle = base.CreateParams.ExStyle;
                }
                CreateParams cp = base.CreateParams;

                //if (m_EnableAntiFlicker)
                //{
                //    cp.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
                //}
                //else
                //{
                //    cp.ExStyle = m_previousExStyle;
                //}

                return cp;
            }
        }

        private int m_previousExStyle = -1;
        private bool m_EnableAntiFlicker;

        public GCLForm()
        {
            this.ToggleAntiFlicker(false);

            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }


        private void ToggleAntiFlicker(bool Enable)
        {
            m_EnableAntiFlicker = Enable;

            this.FormBorderStyle = FormBorderStyle.None;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Color back = this.UseThemeColors ? GCLColors.FormBackground : this.BackColor;
            Color border = this.UseThemeColors ? GCLColors.Border : this.BorderColor;

            e.Graphics.Clear(back);
            using (Pen p = new Pen(border))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        internal void SetMaximizeBounds(Rectangle r)
        {
            this.MaximizedBounds = r;
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            ToggleAntiFlicker(true);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            ToggleAntiFlicker(false);
        }
    }
}
