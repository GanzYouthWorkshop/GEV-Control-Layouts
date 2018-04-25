using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    public abstract class GCLLocalizationAttribute : Attribute
    {
        protected string LocalizedValue { get; set; }

        public string Locale { get; set; }
        public string Language
        {
            get { return this.Locale.Split('-')[0]; }
        }
        public string LCID
        {
            get { return this.Locale; }
        }

        public GCLLocalizationAttribute(string name) : this(name, GCLLanguages.Default)
        {

        }

        public GCLLocalizationAttribute(string name, string locale)
        {
            this.LocalizedValue = name;
            this.Locale = locale;
        }

        public GCLLocalizationAttribute(string name, GCLLanguages language)
        {
            this.LocalizedValue = name;
            this.Locale = GCLLanguageTable.GetLocale(language);
        }
    }
}
