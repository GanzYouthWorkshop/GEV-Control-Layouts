using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.PropertyGrid
{
    internal class PropertyCategory
    {
        public string Name { get; set; }
        public bool Collapsed { get; set; }
        public List<PropertyInfo> Properties { get; set; }
    }

}
