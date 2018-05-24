using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Utils
{
    internal class GCLUtils
    {
        public static void DrawButtonlike(IGCLButtonlike button, PaintEventArgs e)
        {
            Color border = button.UseThemeColors ? GCLColors.SoftBorder : button.FlatAppearance.BorderColor;
            Color back = button.UseThemeColors ? GCLColors.Button : button.BackColor;
            Color fore;

            if(button.Visible)
            {
                if(button.Enabled)
                {
                    fore = button.UseThemeColors ? GCLColors.PrimaryText : button.ForeColor;

                    if (button.IsPressed)
                    {
                        back = button.UseThemeColors ? GCLColors.AccentColor1Highlight : button.FlatAppearance.MouseDownBackColor;
                    }
                    else if(button.IsHovered)
                    {
                        back = button.UseThemeColors ? GCLColors.AccentColor1 : button.FlatAppearance.MouseOverBackColor;
                    }
                    else if(button.Checked)
                    {
                        back = button.UseThemeColors ? GCLColors.AccentColor2 : button.FlatAppearance.CheckedBackColor;
                    }
                }
                else
                {
                    fore = button.UseThemeColors ? GCLColors.SecondaryText : button.ForeColor;
                }

                e.Graphics.Clear(back);
                using (Pen p = new Pen(border))
                using(Brush b = new SolidBrush(fore))
                {
                    Rectangle br = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                    e.Graphics.DrawRectangle(p, br);
                    if(button.Image != null)
                    {
                        e.Graphics.DrawImage(button.Image, GetImageDrawingPoint(e.ClipRectangle, button.Image, button.ImageAlign, button.Padding));
                    }

                    if(button.ImageList != null && button.ImageKey != null && button.ImageKey != "")
                    {
                        e.Graphics.DrawImage(button.ImageList.Images[button.ImageKey], GetImageDrawingPoint(e.ClipRectangle, button.Image, button.ImageAlign, button.Padding));
                    }

                    StringAlignment valign = StringAlignment.Center;
                    StringAlignment halign = StringAlignment.Center;
                    switch(button.TextAlign)
                    {
                        case ContentAlignment.BottomCenter:
                            valign = StringAlignment.Far;
                            halign = StringAlignment.Center;
                            break;
                        case ContentAlignment.BottomLeft:
                            valign = StringAlignment.Far;
                            halign = StringAlignment.Near;
                            break;
                        case ContentAlignment.BottomRight:
                            valign = StringAlignment.Far;
                            halign = StringAlignment.Far;
                            break;
                        case ContentAlignment.MiddleCenter:
                            valign = StringAlignment.Center;
                            halign = StringAlignment.Center;
                            break;
                        case ContentAlignment.MiddleLeft:
                            valign = StringAlignment.Center;
                            halign = StringAlignment.Near;
                            break;
                        case ContentAlignment.MiddleRight:
                            valign = StringAlignment.Center;
                            halign = StringAlignment.Far;
                            break;
                        case ContentAlignment.TopCenter:
                            valign = StringAlignment.Near;
                            halign = StringAlignment.Center;
                            break;
                        case ContentAlignment.TopLeft:
                            valign = StringAlignment.Near;
                            halign = StringAlignment.Near;
                            break;
                        case ContentAlignment.TopRight:
                            valign = StringAlignment.Near;
                            halign = StringAlignment.Far;
                            break;
                    }

                    e.Graphics.DrawString(button.Text, button.Font, b, e.ClipRectangle, new StringFormat() { Alignment = halign, LineAlignment = valign });
                }
            }
        }

        private static PointF GetImageDrawingPoint(Rectangle r, Image img, ContentAlignment align, Padding padding)
        {
            PointF buttonCenter = new PointF((r.Right + r.Left) / 2, (r.Top + r.Bottom) / 2);
            PointF imageCenter = new PointF(img.Width / 2, img.Height / 2);

            float x = 0;
            float y = 0;

            switch(align)
            {
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    x = r.Right - img.Width - padding.Right;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    x = buttonCenter.X - imageCenter.X;
                    break;
                default:
                    x = padding.Left;
                    break;
            }

            switch (align)
            {
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.MiddleCenter:
                    y = buttonCenter.Y - imageCenter.Y;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    y = r.Bottom - img.Height - padding.Bottom;
                    break;
                default:
                    y = padding.Top;
                    break;

            }

            return new PointF(x, y);
        }
    }
}
