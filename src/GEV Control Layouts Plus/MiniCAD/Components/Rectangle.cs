using GEV.Layouts.Extended.MiniCAD.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Components
{
    public class RectangleComponent : IComponent
    {
        public RectangleF BoundingBox
        {
            get
            {
                return new RectangleF(10, 10, 10, 10);
            }
        }

        public PointF Position { get; set; }


        public void Draw(Graphics g, RectangleF viewport, float zoom)
        {
            PointF pos = new PointF(10, 10);
            SizeF size = new SizeF(10, 10);

            PointF posScr = GeometryUtils.MapInnerToScreen(pos, viewport, zoom);
            SizeF sizeScr = GeometryUtils.MapInnerToScreen(size, viewport, zoom);
            g.FillRectangle(Brushes.Red, new RectangleF(posScr, sizeScr));
        }
    }
}
