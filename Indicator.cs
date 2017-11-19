using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.ControlLayouts
{
    public class Indicator : Label
    {
        public enum IndicatorTypes
        {
            Round,
            Rectangle,
            Diamond
        }

        public IndicatorTypes Type { get; set; }

        public bool Active { get; set; }

        public Color ActiveColor { get; set; } = Color.FromArgb(0, 255, 0);
        public Color InactiveColor { get; set; } = Color.FromArgb(255, 0, 0);

        public Indicator()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.Text = "";
            this.AutoSize = false;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Color color = this.Active ? this.ActiveColor : this.InactiveColor;

            using (Graphics g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);

                using (Pen p = new Pen(color, 5))
                {
                    switch (this.Type)
                    {
                        case IndicatorTypes.Rectangle:
                            g.DrawRectangle(p, new Rectangle(0, 0, this.Width, this.Height));
                            break;
                        case IndicatorTypes.Round:
                            g.DrawEllipse(p, new Rectangle(0, 0, this.Width, this.Height));
                            break;
                        case IndicatorTypes.Diamond:
                            g.DrawLine(p, 0, this.Height / 2, this.Width / 2, 0);
                            g.DrawLine(p, this.Width / 2, 0, this.Width, this.Height / 2);
                            g.DrawLine(p, this.Width, this.Height / 2, this.Width / 2, this.Height);
                            g.DrawLine(p, this.Width / 2, this.Height, 0, this.Height / 2);
                            break;
                    }
                }
            }
        }
    }
}
