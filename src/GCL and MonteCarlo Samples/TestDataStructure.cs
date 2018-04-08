using GEV.Layouts.PropertyGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class TestDataStructure
    {
        [Category("Alapok")]
        public int One { get; set; }
        [Category("Alapok")]
        public int Two { get; }
        private int Three { get; }
        public string Four { get; set; }

        [GCLDisplay(typeof(ButtonDisplay))]
        public Color Five { get; set; }
    }
}
