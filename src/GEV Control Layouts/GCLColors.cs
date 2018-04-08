using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts
{
    public static class GCLColors
    {
        public static Color FormBackground { get; } = Color.FromArgb(57, 65, 68);
        public static Color PanelBackground { get; } = Color.FromArgb(74, 84, 86);
        public static Color HeaderBackground { get; } = Color.FromArgb(32, 36, 37);

        public static Color Border { get; } = Color.FromArgb(47, 55, 55);
        public static Color SoftBorder { get; } = Color.FromArgb(57, 62, 65);
        public static Color Shadow { get; } = Color.FromArgb(63, 71, 74);
        public static Color Button { get; } = Color.FromArgb(71, 76, 79);

        public static Color AccentColor1 { get; } = Color.FromArgb(24, 134, 171);
        public static Color AccentColor1Highlight { get; } = Color.FromArgb(27, 158, 202);
        public static Color AccentColor2 { get; } = Color.FromArgb(119, 87, 152);
        public static Color AccentColor2Highlight { get; } = Color.FromArgb(138, 106, 170);
        public static Color AccentColor3 { get; } = Color.FromArgb(32, 36, 37);

        public static Color PrimaryText = Color.FromArgb(240, 240, 240);
        public static Color SecondaryText = Color.FromArgb(167, 167, 171);

        public static Color SuccessGreen = Color.FromArgb(76, 175, 80);
        public static Color ErrorRed = Color.FromArgb(224, 67, 54);
        public static Color AlertYellow = Color.FromArgb(255, 193, 0);
    }
}
