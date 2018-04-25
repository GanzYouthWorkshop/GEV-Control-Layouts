using GEV.Layouts.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GEV.Layouts.PropertyGrid
{
    internal class PropertyGridUtils
    {
        public static string GetLocalizedName(PropertyInfo pi)
        {
            string result = GetLocalizedAttribute<GCLNameAttribute>(pi);

            if(result == null)
            {
                var nameOld = pi.GetCustomAttribute<DisplayNameAttribute>(true);
                if (nameOld != null)
                {
                    return nameOld.DisplayName;
                }
            }

            return pi.Name;
        }

        public static string GetLocalizedDescription(PropertyInfo pi)
        {
            string result = GetLocalizedAttribute<GCLDescriptionAttribute>(pi);

            if (result == null)
            {
                var descOld = pi.GetCustomAttribute<DescriptionAttribute>(true);
                if (descOld != null)
                {
                    return descOld.Description;
                }
            }

            return "";

        }

        private static string GetLocalizedAttribute<T>(PropertyInfo pi) where T : GCLLocalizationAttribute
        {
            var names = pi.GetCustomAttributes<T>(true);

            foreach (var attr in names)
            {
                if (attr.Locale == Thread.CurrentThread.CurrentUICulture.Name)
                {
                    return attr.Locale;
                }
            }

            return null;
        }
    }
}
