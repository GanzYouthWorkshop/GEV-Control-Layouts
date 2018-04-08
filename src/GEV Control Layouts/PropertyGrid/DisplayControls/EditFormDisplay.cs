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
    public partial class EditFormDisplay : UserControl, IDisplayControl
    {
        public event EventHandler Selected;

        protected PropertyInfo m_Property;
        protected object m_DataSource;

        public EditFormDisplay()
        {
            InitializeComponent();
        }

        public void ForceValidate()
        {
        }

        public virtual void Setup(object dataSource, PropertyInfo info, object value)
        {
            this.m_DataSource = dataSource;
            this.m_Property = info;
        }

        protected void PerformSelected()
        {
            this.Selected?.Invoke(this, new EventArgs());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Selected?.Invoke(this, new EventArgs());
        }
    }
}
