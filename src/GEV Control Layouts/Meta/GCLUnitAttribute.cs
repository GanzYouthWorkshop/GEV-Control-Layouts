﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Meta
{
    public class GCLUnitAttribute : Attribute
    {
        public string Unit { get; }

        public GCLUnitAttribute(string unit)
        {
            this.Unit = unit;
        }
    }
}
