using GEV.Layouts.Theming;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLPanel : Panel
    {
        public Color BorderColor { get; set; } = GCLColors.Border;

        public GCLPanel() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);

            this.BorderStyle = BorderStyle.None;
            this.BackColor = GCLColors.PanelBackground;

            this.Padding = new Padding(10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            using (Pen p = new Pen(this.BorderColor))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
    }
}
