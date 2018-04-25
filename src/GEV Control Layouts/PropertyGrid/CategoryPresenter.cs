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

        public Color GridColor { get; set; }
        public Color ButtonColor { get; set; }
        public Color ActiveColor { get; set; }

        public CategoryPresenter()
        {
            InitializeComponent();
        }

        public void BuildGUI()
        {
            this.tableLayoutPanel1.BackColor = this.GridColor;
            this.lblCategoryName.BackColor = this.GridColor;
            this.gclToggleButton1.FlatAppearance.CheckedBackColor = this.ActiveColor;
            this.gclToggleButton1.BackColor = this.ButtonColor;

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
                    Dock = DockStyle.Top,

                    ActiveColor = this.ActiveColor,
                    BackColor = this.BackColor
                    //Property háttér, border, text?
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
