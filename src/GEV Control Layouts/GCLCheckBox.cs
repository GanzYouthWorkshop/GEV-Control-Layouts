using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLCheckBox : CheckBox
    {
        public GCLCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;

            this.FlatStyle = FlatStyle.Flat;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush border = new SolidBrush(GCLColors.SoftBorder))
            using (Brush active = new SolidBrush(GCLColors.AccentColor2Highlight))
            using (Brush text = new SolidBrush(this.ForeColor))
            using (Pen textPen = new Pen(border))
            {
                RectangleF R = new RectangleF(e.Graphics.ClipBounds.X + this.Padding.Left, e.Graphics.ClipBounds.Y + this.Padding.Top + 3, 16F, 16F);
                e.Graphics.FillRectangle(border, R);
                if (this.Checked)
                {
                    e.Graphics.FillRectangle(active, new RectangleF(R.X + 3, R.Y + 3, 10, 10));
                }

                //e.Graphics.DrawRectangle(textPen, R.X, R.Y, R.Width - 1, R.Height - 1);
            }
        }
    }
}
