using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLMiniDataLog : Control
    {
        private List<Tuple<DateTime, double>> m_Values = new List<Tuple<DateTime, double>>();
        public int ValueCount { get; set; } = 20;

        public int ValueTextSpace { get; set; } = 100;

        public double MaxValue { get; set; } = 100;
        public double MinValue { get; set; } = 0;

        public string DateFormat { get; set; } = "HH:mm:ss";
        public string ValueFormat { get; set; } = "0.00";

        public Color LineColor { get; set; } = GCLColors.AccentColor1Highlight;

        public GCLMiniDataLog() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }

        public void AddValue(double d)
        {
            if(this.m_Values.Count >= this.ValueCount)
            {
                this.m_Values.RemoveAt(0);
            }
            this.m_Values.Add(new Tuple<DateTime, double>(DateTime.Now, d));
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (Brush backgroundBrush = new SolidBrush(GCLColors.Shadow))
            using (Brush gridBrush = new SolidBrush(GCLColors.SecondaryText))
            using (Brush mainBrush = new SolidBrush(this.LineColor))
            using (Pen mainPen = new Pen(mainBrush, 3) { EndCap = LineCap.Round, StartCap = LineCap.Round })
            using(Pen gridPen = new Pen(gridBrush))
            {
                #region Általános méretek felvétele
                SizeF commonText = e.Graphics.MeasureString("1", this.Font);
                int width = e.ClipRectangle.Width - ValueTextSpace;
                int height = e.ClipRectangle.Height - (int)commonText.Height;

                float gridSize = width / 4;
                #endregion

                #region Háttér és rács rajzolása
                e.Graphics.FillRectangle(backgroundBrush, new Rectangle(0, 0, width, height));

                for (int i = 0; i < 4; i++)
                {
                    e.Graphics.DrawLine(gridPen, new PointF(i * gridSize, 0), new PointF(i * gridSize, height));
                }
                e.Graphics.DrawLine(gridPen, new PointF(width, 0), new PointF(width, height));
                e.Graphics.DrawLine(gridPen, new PointF(width, 0), new PointF(width, height));
                e.Graphics.DrawLine(gridPen, new PointF(0, height), new PointF(width, height));
                #endregion

                if (this.m_Values.Count > 0)
                {
                    #region első, utolsó, legkisebb és legnagyobb darabok
                    Tuple<DateTime, double> firstValue = this.m_Values.FirstOrDefault();
                    Tuple<DateTime, double> lastValue = this.m_Values.LastOrDefault();
                    double min = this.m_Values.Min(i => i.Item2);
                    double max = this.m_Values.Max(i => i.Item2);
                    #endregion

                    double horizontalStep = 1;
                    double verticalStep = (float)width / this.ValueCount;
                    if ((max - min) != 0)
                    {
                        horizontalStep = (float)height / ((this.MaxValue - this.MinValue) * 1.2);
                    }

                    PointF lastPoint = new PointF(0, 0);
                    double x = 0;
                    double y = 0;

                    #region a Görbe rajzolása
                    float dx = (float)verticalStep / 1.2f;

                    for (int i = 0; i < this.m_Values.Count; i++)
                    {
                        int startIndex = this.ValueCount - this.m_Values.Count;

                        x = ((startIndex + i + 1) * verticalStep);

                        if ((max - min) != 0)
                        {
                            y = height - ((Math.Min(this.m_Values[i].Item2, this.MaxValue) - this.MinValue) * horizontalStep);
                        }
                        else
                        {
                            y = height / 2;
                        }

                        PointF currentPoint = new PointF((float)x, (float)y);

                        if (i != 0)
                        {
                            //e.Graphics.DrawLine(mainPen, lastPoint, currentPoint);
                            e.Graphics.DrawBezier(mainPen, lastPoint, new PointF(lastPoint.X + dx, lastPoint.Y), new PointF(currentPoint.X - dx, currentPoint.Y), currentPoint);
                        }

                        lastPoint = currentPoint;
                    }
                    e.Graphics.FillEllipse(mainBrush, (float)x - 4, (float)y - 4, 8, 8);
                    #endregion

                    #region Szövegek rajzolása
                    if (this.m_Values.Count == this.ValueCount)
                    {
                        e.Graphics.DrawString(firstValue.Item1.ToString(this.DateFormat), this.Font, gridBrush, new PointF(0, height + 3), new StringFormat() { Alignment = StringAlignment.Near });
                    }
                    e.Graphics.DrawString(lastValue.Item2.ToString(this.ValueFormat), this.Font, gridBrush, new PointF(width + 7, (float)y), new StringFormat() { LineAlignment = StringAlignment.Center });
                    e.Graphics.DrawString(lastValue.Item1.ToString(this.DateFormat), this.Font, gridBrush, new PointF(width, height + 3), new StringFormat() { Alignment = StringAlignment.Far });
                    #endregion
                }
            }
        }
    }
}
