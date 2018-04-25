using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    public enum GCLLanguages
    {
        Default = 0,
        English = 1033,
        German = 1031,
        Hungarian = 1038,
        ChineseSimplified = 2052,
        SpanishMexican = 2058
    }

    internal class GCLLanguageTable
    {
        private static Dictionary<int, string> s_Table = new Dictionary<int, string>
        {
            { 0, "default-default" },
            { 1033, "en-us" },
            { 1031, "de-de" },
            { 1038, "hu-hu" },
            { 2052, "zh-cn" },
            { 2058, "es-mx" },
        };

        public static string GetLocale(GCLLanguages language)
        {
            if(s_Table.ContainsKey((int)language))
            {
                return s_Table[(int)language];
            }
            else
            {
                return "default-default";
            }
        }
    }
}
