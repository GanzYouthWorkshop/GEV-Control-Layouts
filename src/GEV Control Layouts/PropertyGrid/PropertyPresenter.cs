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
using System.Collections;
using GEV.Layouts.PropertyGrid.DisplayControls;
using GEV.Layouts.Utils;

namespace GEV.Layouts.PropertyGrid
{
    [ToolboxItem(false)]
    internal partial class PropertyPresenter : ElementPresenter
    {
        public PropertyInfo Property
        {
            get
            {
                return (PropertyInfo)this.ReflectionInfo;
            }

            set
            {
                this.ReflectionInfo = value;
            }
        }

        private IDisplayControl m_DisplayControl;

        public PropertyPresenter()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);

        }

        public override void BuildGUI()
        {
            this.lblName.Text = PropertyGridUtils.GetLocalizedName(this.Property);

            if (this.DataSource != null)
            {
                object prop = this.Property.GetValue(this.DataSource);
                if (prop != null)
                {
                    bool customDisplayUsed = false;

                    var customDisplay = this.Property.GetCustomAttributes<GCLDisplayAttribute>(true);
                    if(customDisplay.Count() > 0)
                    {
                        GCLDisplayAttribute display = customDisplay.First();
                        Type type = display.EditorType;

                        if(type.GetInterfaces().Contains(typeof(IDisplayControl)))
                        {
                            this.m_DisplayControl = (IDisplayControl)Activator.CreateInstance(type);
                            customDisplayUsed = true;
                        }
                    }

                    if(!customDisplayUsed)
                    {
                        Type propType = prop.GetType();
                        if (propType.IsPrimitive || propType.IsEnum || propType == typeof(string) || propType == typeof(char))
                        {
                            this.m_DisplayControl = new SimpleDisplay();
                        }
                        else if (prop is ICollection)
                        {
                            this.m_DisplayControl = new CollectionDisplay();
                        }
                        else if (propType == typeof(Color))
                        {
                            this.m_DisplayControl = new ColorDisplay();
                        }
                        else
                        {
                            this.m_DisplayControl = new EditFormDisplay();
                        }
                    }
                }


                if (this.m_DisplayControl != null)
                {
                    if(this.m_DisplayControl is Control)
                    {
                        Control c = this.m_DisplayControl as Control;
                        c.Dock = DockStyle.Fill;

                        this.m_DisplayControl.Setup(this.DataSource, this.Property, prop);
                        this.m_DisplayControl.Selected += this.PerformElementSelected;

                        this.container.Panel2.Controls.Add(c);

                        c.Click += this.PerformElementSelected;
                    }
                }
            }
        }

        public override void ForceValidate()
        {
            if(m_DisplayControl != null)
            {
                this.m_DisplayControl.ForceValidate();
            }
        }
    }
}
