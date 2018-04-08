using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLToolTip : ToolTip
    {
        public Color BorderColor { get; set; } = GCLColors.SoftBorder;
        public Font Font { get; set; } = SystemFonts.DefaultFont;

        public GCLToolTip(IContainer container) : base(container)
        {
            this.OwnerDraw = true;
            this.BackColor = GCLColors.Shadow;
            this.ForeColor = GCLColors.PrimaryText;

            this.Draw += GCLToolTip_Draw;
            this.Popup += GCLToolTip_Popup;
        }

        private void GCLToolTip_Popup(object sender, PopupEventArgs e)
        {
        }


        private void GCLToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            using (Brush b = new SolidBrush(this.BackColor))
            using (Brush text = new SolidBrush(ForeColor))
            {
                e.Graphics.Clear(this.BorderColor);
                Rectangle r = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
                e.Graphics.FillRectangle(b, e.Bounds);
                e.DrawText();

            }
        }
    }
}
