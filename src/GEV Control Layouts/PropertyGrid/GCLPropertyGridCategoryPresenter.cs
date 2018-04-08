using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.PropertyGrid
{
    internal partial class GCLPropertyGridCategoryPresenter : UserControl
    {
        public object DataSource { get; set; }
        public PropertyCategory Category { get; set; }

        public GCLPropertyGridCategoryPresenter()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.label2.Text = Category.Name.ToUpper();

            this.tableLayoutPanel1.RowCount = this.Category.Properties.Count;
            this.tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < this.Category.Properties.Count; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
                string strvalue = "null";
                object value = this.Category.Properties[i].GetValue(this.DataSource);
                if(value != null)
                {
                    strvalue = value.ToString();
                }

                Label name = new Label() { Text = this.Category.Properties[i].Name, Dock = DockStyle.Fill };
                Label lblvalue = new Label() { Text = strvalue, Dock = DockStyle.Fill };
                this.tableLayoutPanel1.Controls.Add(name, 0, i);
                this.tableLayoutPanel1.Controls.Add(lblvalue, 1, i);
            }

        }
    }
}
