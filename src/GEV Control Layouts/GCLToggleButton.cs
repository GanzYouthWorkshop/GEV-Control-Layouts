﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public partial class GCLToggleButton : CheckBox
    {
        public GCLToggleButton()
        {
            InitializeComponent();

            this.FlatStyle = FlatStyle.Flat;
            this.Appearance = Appearance.Button;
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = GCLColors.SoftBorder;
            this.FlatAppearance.CheckedBackColor = GCLColors.AccentColor2;
            this.FlatAppearance.MouseOverBackColor = GCLColors.AccentColor1Highlight;
            this.FlatAppearance.MouseDownBackColor = GCLColors.AccentColor1;

            this.BackColor = GCLColors.Button;
            this.ForeColor = GCLColors.PrimaryText;
        }
    }
}