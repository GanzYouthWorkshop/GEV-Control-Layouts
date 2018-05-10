using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLCheckBox : CheckBox, IGCLControl
    {
        public bool UseThemeColors { get; set; } = true;

        public Color BoxColor { get; set; } = GCLColors.SoftBorder;
        public Color CheckedColor { get; set; } = GCLColors.AccentColor2Highlight;

        public GCLCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;

            this.FlatStyle = FlatStyle.Flat;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color box = this.UseThemeColors ? GCLColors.Button : this.BoxColor;
            Color active = this.UseThemeColors ? GCLColors.AccentColor1 : this.CheckedColor;
            Color text = this.UseThemeColors ? GCLColors.PrimaryText : this.ForeColor;

            e.Graphics.Clear(this.BackColor);
            using (Brush borderBrush = new SolidBrush(box))
            using (Brush activeBrush = new SolidBrush(active))
            using (Brush textBrush = new SolidBrush(text))
            {
                RectangleF R = new RectangleF(e.Graphics.ClipBounds.X + this.Padding.Left, e.Graphics.ClipBounds.Y + this.Padding.Top + 3, 16F, 16F);
                e.Graphics.FillRectangle(borderBrush, R);
                if (this.Checked)
                {
                    e.Graphics.FillRectangle(activeBrush, new RectangleF(R.X + 3, R.Y + 3, 10, 10));
                }

                RectangleF rt = new RectangleF(e.Graphics.ClipBounds.X + 18, e.Graphics.ClipBounds.Y, e.Graphics.ClipBounds.Width - 18, e.Graphics.ClipBounds.Height);

                e.Graphics.DrawString(this.Text, this.Font, textBrush, rt, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
            }
        }
    }
}
