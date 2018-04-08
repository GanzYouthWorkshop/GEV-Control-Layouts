using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.PropertyGrid.EditControls
{
    public partial class ColorEditor : GCLForm
    {
        public Color Color
        {
            get
            {
                return this.gclColorPicker1.Color;
            }
            set
            {
                this.gclColorPicker1.Color = value;
            }
        }

        public ColorEditor()
        {
            InitializeComponent();
        }

        private void OnPredefinedColorClick(object sender, EventArgs e)
        {
            this.gclColorPicker1.Color = (sender as Control).BackColor;
        }
    }
}
