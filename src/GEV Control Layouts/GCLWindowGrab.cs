using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public partial class GCLWindowGrab : UserControl
    {
        public GCLWindowGrab()
        {
            InitializeComponent();
        }

        private void lblGrab_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ParentForm.Width += e.X;
                this.ParentForm.Height += e.Y;
            }

        }
    }
}
