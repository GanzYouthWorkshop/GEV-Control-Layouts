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
    public partial class GCLButton : Button, IGCLControl
    {
        public bool UseThemeColors { get; set; } = true;

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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //Color c1 = this.FlatAppearance.BorderColor;
            //Color c2 = this.FlatAppearance.MouseOverBackColor;
            //Color c3 = this.FlatAppearance.MouseDownBackColor;
            //Color c4 = this.BackColor;
            //Color c5 = this.ForeColor;

            //if (this.UseThemeColors)
            //{
            //    this.FlatAppearance.BorderColor = GCLColors.SoftBorder;
            //    this.FlatAppearance.MouseOverBackColor = GCLColors.AccentColor1Highlight;
            //    this.FlatAppearance.MouseDownBackColor = GCLColors.AccentColor1;
            //    this.BackColor = GCLColors.Button;
            //    this.ForeColor = GCLColors.PrimaryText;
            //}

            base.OnPaint(pevent);

            //this.FlatAppearance.BorderColor = c1;
            //this.FlatAppearance.MouseOverBackColor = c2;
            //this.FlatAppearance.MouseDownBackColor = c3;
            //this.BackColor = c4;
            //this.ForeColor = c5;
        }
    }
}
