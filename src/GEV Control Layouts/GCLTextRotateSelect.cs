using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEV.Layouts
{
	public class GCLTextRotateSelect : Control
	{
        public event EventHandler AngleChanged;

        public int SmallGrid { get; set; }


        public int Angle
        {
            get { return this.m_Angle; }
            set
            {
                if (this.m_Angle != value)
                {
                    this.m_Angle = value;

                    if (this.m_Angle < -90) this.m_Angle = -90;
                    if (this.m_Angle > 90) this.m_Angle = 90;

                    this.Invalidate();
                }
            }
        }
        private int m_Angle;

        public override string Text
        {
            get { return this.m_Text; }
            set
            {
                if (this.m_Text != value)
                {
                    this.m_Text = value;
                    Invalidate();
                }
            }
        }
        private string m_Text = "Text";


        public GCLTextRotateSelect()
		{
			this.DoubleBuffered = true;
			this.SmallGrid = 5;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			float cx = this.ClientRectangle.Left + 10;
			float cy = this.ClientRectangle.Height / 2;

			float len = cy - 10;
			g.TranslateTransform(cx, cy);

			var pb = SystemBrushes.WindowText;

			for (float a = 0; a <= 180f; a += 15f)
			{
				var d = a * Math.PI / 180f;

				int x = (int)Math.Round(Math.Sin(d) * len);
				int y = (int)Math.Round(Math.Cos(d) * len);

				if ((a % 45) == 0)
				{
                    g.FillEllipse(pb, new RectangleF(x - 2, y - 2, 4, 4));
				}
				else
				{
					g.FillEllipse(pb, new Rectangle(x-1, y-1, 2, 2));
				}
			}

			g.RotateTransform(-this.m_Angle);

			SizeF textSize = new SizeF(0, 0);

			using (var sf = new StringFormat(StringFormat.GenericTypographic))
			{
				sf.FormatFlags |= StringFormatFlags.NoWrap;

				textSize = g.MeasureString("Text", this.Font, 999999, sf);
				g.DrawString("Text", this.Font, SystemBrushes.WindowText, 0, -textSize.Height / 2, sf);
			}

			g.DrawLine(SystemPens.WindowText, textSize.Width + 5, 0, len - 7, 0);

			g.RotateTransform(this.m_Angle);

			g.TranslateTransform(-cx, -cy);
		}

		protected override void OnResize(EventArgs e)
		{
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			UpdateAngleByPoint(e.Location);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left
				|| e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				UpdateAngleByPoint(e.Location);
			}
		}

		private void UpdateAngleByPoint(Point p)
		{
			float cx = this.ClientRectangle.Left+10;
			float cy = this.ClientRectangle.Height / 2;

			var angle = (float)(Math.Atan2(p.Y - cy, p.X - cx) * 180f / Math.PI);

			if (this.SmallGrid > 0)
			{
				var halfSmallChange = this.SmallGrid / 2;
				var m = angle % this.SmallGrid;

				if (m > halfSmallChange) angle += this.SmallGrid - m;
				else if (m < halfSmallChange) angle -= m;
			}

			angle = (float)Math.Round(-angle);

			if (angle < -90) angle = -90;
			if (angle > 90) angle = 90;

			if (this.Angle != angle)
			{
				this.Angle = (int)angle;

				if (this.AngleChanged != null)
				{
					this.AngleChanged(this, null);
				}
			}
		}

	}
}
