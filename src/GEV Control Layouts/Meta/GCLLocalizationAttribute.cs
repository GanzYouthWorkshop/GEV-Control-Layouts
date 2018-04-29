using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public abstract class GCLLocalizationAttribute : Attribute
    {
        internal string LocalizedValue { get; }

        public string Locale { get; }
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
