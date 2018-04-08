using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLGauge : Control
    {
        public bool ShowNeedle { get; set; } = true;
        public Color NeedleColor { get; set; } = GCLColors.PrimaryText;
        public Color GridColor { get; set; } = GCLColors.SecondaryText;

        public double MinValue { get; set; } = 0;
        public double MaxValue { get; set; } = 100;
        public double Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                this.m_Value = value;
                this.Invalidate();
            }
        }
        private double m_Value = 50;
        public int StartAngle { get; set; } = 30;
        public int EndAngle { get; set; } = 330;
        public double MajorGridSpacing { get; set; } = 10;
        public double MinorGridSpacing { get; set; } = 2;
        public bool ShowMajorGrid { get; set; } = true;
        public bool ShowMinorGrid { get; set; } = true;
        public bool ShowLabels { get; set; } = true;
        public bool ShowBorder { get; set; } = true;
        public Color BorderColor { get; set; } = Color.Blue;
        public int BorderWidth { get; set; } = 5;
        public bool ShowSpin { get; set; } = false;

        public List<GaugeColorRegion> RegionColors { get; } = new List<GaugeColorRegion>();

        public GCLGauge()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int cx = (int)(this.Size.Width / 2);
            int cy = (int)(this.Size.Height / 2);

            Point center = new Point(cx, cy);

            int gridRadius = (int)(Math.Min(this.Size.Width, this.Size.Height) * 0.9 / 2);
            int spinRadius = gridRadius - 10;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            e.Graphics.Clear(this.BackColor);

            this.DrawColorRegions(e.Graphics, center, gridRadius);
            this.DrawGrid(e.Graphics, center, gridRadius - 2);
            this.DrawSpin(e.Graphics, center, spinRadius);
            this.DrawNeedle(e.Graphics, center, spinRadius);
        }

        private void DrawGrid(Graphics g, Point center, int radius)
        {
            Rectangle boundingBox = CreateFromCenter(center, radius);
            g.DrawArc(Pens.DarkGray, boundingBox, 90 + this.StartAngle, this.EndAngle - this.StartAngle);

            int length = (this.EndAngle % 360 - (this.StartAngle % 360)) + 90;
            int step = (int)(length / (this.MaxValue - this.MinValue));

            using (Pen gridPen = new Pen(this.GridColor))
            {
                if (this.ShowMinorGrid)
                {

                    for (int i = this.StartAngle; i < this.EndAngle; i += (int)(Math.Max(1, MinorGridSpacing) * step))
                    {
                        float angle = i + 90;
                        float rad = (float)DegToRad(angle);

                        int p1X = (int)(center.X + radius * Math.Cos(rad));
                        int p1Y = (int)(center.Y + radius * Math.Sin(rad));
                        int p2X = (int)(center.X + (radius + 5) * Math.Cos(rad));
                        int p2Y = (int)(center.Y + (radius + 5) * Math.Sin(rad));

                        g.DrawLine(gridPen, new Point(p1X, p1Y), new Point(p2X, p2Y));
                    }
                }

                if (this.ShowMajorGrid)
                {
                    for (int i = this.StartAngle; i < this.EndAngle; i += (int)(Math.Max(1, MajorGridSpacing) * step))
                    {
                        float angle = i + 90;
                        float rad = (float)DegToRad(angle);

                        int p1X = (int)(center.X + radius * Math.Cos(rad));
                        int p1Y = (int)(center.Y + radius * Math.Sin(rad));
                        int p2X = (int)(center.X + (radius + 15) * Math.Cos(rad));
                        int p2Y = (int)(center.Y + (radius + 15) * Math.Sin(rad));

                        if (i == this.StartAngle)
                        {
                            g.DrawLine(Pens.Red, new Point(p1X, p1Y), new Point(p2X, p2Y));

                        }
                        else
                        {
                            g.DrawLine(gridPen, new Point(p1X, p1Y), new Point(p2X, p2Y));

                        }
                    }
                    float trad = (float)DegToRad(this.EndAngle + 90);

                    int tp1X = (int)(center.X + radius * Math.Cos(trad));
                    int tp1Y = (int)(center.Y + radius * Math.Sin(trad));
                    int tp2X = (int)(center.X + (radius + 15) * Math.Cos(trad));
                    int tp2Y = (int)(center.Y + (radius + 15) * Math.Sin(trad));

                    g.DrawLine(gridPen, new Point(tp1X, tp1Y), new Point(tp2X, tp2Y));
                }
            }
        }

        private void DrawColorRegions(Graphics g, Point center, int radius)
        {
            Rectangle boundingBox = CreateFromCenter(center, radius);

            foreach (GaugeColorRegion item in this.RegionColors)
            {
                using (Pen p = new Pen(item.Col, 5))
                {
                    float start = (float)((this.EndAngle - this.StartAngle) * (item.Start / this.MaxValue));
                    float length = (float)((this.EndAngle - this.StartAngle) * ((item.Stop - item.Start) / this.MaxValue));
                    g.DrawArc(p, boundingBox, 90 + this.StartAngle + start, length);
                }
            }
        }

        private void DrawSpin(Graphics g, Point center, int radius)
        {
            if (this.ShowSpin)
            {
                Rectangle boundingBox = CreateFromCenter(center, radius);

                using (Pen p = new Pen(Color.Gray, 5) { EndCap = System.Drawing.Drawing2D.LineCap.Round, StartCap = System.Drawing.Drawing2D.LineCap.Round })
                {
                    float length = (float)((this.EndAngle - this.StartAngle) * (this.Value / this.MaxValue));
                    g.DrawArc(p, boundingBox, 90 + this.StartAngle, length);
                }
            }
        }

        private void DrawNeedle(Graphics g, Point center, int radius)
        {
            if(this.ShowNeedle)
            {
                float angle = this.StartAngle + (float)((this.EndAngle - this.StartAngle) * (this.Value / this.MaxValue)) + 90;

                float rad = (float)DegToRad(angle);

                int p2X = (int)(center.X + radius * Math.Cos(rad));
                int p2Y = (int)(center.Y + radius * Math.Sin(rad));
                Point p2 = new Point(p2X, p2Y);

                using (Brush b = new SolidBrush(this.NeedleColor))
                using (Pen p = new Pen(this.NeedleColor, 3) { EndCap = System.Drawing.Drawing2D.LineCap.Round })
                {
                    g.FillEllipse(b, CreateFromCenter(center, 10));
                    g.DrawLine(p, center, p2);
                }
            }
        }


        private Rectangle CreateFromCenter(Point center, int radius)
        {
            return new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        private double DegToRad(double degree)
        {
            return (degree * Math.PI) / 180;
        }

    }
}
