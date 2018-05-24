using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEV.Layouts.Extended.MiniCAD.Implementation;

namespace GEV.Layouts.Extended.MiniCAD
{
    public partial class MiniCADEditor : UserControl
    {
        public Document Document
        {
            get { return this.canvas.Document; }
            set { this.canvas.Document = value; }
        }

        public MiniCADEditor()
        {
            InitializeComponent();

            this.canvas.MouseWheel += MiniCADCanvas1_MouseWheel;
        }

        private void MiniCADCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            int i = e.Delta;
            if(i > 0)
            {
                this.canvas.Zoom *= 1.1f;
            }
            else
            {
                this.canvas.Zoom *= 0.9f;
            }
            this.canvas.Invalidate();

            this.UpdateInfoText();
        }

        private Point m_LastMouseLocation = new Point(-1, -1);
        private void miniCADCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                if(this.m_LastMouseLocation.X != -1)
                {
                    float dx = ((e.Location.X - this.m_LastMouseLocation.X)  * (1 / this.canvas.Zoom)) * -1;
                    float dy = ((e.Location.Y - this.m_LastMouseLocation.Y) * (1 / this.canvas.Zoom)) * -1;
                    PointF p = new PointF(this.canvas.ViewportPosition.X + dx, this.canvas.ViewportPosition.Y + dy);
                    this.canvas.ViewportPosition = p;
                    this.canvas.Invalidate();
                }
                this.m_LastMouseLocation = e.Location;
            }
            else
            {
                this.m_LastMouseLocation = new Point(-1, -1);
            }

            if(this.canvas.SnapPointUnderCursor != null)
            {
                this.toolTip1.SetToolTip(this.canvas, this.canvas.SnapPointUnderCursor.Name);
                this.toolTip1.Active = true;
            }
            else
            {
                this.toolTip1.Active = false;
            }

            this.UpdateInfoText();
        }

        private void UpdateInfoText()
        {
            var c = canvas;
            this.label1.Text = String.Format("Cursor: [{0:0.000}; {1:0.000}] | Viewport: [{2:0.000}; {3:0.000}] | Zoom: {4:0%}", c.CursorPosition.X, c.CursorPosition.Y, c.ViewportPosition.X, c.ViewportPosition.Y, c.Zoom);
        }

        private void canvas_MouseEnter(object sender, EventArgs e)
        {
            this.canvas.Focus();
        }
    }
}
