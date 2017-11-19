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
    public partial class GCLToggleButton : CheckBox
    {
        public GCLToggleButton()
        {
            InitializeComponent();

            this.FlatStyle = FlatStyle.Flat;
            this.Appearance = Appearance.Button;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(57, 174, 169);
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 73, 94);
            this.FlatAppearance.CheckedBackColor = Color.FromArgb(46, 204, 113);

            this.BackColor = Color.FromArgb(52, 73, 94);
            this.ForeColor = Color.White;
        }
    }
}
