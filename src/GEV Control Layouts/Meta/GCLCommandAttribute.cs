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

        public GCLCommandAttribute()
        {
            this.ShowResultInMessageBox = true;
        }

        public GCLCommandAttribute(bool showResultInMessageBox)
        {
            this.ShowResultInMessageBox = showResultInMessageBox;
        }
    }
}
