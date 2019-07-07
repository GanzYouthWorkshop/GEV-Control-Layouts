using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class GCLCommandAttribute : Attribute
    {
        public bool ShowResultInMessageBox { get; }
        public bool ShowButtonOnly { get; }

        public GCLCommandAttribute()
        {
            this.ShowResultInMessageBox = true;
            this.ShowButtonOnly = true;
        }

        public GCLCommandAttribute(bool showButtonOnly, bool showResultInMessageBox)
        {
            this.ShowResultInMessageBox = showResultInMessageBox;
            this.ShowButtonOnly = showButtonOnly;
        }
    }
}
