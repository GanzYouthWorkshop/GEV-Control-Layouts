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
using System.Drawing.Text;
using System.Collections;

namespace GEV.Layouts.PropertyGrid
{
    public partial class GCLPropertyGrid : UserControl
    {
        protected object m_DataSource;
        public object DataSource
        {
            get
            {
                return this.m_DataSource;
            }

            set
            {
                this.m_DataSource = value;

                if (this.m_DataSource != null)
                {
                    this.BuildGUI();
                }
            }
        }

        private Bitmap m_Bitmap;
        private List<PropertyCategory> m_InternalPropertyData;

        public GCLPropertyGrid()
        {
            InitializeComponent();
        }

        protected void BuildGUI()
        {
            PropertyInfo[] properties = this.m_DataSource.GetType().GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Public);

            var propertyData = properties.GroupBy(prop => prop.GetCustomAttribute<CategoryAttribute>(true))
                                         .Select(group => new { Category = group.First().GetCustomAttribute<CategoryAttribute>(true), Items = group.ToList() })
                                         .ToList();

            this.m_InternalPropertyData = new List<PropertyCategory>();
            foreach(var pd in propertyData)
            {
                string cat = pd.Category != null ? pd.Category.Category : "Egyéb";

                this.m_InternalPropertyData.Add(new PropertyCategory()
                {
                    Name = cat,
                    Collapsed = false,
                    Properties = pd.Items
                });
            }

            this.DrawGUI();
        }

        protected void DrawGUI()
        {
            foreach (PropertyCategory pc in this.m_InternalPropertyData)
            {
                this.panel1.Controls.Add(new CategoryPresenter()
                {
                    Dock = DockStyle.Top,
                    DataSource = this.m_DataSource,
                    Category = pc
                });
            }

            foreach (Control c in this.panel1.Controls)
            {
                (c as CategoryPresenter).BuildGUI();
            }
        }
    }
}
