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
    public partial class GCLForm : Form
    {
        public bool HideStartMenuOnMaximize { get; set; } = false;

        public GCLForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            using (Brush b = new SolidBrush(GCLColors.Border))
            using (Pen p = new Pen(b))
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
