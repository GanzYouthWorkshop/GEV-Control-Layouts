using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GEV.Layouts
{
    public partial class GCLColorPicker : UserControl
    {
        public Color Color
        {
            get
            {
                return this.m_Color;
            }
            set
            {
                this.m_Color = value;

                this.nudRed.Value = value.R;
                this.nudGreen.Value = value.G;
                this.nudBlue.Value = value.B;

            }
        }
        private Color m_Color;

        public GCLColorPicker()
        {
            InitializeComponent();
        }

        private void GCLColorPicker_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                using (Bitmap b = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height))
                {
                    int X = Math.Max(0, Math.Min(pictureBox1.ClientSize.Width - 1, e.X ));
                    int Y = Math.Max(0, Math.Min(pictureBox1.ClientSize.Height - 1, e.Y ));

                    pictureBox1.DrawToBitmap(b, pictureBox1.ClientRectangle);
                    Color c = b.GetPixel(X, Y);


                    this.nudRed.Value = c.R;
                    this.nudGreen.Value = c.G;
                    this.nudBlue.Value = c.B;
                }
            }
        }

        private void OnColorInputChange(object sender, EventArgs e)
        {
            this.m_Color = Color.FromArgb((int)this.nudRed.Value, (int)this.nudGreen.Value, (int)this.nudBlue.Value);
            this.gclPanel1.BackColor = this.Color;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
