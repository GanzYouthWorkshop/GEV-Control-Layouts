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
using GEV.Layouts.Utils;

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

        private List<PropertyCategory> m_InternalPropertyData;

        public Color ActiveColor { get; set; } = GCLColors.AccentColor1;
        public Color GridColor { get; set; } = GCLColors.SoftBorder;
        public Color PropertyBackColor { get; set; } = GCLColors.Shadow;
        public Color PropertyTextColor { get; set; } = GCLColors.PrimaryText;
        public Color PropertyDisabledTextColor { get; set; } = GCLColors.SecondaryText;
        public Color PropertyBorderColor { get; set; } = GCLColors.SoftBorder;

        public GCLPropertyGrid()
        {
            InitializeComponent();
            this.lblProperty.Text = "";
            this.lblDescription.Text = "";
        }

        protected void BuildGUI()
        {
            PropertyInfo[] properties = this.m_DataSource.GetType().GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Public);

            MethodInfo[] methods = this.m_DataSource.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            var nameProperty = properties.FirstOrDefault(p => p.Name == "Name");
            if(nameProperty != null)
            {
                this.lblName.Text = nameProperty.GetValue(this.DataSource).ToString();
            }
            this.lblType.Text = PropertyGridUtils.GetLocalizedName(this.m_DataSource.GetType());

            var propertyData = properties.GroupBy(prop => prop.GetCustomAttribute<CategoryAttribute>(true))
                                         .Select(group => new { Category = group.First().GetCustomAttribute<CategoryAttribute>(true), Items = group.ToList() })
                                         .ToList();

            var methodData = methods.Where(method => PropertyGridUtils.IsCommandMethod(method))
                                         .GroupBy(method => method.GetCustomAttribute<CategoryAttribute>(true))
                                         .Select(group => new { Category = group.First().GetCustomAttribute<CategoryAttribute>(true), Items = group.ToList() })
                                         .ToList();

            this.m_InternalPropertyData = new List<PropertyCategory>();
            foreach(var pd in propertyData)
            {
                string cat = pd.Category != null ? pd.Category.Category : "Egyéb";

                var methodsInCategory = methodData.FirstOrDefault(item => (item.Category == null && pd.Category == null) || item.Category.Category == pd.Category.Category);

                List<MemberInfo> allMembers = new List<MemberInfo>();
                allMembers.AddRange(pd.Items);
                if(methodsInCategory != null)
                {
                    allMembers.AddRange(methodsInCategory.Items);
                }

                this.m_InternalPropertyData.Add(new PropertyCategory()
                {
                    Name = cat,
                    Collapsed = false,
                    Properties = allMembers
                });
            }

            this.DrawGUI();
        }

        protected void DrawGUI()
        {
            foreach (PropertyCategory pc in this.m_InternalPropertyData)
            {
                CategoryPresenter cp = new CategoryPresenter()
                {
                    Dock = DockStyle.Top,
                    DataSource = this.m_DataSource,
                    Category = pc,

                    GridColor = this.GridColor,
                    ActiveColor = this.ActiveColor,
                    BackColor = this.PropertyBackColor,
                    PropertyBorderColor = this.PropertyBorderColor
                };
                this.pnlCategoryPresenters.Controls.Add(cp);
                cp.ElementSelected += Cp_ElementSelected;

            }

            foreach (Control c in this.pnlCategoryPresenters.Controls)
            {
                (c as CategoryPresenter).BuildGUI();
            }
        }

        private void Cp_ElementSelected(object sender, EventArgs e)
        {
            if(sender is ElementPresenter)
            {
                ElementPresenter ep = sender as ElementPresenter;
                ep.IsSelected = true;

                this.lblProperty.Text = PropertyGridUtils.GetLocalizedName(ep.ReflectionInfo);
                this.lblDescription.Text = PropertyGridUtils.GetLocalizedDescription(ep.ReflectionInfo);

                foreach (Control c in this.pnlCategoryPresenters.Controls)
                {
                    if (c is CategoryPresenter)
                    {
                        (c as CategoryPresenter).ResetSelection(ep);
                    }
                }
            }
        }
    }
}
