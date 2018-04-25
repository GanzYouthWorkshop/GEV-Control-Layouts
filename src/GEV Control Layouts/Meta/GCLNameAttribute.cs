using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    public class GCLNameAttribute : GCLLocalizationAttribute
    {
        public string Name { get { return this.LocalizedValue; } }

        public GCLNameAttribute(string name, string locale) : base(name, locale)
        {
        }

        public GCLNameAttribute(string name, GCLLanguages language) : base(name, language)
        {
        }
    }
}
