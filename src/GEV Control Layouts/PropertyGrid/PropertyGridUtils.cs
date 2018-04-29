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
        #region Property
        public static string GetLocalizedName(MemberInfo pi)
        {
            string result = GetLocalizedAttribute<GCLNameAttribute>(pi);

            if(result != null)
            {
                return result;
            }
            else
            {
                var nameOld = pi.GetCustomAttribute<DisplayNameAttribute>(true);
                if (nameOld != null)
                {
                    return nameOld.DisplayName;
                }
            }

            return pi.Name;
        }

        public static string GetLocalizedDescription(MemberInfo pi)
        {
            string result = GetLocalizedAttribute<GCLDescriptionAttribute>(pi);

            if (result != null)
            {
                return result;
            }
            else
            {
                var descOld = pi.GetCustomAttribute<DescriptionAttribute>(true);
                if (descOld != null)
                {
                    return descOld.Description;
                }
            }

            return "";

        }

        private static string GetLocalizedAttribute<T>(MemberInfo pi) where T : GCLLocalizationAttribute
        {
            string currentLocale = Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();

            var names = pi.GetCustomAttributes<T>(true);

            foreach (var attr in names)
            {
                if (attr.Locale.ToLowerInvariant() == currentLocale)
                {
                    return attr.LocalizedValue;
                }
            }

            return null;
        }
        #endregion

        #region Class
        public static string GetLocalizedName(Type t)
        {
            string result = GetLocalizedAttribute<GCLNameAttribute>(t);

            if (result != null)
            {
                return result;
            }
            else
            {
                var nameOld = t.GetCustomAttribute<DisplayNameAttribute>(true);
                if (nameOld != null)
                {
                    return nameOld.DisplayName;
                }
            }

            return t.Name;
        }

        public static string GetLocalizedDescription(Type t)
        {
            string result = GetLocalizedAttribute<GCLDescriptionAttribute>(t);

            if (result != null)
            {
                return result;
            }
            else
            {
                var descOld = t.GetCustomAttribute<DescriptionAttribute>(true);
                if (descOld != null)
                {
                    return descOld.Description;
                }
            }

            return "";
        }

        private static string GetLocalizedAttribute<T>(Type t) where T : GCLLocalizationAttribute
        {
            string currentLocale = Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();

            var names = t.GetCustomAttributes<T>(true);

            foreach (var attr in names)
            {
                if (attr.Locale.ToLowerInvariant() == currentLocale)
                {
                    return attr.LocalizedValue;
                }
            }

            return null;
        }
        #endregion

        #region Command method
        public static bool IsCommandMethod(MethodInfo mi)
        {
            GCLCommandAttribute attr = mi.GetCustomAttribute<GCLCommandAttribute>(true);
            if(attr != null)
            {
                if(mi.GetParameters().Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetLocalizedCommandName(MethodInfo mi)
        {
            string result = GetLocalizedAttribute<GCLCommandDescriptionAttribute>(mi);

            if(result == null)
            {
                result = "";
            }

            return result;
        }
        #endregion
    }
}
