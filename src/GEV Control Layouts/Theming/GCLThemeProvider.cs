using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public BasicThemes BasicTheme { get; set; }

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
