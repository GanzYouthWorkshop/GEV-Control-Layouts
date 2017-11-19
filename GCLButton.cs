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
    public partial class GCLButton : Button
    {
        public GCLButton()
        {
            InitializeComponent();

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(57, 174, 169);
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 73, 94);
            
            this.BackColor = Color.FromArgb(52, 73, 94);
            this.ForeColor = Color.White;
        }
    }
}
