using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLRadioButton : RadioButton, IGCLButtonlike, IGCLControl
    {
        public bool UseThemeColors { get; set; } = true;
        public bool IsHovered { get; private set; } = false;
        public bool IsPressed { get; private set; } = false;

        public GCLRadioButton()
        {
            this.Appearance = Appearance.Button;

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = GCLColors.SoftBorder;
            this.FlatAppearance.CheckedBackColor = GCLColors.AccentColor2;
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
