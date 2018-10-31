using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLProgressBar : Panel
    {
        private int m_Value;
        public int Value
        {
            get { return this.m_Value; }
            set { this.m_Value = value; this.Invalidate(); }
        }

        public int Maximum { get; set; } = 100;

        public Color ActiveColor { get; set; } = GCLColors.AccentColor1;

        public GCLProgressBar() : base()
        {
            this.BackColor = GCLColors.Shadow;

            this.Value = 10;
            this.SetStyle(ControlStyles.UserPaint, true);

            this.BorderStyle = BorderStyle.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            using (Brush b = new SolidBrush(this.ActiveColor))
            {
                int width = 0;
                if (this.Value != 0)
                {
                    width = (int)(this.Width * ((float)this.Value / (float)this.Maximum));
                }
                
                e.Graphics.FillRectangle(b, new Rectangle(0, 0, width, this.Height));
            }
        }

    }
}
