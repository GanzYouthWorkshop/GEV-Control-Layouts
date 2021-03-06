﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace GEV.Layouts.PropertyGrid
{
    [ToolboxItem(false)]
    internal partial class CategoryPresenter : UserControl, IGCLControl
    {
        public object DataSource { get; set; }
        public PropertyCategory Category { get; set; }

        public bool UseThemeColors
        {
            get
            {
                return this.m_UseThemeColors;
            }
            set
            {
                foreach (Control c in this.pnlPropertyPresenters.Controls)
                {
                    if (c is IGCLControl)
                    {
                        (c as IGCLControl).UseThemeColors = value;
                    }
                }
                this.m_UseThemeColors = value;
            }
        }
        protected bool m_UseThemeColors;


        public event EventHandler ElementSelected;
        public event EventHandler<int> GridChanging;

        public Color GridColor { get; set; }
        public Color ButtonColor { get; set; }
        public Color ActiveColor { get; set; }
        public Color PropertyBorderColor { get; set; }

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
                if(this.Category.Properties[i] is PropertyInfo)
                {
                    PropertyInfo info = (PropertyInfo)this.Category.Properties[i];
                    bool browsable = info.CustomAttributes.Count(attr => attr.AttributeType.Equals(typeof(BrowsableAttribute))) == 0;

                    if(browsable)
                    {
                        string strvalue = "null";
                        object value = info.GetValue(this.DataSource);
                        if (value != null)
                        {
                            strvalue = value.ToString();
                        }

                        PropertyPresenter tmp = new PropertyPresenter()
                        {
                            DataSource = this.DataSource,
                            Property = info,
                            Dock = DockStyle.Top,

                            ActiveColor = this.ActiveColor,
                            BackColor = this.BackColor,
                            BorderColor = this.PropertyBorderColor,
                            //Property háttér, border, text?
                        };
                        tmp.ElementSelected += OnElementSelected;
                        tmp.GridChanging += OnGridChanging;
                        this.pnlPropertyPresenters.Controls.Add(tmp);
                    }
                }
                else if(this.Category.Properties[i] is MethodInfo)
                {
                    MethodInfo info = (MethodInfo)this.Category.Properties[i];

                    CommandMethodPresenter tmp = new CommandMethodPresenter()
                    {
                        DataSource = this.DataSource,
                        Method = info,
                        Dock = DockStyle.Top,

                        ActiveColor = this.ActiveColor,
                        BackColor = this.BackColor,
                        BorderColor = this.PropertyBorderColor,
                        //Property háttér, border, text?

                    };
                    tmp.ElementSelected += OnElementSelected;
                    tmp.GridChanging += OnGridChanging;
                    this.pnlPropertyPresenters.Controls.Add(tmp);
                }
            }
        }

        private void OnGridChanging(object sender, int e)
        {
            //this.ChangeGrid(sender, e);
            this.GridChanging?.Invoke(sender, e);
        }

        private void OnElementSelected(object sender, EventArgs e)
        {
            this.ElementSelected?.Invoke(sender, e);
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

        public void ResetSelection(ElementPresenter presenter)
        {
            foreach(Control c in this.pnlPropertyPresenters.Controls)
            {
                ElementPresenter ep = (c as ElementPresenter);
                if (ep != presenter && ep.IsSelected)
                {
                    ep.IsSelected = false;
                }
            }
        }

        public void ChangeGrid(object origin, int i)
        {
            foreach (ElementPresenter c in this.pnlPropertyPresenters.Controls)
            {
                if(c != origin)
                {
                    c.SetGrid(i);
                }
            }
        }
    }
}
