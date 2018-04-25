using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Theming
{
    public static class ControlExtensions
    {
        public static GCLForm GetGCLForm(this Control c)
        {
            Form f = c.FindForm();
            if(f != null && f is GCLForm)
            {
                return (f as GCLForm);
            }
            return null;
        }
    }
}
