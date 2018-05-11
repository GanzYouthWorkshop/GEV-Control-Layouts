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
    public partial class GCLButton : Button, IGCLControl, IGCLButtonlike
    {
        public bool UseThemeColors { get; set; } = true;
        public bool IsHovered { get; private set; } = false;
        public bool IsPressed { get; private set; } = false;

        [Browsable(false)]
        public  bool Checked { get; set; } = false;

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

            this.MouseEnter += OnMouseEnter;
            this.MouseLeave += OnMouseLeave;
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            this.IsPressed = false;
            this.Invalidate();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            this.IsPressed = true;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            this.IsHovered = false;
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            this.IsHovered = true;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Utils.GCLUtils.DrawButtonlike(this, pevent);
        }
    }
}
