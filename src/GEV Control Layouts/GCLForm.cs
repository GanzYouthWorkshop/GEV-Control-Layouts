using GEV.Layouts.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public partial class GCLForm : Form, IGCLControl
    {
        public bool UseThemeColors { get; set; } = true;
        public bool HideStartMenuOnMaximize { get; set; } = false;

        public Color BorderColor { get; set; } = GCLColors.Border;

        public GCLForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Color back = this.UseThemeColors ? GCLColors.FormBackground : this.BackColor;
            Color border = this.UseThemeColors ? GCLColors.Border : this.BorderColor;

            e.Graphics.Clear(back);
            using (Pen p = new Pen(border))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        internal void SetMaximizeBounds(Rectangle r)
        {
            this.MaximizedBounds = r;
        }
    }
}
