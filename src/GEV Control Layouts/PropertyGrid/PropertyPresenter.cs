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

namespace GEV.Layouts.PropertyGrid
{
    [ToolboxItem(false)]
    internal partial class PropertyPresenter : UserControl
    {
        public event EventHandler PropertySelected;
        public event EventHandler<int> GridChanging;

        public PropertyInfo Property
        {
            get
            {
                return this.m_Property;
            }

            set
            {
                this.m_Property = value;
                this.BuildGUI();
            }
        }
        private PropertyInfo m_Property;

        private IDisplayControl m_DisplayControl;

        public object DataSource { get; set; }

        public bool IsSelected
        {
            get
            {
                return this.m_Selected;
            }
            set
            {
                if(this.m_Selected == true && value == false)
                {
                    this.ForceValidate();
                }
                this.m_Selected = value;
                this.Invalidate();
            }
        }
        private bool m_Selected;

        public PropertyPresenter()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public void BuildGUI()
        {
            this.lblName.Text = this.m_Property.Name;

            if (this.DataSource != null)
            {
                object prop = this.m_Property.GetValue(this.DataSource);
                if (prop != null)
                {
                    bool customDisplayUsed = false;

                    var customDisplay = this.m_Property.GetCustomAttributes<GCLDisplayAttribute>(true);
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

                        this.m_DisplayControl.Setup(this.DataSource, this.m_Property, prop);
                        this.m_DisplayControl.Selected += PropertyDisplay_Click;

                        this.container.Panel2.Controls.Add(c);

                        c.Click += PropertyDisplay_Click;
                    }
                }
            }
        }

        public void ForceValidate()
        {
            if(m_DisplayControl != null)
            {
                this.m_DisplayControl.ForceValidate();
            }
        }

        public void SetGrid(int i)
        {
            this.container.SplitterDistance = i;
        }

        private void PropertyDisplay_Click(object sender, EventArgs e)
        {
            this.PropertySelected?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.IsSelected)
            {
                e.Graphics.Clear(GCLColors.AccentColor1);
            }
            else
            {
                e.Graphics.Clear(GCLColors.Shadow);
            }

            using (Brush b = new SolidBrush(GCLColors.SoftBorder))
            {
                e.Graphics.FillRectangle(b, new Rectangle(0, this.Bounds.Height - 1, this.Bounds.Width, this.Bounds.Height));
            }
        }

        private void OnSplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            this.GridChanging?.Invoke(this, e.SplitX);
        }

        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {
            using (Brush b = new SolidBrush(GCLColors.SoftBorder))
            using (Pen p = new Pen(b, 2))
            {
                int x = this.container.SplitterRectangle.X;
                int h = this.container.SplitterRectangle.Height;
                e.Graphics.DrawLine(p, x, 0, x, h);
            }
        }
    }
}
