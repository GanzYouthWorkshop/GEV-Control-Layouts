using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public static class GCLResourceProvider
    {
        public static void ApplyResource(this Form form, string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            ComponentResourceManager resources = new ComponentResourceManager(form.GetType());

            resources.ApplyResources(form, "$this");
            form.ApplyResourceToChilds(resources);
        }

        public static void ApplyResourceToChilds(this Control control, ComponentResourceManager resources)
        {
            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                c.ApplyResourceToChilds(resources);
            }
        }
    }
}
