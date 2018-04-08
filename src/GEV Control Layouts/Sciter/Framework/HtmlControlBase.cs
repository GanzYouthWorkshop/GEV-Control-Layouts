using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SciterSharp;
using SciterSharp.WinForms;

namespace GEV.Layouts.Sciter.Framework
{
    public abstract partial class HtmlControlBase : UserControl
    {
        internal SciterControl m_Container;
        private SciterHost m_Host;

        public delegate void ScriptCallEventHandler(object sender, SciterElement se, string name, SciterValue[] args, out SciterValue result);
        public event ScriptCallEventHandler ScriptCalled;

        public HtmlControlBase()
        {
            InitializeComponent();
            this.m_Container = new SciterControl();
            this.m_Container.HandleCreated += M_Container_HandleCreated;

            this.m_Container.Dock = DockStyle.Fill;
            this.Controls.Add(this.m_Container);
        }

        private void M_Container_HandleCreated(object sender, EventArgs e)
        {
            this.m_Container.SciterWnd.LoadHtml(this.Setup());
            this.m_Container.HandleCreated -= M_Container_HandleCreated;

            this.m_Host = new Host(this);
        }

        internal void PerformScriptCalled(SciterElement se, string name, SciterValue[] args, out SciterValue result)
        {
            SciterValue val = null;
            this.ScriptCalled?.Invoke(this, se, name, args, out val);
            result = val;
        }

        protected abstract string Setup();
    }
}
