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
using GEV.Layouts.Sciter.Framework;

namespace GEV.Layouts.Sciter
{
    public partial class GCLHtmlControl : UserControl
    {
        internal SciterControl m_Container;
        private SciterHost m_Host;

        public delegate void ScriptCallEventHandler(object sender, SciterElement se, string name, SciterValue[] args, out SciterValue result);
        public event ScriptCallEventHandler ScriptCalled;

        public new event System.EventHandler HandleCreated;

        public string HTML
        {
            get
            {
                return this.m_HTML;
            }

            set
            {
                this.m_HTML = value;
                if (this.m_HTML != null)
                {
                    if(!this.m_Container.IsHandleCreated)
                    {
                        this.m_Container.CreateControl();
                    }

                    this.m_Container.SciterWnd.LoadHtml(this.m_HTML);
                }
            }
        }
        private string m_HTML;

        public GCLHtmlControl()
        {
            InitializeComponent();
            this.m_Container = new SciterControl();
            this.m_Container.HandleCreated += M_Container_HandleCreated;

            this.m_Container.Dock = DockStyle.Fill;
            this.Controls.Add(this.m_Container);
        }

        private void M_Container_HandleCreated(object sender, EventArgs e)
        {
            this.m_Container.HandleCreated -= M_Container_HandleCreated;

            this.m_Host = new Host(this);

            this.HandleCreated?.Invoke(this, null);
        }

        public void RunJavaScript(string script)
        {
            var result = this.m_Container.SciterWnd.CallFunction("eval", new SciterValue(script));
            var disp = result.ToString();
        }

        public void ShowDebugger()
        {
            //TODO
            //this.m_Host.DebugInspect();
        }

        internal void PerformScriptCalled(SciterElement se, string name, SciterValue[] args, out SciterValue result)
        {
            SciterValue val = null;
            this.ScriptCalled?.Invoke(this, se, name, args, out val);
            result = val;
        }
    }
}
