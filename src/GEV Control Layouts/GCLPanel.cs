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
    public class GCLPanel : Panel, IGCLControl
    {
        public Color BorderColor { get; set; } = GCLColors.Border;
        public bool UseThemeColors { get; set; } = true;

        public GCLPanel() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);

            this.BorderStyle = BorderStyle.None;
            this.BackColor = GCLColors.PanelBackground;

            this.Padding = new Padding(10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color backColor = this.UseThemeColors ? GCLColors.PanelBackground : this.BackColor;
            Color borderColor = this.UseThemeColors ? GCLColors.Border : this.BorderColor;

            e.Graphics.Clear(backColor);

            using (Pen p = new Pen(borderColor))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
    }
}
