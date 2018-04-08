using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using GEV.Layouts.PropertyGrid.EditControls;

namespace GEV.Layouts.PropertyGrid.DisplayControls
{
    public partial class ColorDisplay : EditFormDisplay
    {
        private Color m_Color;

        public ColorDisplay()
        {
            InitializeComponent();
        }

        public override void Setup(object dataSource, PropertyInfo info, object value)
        {
            base.Setup(dataSource, info, value);
            this.m_Color = (Color)value;

            Color c = this.m_Color;

            this.pnlColor.BackColor = this.m_Color;
            this.lblName.Text = String.Format("ARGB: #{0:X2}{1:X2}{2:X2}{3:X2}", c.A, c.R, c.G, c.B);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ColorEditor dialog = new ColorEditor();
            dialog.Color = this.m_Color;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.m_Property.SetValue(this.m_DataSource, dialog.Color);
                this.m_Color = dialog.Color;
                this.pnlColor.BackColor = dialog.Color;
                this.lblName.Text = String.Format("ARGB: #{0:X2}{1:X2}{2:X2}{3:X2}", dialog.Color.A, dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }
        }

        private void OnSelect(object sender, EventArgs e)
        {
            this.PerformSelected();
        }
    }
}
