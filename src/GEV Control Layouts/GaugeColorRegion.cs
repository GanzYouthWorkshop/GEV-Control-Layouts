using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts
{
    [TypeConverter(typeof(CollectionConverter))]
    public class GaugeColorRegion
    {
        public int Start { get; set; }
        public int Stop { get; set; }
        public Color Col { get; set; }
    }
}
