using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLIconAnimator : Label
    {
        public enum AnimationType
        {
            Spin,
            Flash,
            Frames
        }

        protected static Timer s_Ticker = new Timer();
        protected static ulong s_Ticks;

        static GCLIconAnimator()
        {
            s_Ticker.Interval = 50;
            s_Ticker.Enabled = true;
            s_Ticker.Tick += M_Ticker_Tick1;
        }

        private static void M_Ticker_Tick1(object sender, EventArgs e)
        {
            s_Ticks++;
        }

        public uint AnimationSpeed { get; set; } = 2;
        public float FrameRotation { get; set; } = 10;
        public bool AnimationEnabled { get; set; } = true;
        public AnimationType Type { get; set; } = AnimationType.Spin;

        public Point CenterCorrection { get; set; } = new Point(0, 0);

        private float m_CurrentRoation = 0;
        private int m_Frame = 0;

        public GCLIconAnimator() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            s_Ticker.Tick += M_Ticker_Tick;

            this.Padding = new Padding(10);
        }

        private void M_Ticker_Tick(object sender, EventArgs e)
        {
            if(s_Ticks % this.AnimationSpeed == 0)
            {
                this.m_CurrentRoation = (this.m_CurrentRoation + this.FrameRotation) % 360;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            using (Brush b = new SolidBrush(this.ForeColor))
            {
                if(this.AnimationEnabled)
                {
                    switch(this.Type)
                    {
                        case AnimationType.Spin:
                            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                            e.Graphics.TranslateTransform((this.Width / 2), (this.Height / 2));
                            e.Graphics.RotateTransform(this.m_CurrentRoation);
                            e.Graphics.DrawString(this.Text, this.Font, b, new PointF(this.CenterCorrection.X, this.CenterCorrection.Y), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                            break;
                        case AnimationType.Flash:
                            if(this.m_Frame == 0)
                            {
                                this.m_Frame = 1;
                            }
                            else
                            {
                                this.m_Frame = 0;
                                e.Graphics.DrawString(this.Text, this.Font, b, e.ClipRectangle, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                            }
                            break;
                        case AnimationType.Frames:
                            if(this.m_Frame == this.Text.Length - 1)
                            {
                                this.m_Frame = 0;
                            }
                            else
                            {
                                this.m_Frame++;
                            }
                            e.Graphics.DrawString(this.Text[this.m_Frame].ToString(), this.Font, b, e.ClipRectangle, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                            break;
                    }
                    //e.Graphics.DrawLine(Pens.Red, new Point(0, 0), new Point(1, 1));
                }
                else
                {
                    e.Graphics.DrawString(this.Text, this.Font, b, e.ClipRectangle,  new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                }
            }
        }

    }
}
