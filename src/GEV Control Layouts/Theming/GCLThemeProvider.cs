using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Theming
{
    public partial class GCLThemeProvider : Component
    {
        public GCLThemeProvider()
        {
            InitializeComponent();
        }

        public GCLThemeProvider(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public BasicThemes BasicTheme
        {
            get { return this.m_BasicTheme; }
            set
            {
                this.m_BasicTheme = value;
                if(value == BasicThemes.Dark)
                {
                    GCLColors.FormBackground = Color.FromArgb(57, 65, 68);
                    GCLColors.PanelBackground = Color.FromArgb(74, 84, 86);
                    GCLColors.HeaderBackground = Color.FromArgb(32, 36, 37);
                    GCLColors.MenuBackground = Color.FromArgb(40, 40, 40);

                    GCLColors.Border = Color.FromArgb(47, 55, 55);
                    GCLColors.SoftBorder = Color.FromArgb(57, 62, 65);
                    GCLColors.Shadow = Color.FromArgb(63, 71, 74);
                    GCLColors.Button = Color.FromArgb(71, 76, 79);

                    GCLColors.AccentColor1 = Color.FromArgb(24, 134, 171);
                    GCLColors.AccentColor1Highlight = Color.FromArgb(27, 158, 202);
                    GCLColors.AccentColor2 = Color.FromArgb(119, 87, 152);
                    GCLColors.AccentColor2Highlight = Color.FromArgb(138, 106, 170);
                    GCLColors.AccentColor3 = Color.FromArgb(32, 36, 37);

                    GCLColors.PrimaryText = Color.FromArgb(240, 240, 240);
                    GCLColors.SecondaryText = Color.FromArgb(167, 167, 171);

                    GCLColors.SuccessGreen = Color.FromArgb(76, 175, 80);
                    GCLColors.ErrorRed = Color.FromArgb(224, 67, 54);
                    GCLColors.AlertYellow = Color.FromArgb(255, 193, 0);
                }
                else if(value == BasicThemes.Light)
                {
                    GCLColors.FormBackground = Color.Gainsboro;
                    GCLColors.PanelBackground = Color.White;
                    GCLColors.HeaderBackground = Color.FromArgb(32, 36, 37);
                    GCLColors.MenuBackground = Color.FromArgb(40, 40, 40);

                    GCLColors.Border = Color.FromArgb(47, 55, 55);
                    GCLColors.SoftBorder = Color.Gainsboro;
                    GCLColors.Shadow = Color.White;
                    GCLColors.Button = Color.FromArgb(200, 200, 200);

                    GCLColors.AccentColor1 = Color.FromArgb(24, 134, 171);
                    GCLColors.AccentColor1Highlight = Color.FromArgb(27, 158, 202);
                    GCLColors.AccentColor2 = Color.FromArgb(119, 87, 152);
                    GCLColors.AccentColor2Highlight = Color.FromArgb(138, 106, 170);
                    GCLColors.AccentColor3 = Color.FromArgb(32, 36, 37);

                    GCLColors.PrimaryText = Color.FromArgb(34, 34, 34);
                    GCLColors.SecondaryText = Color.FromArgb(120, 120, 120);

                    GCLColors.SuccessGreen = Color.FromArgb(76, 175, 80);
                    GCLColors.ErrorRed = Color.FromArgb(224, 67, 54);
                    GCLColors.AlertYellow = Color.FromArgb(255, 193, 0);
                }

                if(this.Container is Form)
                {
                    (this.Container as Form).Invalidate();
                }
            }
        }
        private BasicThemes m_BasicTheme = BasicThemes.Dark;

        public Color FormBackground { get { return GCLColors.FormBackground; } set { GCLColors.FormBackground = value; } }
        public Color PanelBackground { get { return GCLColors.PanelBackground; } set { GCLColors.PanelBackground = value; } }
        public Color HeaderBackground { get { return GCLColors.HeaderBackground; } set { GCLColors.HeaderBackground = value; } }
        public Color MenuBackground { get { return GCLColors.MenuBackground; } set { GCLColors.MenuBackground = value; } }

        public Color Border { get { return GCLColors.Border; } set { GCLColors.Border = value; } }
        public Color SoftBorder { get { return GCLColors.SoftBorder; } set { GCLColors.SoftBorder = value; } }
        public Color Shadow { get { return GCLColors.Shadow; } set { GCLColors.Shadow = value; } }
        public Color Button { get { return GCLColors.Button; } set { GCLColors.Button = value; } }

        public Color AccentColor1 { get { return GCLColors.AccentColor1; } set { GCLColors.AccentColor1 = value; } }
        public Color AccentColor1Highlight { get { return GCLColors.AccentColor1Highlight; } set { GCLColors.AccentColor1Highlight = value; } }
        public Color AccentColor2 { get { return GCLColors.AccentColor2; } set { GCLColors.AccentColor2 = value; } }
        public Color AccentColor2Highlight { get { return GCLColors.AccentColor2Highlight; } set { GCLColors.AccentColor2Highlight = value; } }
        public Color AccentColor3 { get { return GCLColors.AccentColor3; } set { GCLColors.AccentColor3 = value; } }

        public Color PrimaryText { get { return GCLColors.PrimaryText; } set { GCLColors.PrimaryText = value; } }
        public Color SecondaryText { get { return GCLColors.SecondaryText; } set { GCLColors.SecondaryText = value; } }

        public Color SuccessGreen { get { return GCLColors.SuccessGreen; } set { GCLColors.SuccessGreen = value; } }
        public Color ErrorRed { get { return GCLColors.ErrorRed; } set { GCLColors.ErrorRed = value; } }
        public Color AlertYellow { get { return GCLColors.AlertYellow; } set { GCLColors.AlertYellow = value; } }

    }
}
