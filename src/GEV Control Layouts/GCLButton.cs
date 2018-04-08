using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GEV.Layouts
{
    public partial class GCLButton : Button
    {
        public GCLButton()
        {
            InitializeComponent();

            this.FlatStyle = FlatStyle.Flat;

            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = GCLColors.SoftBorder;

            this.FlatAppearance.MouseOverBackColor = GCLColors.AccentColor1Highlight;
            this.FlatAppearance.MouseDownBackColor = GCLColors.AccentColor1;
            
            this.BackColor = GCLColors.Button;
            this.ForeColor = GCLColors.PrimaryText;
        }
    }
}
