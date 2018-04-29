using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    public class GCLCommandDescriptionAttribute : GCLLocalizationAttribute
    {
        public string CommandString { get { return this.LocalizedValue; } }

        public GCLCommandDescriptionAttribute(string command, string locale) : base(command, locale)
        {
        }

        public GCLCommandDescriptionAttribute(string command, GCLLanguages language) : base(command, language)
        {
        }

    }
}
