using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.PropertyGrid
{
    public interface IDisplayControl
    {
        void Setup(object dataSource, PropertyInfo info, object value);
        event EventHandler Selected;
        void ForceValidate();
    }
}
