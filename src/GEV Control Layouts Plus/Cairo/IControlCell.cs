using GEV.Layouts.Extended.Cairo.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.Cairo
{
    public interface IControlCell
    {
        SolidColor Color1 { get; set; }
        SolidColor Color2 { get; set; }
        SolidColor Color3 { get; set; }
        SolidColor Color4 { get; set; }
    }
}
