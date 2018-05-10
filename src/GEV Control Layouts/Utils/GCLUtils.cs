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
                    e.Graphics.DrawRectangle(p, e.ClipRectangle);
                    e.Graphics.DrawString(button.Text, button.Font, b, e.ClipRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }
        }
    }
}
