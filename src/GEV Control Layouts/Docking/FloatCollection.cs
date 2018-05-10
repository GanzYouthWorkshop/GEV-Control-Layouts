using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Docking
{
    public class FloatCollection : List<IFloatingWindow>
    {
        public IFloatingWindow Find(Control container)
        {
            foreach (FloatingWindow f in this)
            {
                if (f.DockState.Container.Equals(container))
                {
                    return f;
                }
            }
            return null;
        }
    }
}
