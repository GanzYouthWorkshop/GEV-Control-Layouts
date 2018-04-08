using System;
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
    public partial class GCLGroupBox : GroupBox
    {
        public GCLGroupBox()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Dock != DockStyle.None)
            {
                Rectangle r = this.Bounds;
                //r.X += 3;
                //r.Y += 3;
                //r.Width -= 6;
                //r.Height -= 6;

                e.Graphics.Clear(this.Parent.BackColor);
                e.Graphics.FillRectangle(Brushes.White, r);
            }
            else
            {
                e.Graphics.Clear(Color.White);
            }
        }
    }
}
