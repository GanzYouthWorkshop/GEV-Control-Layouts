using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLPieChart : Control
    {
        public List<Color> ChartColors { get; } = new List<Color>() { Color.CadetBlue, Color.DarkOrange, Color.LimeGreen };
        public List<double> Values { get; } = new List<double>() { 10, 20, 30 };

        public GCLPieChart() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(this.BackColor);


            double sum = Values.Sum();
            double percentTotal = -90 % 360;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for(int i = 0; i < this.Values.Count; i++)
            {
                Color pieColor = this.ChartColors[i % this.ChartColors.Count];
                double percent = this.Values[i] / sum;

                using (SolidBrush brush = new SolidBrush(pieColor))
                {
                    float start = (float)percentTotal;
                    float angle = (float)percent * 360;
                    e.Graphics.FillPie(brush, new Rectangle(new Point(0, 0), this.Size), start, angle);
                }

                percentTotal += percent * 360;
            }
        }


        public void  AddValue(int index, double value)
        {
            if(this.Values.Count > index)
            {
                double oldValue = this.Values[index];
                this.Values[index] = value;

                if(oldValue != value)
                {
                    this.Invalidate();
                }
            }
        }
    }
}
