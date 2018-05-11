using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Docking
{
    [Browsable(false)]
    internal partial class DockOverlay : Form
    {
        public new DockStyle Dock { get; set; }
        public Control DockHostControl { get; set; }

        public DockOverlay()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(GCLColors.AccentColor1);
        }
    }
}
