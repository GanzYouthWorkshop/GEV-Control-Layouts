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
    [ToolboxItem(false)]
    internal partial class CategoryPresenter : UserControl
    {
        public object DataSource { get; set; }
        public PropertyCategory Category { get; set; }

        public event EventHandler PropertySelected;
        public event EventHandler<int> GridChanging;

        public CategoryPresenter()
        {
            InitializeComponent();
        }

        public void BuildGUI()
        {
            this.lblCategoryName.Text = Category.Name.ToUpper();

            for (int i = 0; i < this.Category.Properties.Count; i++)
            {
                string strvalue = "null";
                object value = this.Category.Properties[i].GetValue(this.DataSource);
                if (value != null)
                {
                    strvalue = value.ToString();
                }

                PropertyPresenter tmp = new PropertyPresenter()
                {
                    DataSource = this.DataSource,
                    Property = this.Category.Properties[i],
                    Dock = DockStyle.Top
                };
                tmp.PropertySelected += OnPropertySelected;
                tmp.GridChanging += OnGridChanging;
                this.pnlPropertyPresenters.Controls.Add(tmp);
            }
        }

        private void OnGridChanging(object sender, int e)
        {
            //this.ChangeGrid(sender, e);
            this.GridChanging?.Invoke(sender, e);
        }

        private void OnPropertySelected(object sender, EventArgs e)
        {
            this.PropertySelected?.Invoke(sender, e);
        }

        private void gclToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.gclToggleButton1.Checked)
            {
                this.pnlPropertyPresenters.Show();
            }
            else
            {
                this.pnlPropertyPresenters.Hide();
            }
        }

        public void ResetSelection(PropertyPresenter presenter)
        {
            foreach(Control c in this.pnlPropertyPresenters.Controls)
            {
                PropertyPresenter pp = (c as PropertyPresenter);
                if (pp != presenter && pp.IsSelected)
                {
                    pp.IsSelected = false;
                }
            }
        }

        public void ChangeGrid(object origin, int i)
        {
            foreach (PropertyPresenter c in this.pnlPropertyPresenters.Controls)
            {
                if(c != origin)
                {
                    c.SetGrid(i);
                }
            }
        }
    }
}
