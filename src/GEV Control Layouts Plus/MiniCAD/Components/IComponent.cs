using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Components
{
    public interface IComponent : IDrawable
    {
        PointF Position { get; set; }
        RectangleF BoundingBox { get; }
    }
}
