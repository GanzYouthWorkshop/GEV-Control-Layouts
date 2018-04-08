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

namespace GEV.Layouts.PropertyGrid.DisplayControls
{
    [ToolboxItem(false)]
    internal partial class SimpleDisplay : UserControl, IDisplayControl
    {
        public SimpleDisplay()
        {
            InitializeComponent();
        }

        public event EventHandler Selected;

        private PropertyInfo m_Property;
        private object m_DataSource;

        private GCLComboBox m_Combobox;
        private GCLTextbox m_TextBox;
        private GCLNumericUpDown m_Numeric;

        public void Setup(object dataSource, PropertyInfo info, object value)
        {
            this.m_Property = info;
            this.m_DataSource = dataSource;

            if (value != null)
            {
                Color c = info.SetMethod != null ? Color.Empty : GCLColors.SecondaryText;
                this.lblName.Text = value.ToString();
                this.lblName.ForeColor = c;
            }

            this.m_Combobox = new GCLComboBox()
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            this.m_TextBox = new GCLTextbox()
            {
                Dock = DockStyle.Fill,
            };

            this.m_Numeric = new GCLNumericUpDown()
            {
                Dock = DockStyle.Fill,
                Minimum = Decimal.MinValue,
                Maximum = Decimal.MaxValue,
            };

            this.m_Combobox.Hide();
            this.m_TextBox.Hide();
            this.m_Numeric.Hide();

            this.Controls.Add(this.m_Combobox);
            this.Controls.Add(this.m_TextBox);
            this.Controls.Add(this.m_Numeric);
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            this.Selected?.Invoke(this, e);
            this.SetEditMode();
        }

        private void SetEditMode()
        {
            if (this.m_Property.SetMethod != null)
            {
                object value = this.m_Property.GetValue(this.m_DataSource);
                if (m_Property.PropertyType == typeof(bool))
                {
                    bool b = !(bool)value;
                    this.m_Property.SetValue(this.m_DataSource, b);
                    this.lblName.Text = b.ToString();

                }
                else if (m_Property.PropertyType.IsEnum)
                {
                    this.m_Combobox.Show();
                    this.lblName.Hide();

                    this.m_Combobox.DataSource = m_Property.PropertyType.GetEnumValues();
                    this.m_Combobox.SelectedItem = value;
                }
                else if (m_Property.PropertyType == typeof(string) || m_Property.PropertyType == typeof(char))
                {
                    this.m_TextBox.Show();
                    this.lblName.Hide();

                    this.m_TextBox.Text = value.ToString();
                    this.m_TextBox.Focus();
                }
                else
                {
                    this.m_Numeric.Show();
                    this.lblName.Hide();

                    this.m_Numeric.Value = Convert.ToDecimal(value);
                    this.Controls.Add(this.m_Numeric);
                    this.m_Numeric.Focus();
                }
            }
        }

        private void lblName_DoubleClick(object sender, EventArgs e)
        {
            this.SetEditMode();
        }

        public void ForceValidate()
        {
            //this.lblName.Focus();
            bool needsUpdate = false;

            if (this.m_Combobox.Visible)
            {
                needsUpdate = true;

                this.m_Property.SetValue(this.m_DataSource, this.m_Combobox.SelectedValue);
            }
            else if(this.m_TextBox.Visible)
            {
                needsUpdate = true;

                this.m_Property.SetValue(this.m_DataSource, this.m_TextBox.Text);
            }
            else if(this.m_Numeric.Visible)
            {
                needsUpdate = true;

                this.m_Numeric.Validate();

                Type t = null;
                if (this.m_Property.PropertyType == typeof(byte))           { t = typeof(byte); }
                else if (this.m_Property.PropertyType == typeof(short))     { t = typeof(short); }
                else if (this.m_Property.PropertyType == typeof(int))       { t = typeof(int); }
                else if (this.m_Property.PropertyType == typeof(long))      { t = typeof(long); }
                else if (this.m_Property.PropertyType == typeof(ushort))    { t = typeof(ushort); }
                else if (this.m_Property.PropertyType == typeof(uint))      { t = typeof(uint); }
                else if (this.m_Property.PropertyType == typeof(ulong))     { t = typeof(ulong); }
                else if (this.m_Property.PropertyType == typeof(float))     { t = typeof(float); }
                else if (this.m_Property.PropertyType == typeof(double))    { t = typeof(double); }
                else if (this.m_Property.PropertyType == typeof(decimal))   { t = typeof(decimal); }

                if(t != null)
                {
                    this.m_Property.SetValue(this.m_DataSource, Convert.ChangeType(this.m_Numeric.Value, t));
                }
            }

            if(needsUpdate)
            {
                this.lblName.Show();

                this.m_Combobox.Hide();
                this.m_Numeric.Hide();
                this.m_TextBox.Hide();

                object value = this.m_Property.GetValue(this.m_DataSource);
                this.lblName.Text = value.ToString();
            }
        }
    }
}
