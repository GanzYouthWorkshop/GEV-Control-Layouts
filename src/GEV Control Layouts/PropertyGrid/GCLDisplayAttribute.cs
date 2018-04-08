using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.PropertyGrid
{
    public class GCLDisplayAttribute : Attribute
    {
        public Type EditorType { get; set; }

        public GCLDisplayAttribute(Type t)
        {
            this.EditorType = t;
        }
    }
}
