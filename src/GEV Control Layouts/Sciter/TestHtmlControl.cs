using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEV.Layouts.Sciter.Framework;

namespace GEV.Layouts.Sciter
{
    public partial class TestHtmlControl : HtmlControlBase
    {
        public TestHtmlControl()
        {
            InitializeComponent();

            this.ScriptCalled += TestHtmlControl_ScriptCalled;
        }

        protected override string Setup()
        {
            return "<button>JUST DO IT!</button>";
        }

        private void TestHtmlControl_ScriptCalled(object sender, SciterSharp.SciterElement se, string name, SciterSharp.SciterValue[] args, out SciterSharp.SciterValue result)
        {
            throw new NotImplementedException();
        }

    }
}
