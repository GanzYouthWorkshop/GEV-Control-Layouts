using SciterSharp;
using SciterSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Sciter.Framework
{
    class Host : SciterHost
    {
        public Host(GCLHtmlControl control) : base()
        {
            this.SetupWindow(control.m_Container.SciterWnd);
            this.AttachEvh(new EventHandler(control));
        }
    }
}
