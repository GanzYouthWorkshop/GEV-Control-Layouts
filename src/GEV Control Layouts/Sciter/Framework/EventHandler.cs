using SciterSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Sciter.Framework
{
    public class EventHandler : SciterEventHandler
    {
        private GCLHtmlControl m_Control;

        public EventHandler(GCLHtmlControl control)
        {
            this.m_Control = control;
        }

        protected override bool OnScriptCall(SciterElement se, string name, SciterValue[] args, out SciterValue result)
        {
            SciterValue val = null;
            this.m_Control.PerformScriptCalled(se, name, args, out val);
            result = val;
            return true;
        }
    }
}
