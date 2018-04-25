using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    public class GCLDescriptionAttribute : GCLLocalizationAttribute
    {
        public string Description { get { return this.LocalizedValue; } }

        public GCLDescriptionAttribute(string name, string locale) : base(name, locale)
        {
        }

        public GCLDescriptionAttribute(string name, GCLLanguages language) : base(name, language)
        {
        }
    }
}
