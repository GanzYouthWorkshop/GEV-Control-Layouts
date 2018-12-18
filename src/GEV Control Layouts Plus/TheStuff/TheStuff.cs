using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using WMPLib;
using System.IO;
using System.Reflection;
using GEV.Layouts.Extended.Properties;

namespace GEV.Layouts.Extended.TheStuff
{
    public partial class TheStuff : UserControl
    {
        public event EventHandler Lost;

        private Random m_RandomGenerator = new Random();
        private List<Panel> m_HittablePanels = new List<Panel>();
        private int m_Lives = 50;
        private WindowsMediaPlayer m_Music = new WindowsMediaPlayer();

        private List<Color> m_Colors = new List<Color>()
        {
            Color.Purple,
            Color.Yellow,
            Color.Red,
            Color.LightGreen,
            Color.White,
            Color.Cyan,
        };

        public TheStuff()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Panel> newList = new List<Panel>();

            foreach (Panel p in this.m_HittablePanels)
            {
                if (p.Location.Y < 12)
                {
                    if(p.Parent != null)
                    {
                        p.Parent.Controls.Remove(p);
                    }
                    this.ResetOpacity();
                    this.lblMessages.Text = "MEH...";
                    this.m_Lives--;
                    this.lblLives.Text = this.m_Lives.ToString();

                    if(this.m_Lives == 0)
                    {
                        this.m_Music.controls.stop();
                        this.timer1.Enabled = false;
                        this.Lost?.Invoke(this, new EventArgs());
                    }
                }
                else if((p.Tag != null && p.Tag.Equals(true)))
                {
                    if (p.Parent != null)
                    {
                        p.Parent.Controls.Remove(p);
                    }
                }
                else
                {
                    newList.Add(p);
                }

                p.Location = new Point(p.Location.X, p.Location.Y - 10);
            }

            this.m_HittablePanels = newList;


            bool newPanel = this.m_RandomGenerator.Next(1, 100) > 94;
            if (newPanel)
            {
                int spot = this.m_RandomGenerator.Next(1, 4);
                Panel parent = null;

                switch (spot)
                {
                    case 1: parent = this.panel1; break;
                    case 2: parent = this.panel2; break;
                    case 3: parent = this.panel3; break;
                    case 4: parent = this.panel4; break;
                }

                Panel p = new Panel()
                {
                    Width = this.gclButton1.Width,
                    Height = 20,
                    Location = new Point(3, 700),
                    BackColor = this.m_Colors[this.m_RandomGenerator.Next(0, this.m_Colors.Count - 1)],
                };

                parent.Controls.Add(p);
                this.m_HittablePanels.Add(p);
            }
            this.ReduceOpacity(10);
        }

        private void ButtonPressed(object sender, EventArgs e)
        {
            GCLButton button = (GCLButton)sender;
            foreach (Panel p in this.m_HittablePanels)
            {
                if (p.Parent == button.Parent && p.Location.Y > 32 && p.Location.Y < 79)
                {
                    p.Tag = true;
                    this.ResetOpacity();
                    this.lblMessages.Text = "OK!";
                }
            }
        }

        #region Színekkel baszakodás
        public void ResetOpacity()
        {
            Color c = this.lblMessages.ForeColor;
            this.lblMessages.ForeColor = Color.FromArgb(210, 210, 210);
        }

        public void ReduceOpacity(int amount)
        {
            Color c = this.lblMessages.ForeColor;
            int newValue = c.R - amount < 34 ? 34 : c.R - amount;
            this.lblMessages.ForeColor = Color.FromArgb(0, newValue, newValue, newValue);
        }


        private Color GradientColors(Color c1, Color c2, float ratio)
        {
            Color result = Color.Transparent;

            if(ratio == 0)
            {
                return c1;
            }
            else if(ratio == 1)
            {
                return c2;
            }


            //Invert sRGB gamma compression
            c1 = InverseSrgbCompanding(c1);
            c2 = InverseSrgbCompanding(c2);

            int R = (int)(c1.R * (1 - ratio) + c2.R * (ratio));
            int G = (int)(c1.G * (1 - ratio) + c2.G * (ratio));
            int B = (int)(c1.B * (1 - ratio) + c2.B * (ratio));

            //Reapply sRGB gamma compression

            return SrgbCompanding(Color.FromArgb(R, G, B));
        }

        Color InverseSrgbCompanding(Color c)
        {
            //Convert color from 0..255 to 0..1
            double r = c.R / 255;
            double g = c.G / 255;
            double b = c.B / 255;

            //Inverse Red, Green, and Blue
            if (r > 0.04045) r = Math.Pow((r + 0.055) / 1.055, 2.4); else r = r / 12.92;
            if (g > 0.04045) g = Math.Pow((g + 0.055) / 1.055, 2.4); else g = g / 12.92;
            if (b > 0.04045) b = Math.Pow((b + 0.055) / 1.055, 2.4); else b = b / 12.92;

            //return new color. Convert 0..1 back into 0..255
            r *= 255;
            g *= 255;
            b *= 255;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        Color SrgbCompanding(Color c)
        {
            //Convert color from 0..255 to 0..1
            double r = c.R / 255;
            double g = c.G / 255;
            double b = c.B / 255;

            //Apply companding to Red, Green, and Blue
            if (r > 0.0031308) r = 1.055 * Math.Pow(r, 1 / 2.4) - 0.055; else r = r * 12.92;
            if (g > 0.0031308) g = 1.055 * Math.Pow(g, 1 / 2.4) - 0.055; else g = g * 12.92;
            if (b > 0.0031308) b = 1.055 * Math.Pow(b, 1 / 2.4) - 0.055; else b = b * 12.92;

            //return new color. Convert 0..1 back into 0..255
            r *= 255;
            g *= 255;
            b *= 255;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }
        #endregion
    }
}
