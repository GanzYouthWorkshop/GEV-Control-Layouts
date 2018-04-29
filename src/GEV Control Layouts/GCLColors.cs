using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts
{
    public class GCLColors
    {
        public static bool UsingSketchMode = false;

        public static Color FormBackground = Color.FromArgb(57, 65, 68);
        public static Color PanelBackground = Color.FromArgb(74, 84, 86);
        public static Color HeaderBackground = Color.FromArgb(32, 36, 37);
        public static Color MenuBackground = Color.FromArgb(40, 40, 40);

        public static Color Border = Color.FromArgb(47, 55, 55);
        public static Color SoftBorder = Color.FromArgb(57, 62, 65);
        public static Color Shadow = Color.FromArgb(63, 71, 74);
        public static Color Button = Color.FromArgb(71, 76, 79);

        public static Color AccentColor1 = Color.FromArgb(24, 134, 171);
        public static Color AccentColor1Highlight = Color.FromArgb(27, 158, 202);
        public static Color AccentColor2 = Color.FromArgb(119, 87, 152);
        public static Color AccentColor2Highlight = Color.FromArgb(138, 106, 170);
        public static Color AccentColor3 = Color.FromArgb(32, 36, 37);

        public static Color PrimaryText = Color.FromArgb(240, 240, 240);
        public static Color SecondaryText = Color.FromArgb(167, 167, 171);

        public static Color SuccessGreen = Color.FromArgb(76, 175, 80);
        public static Color ErrorRed = Color.FromArgb(224, 67, 54);
        public static Color AlertYellow = Color.FromArgb(255, 193, 0);
    }
}
