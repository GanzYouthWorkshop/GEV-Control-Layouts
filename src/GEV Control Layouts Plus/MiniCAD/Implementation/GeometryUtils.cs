using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Implementation
{
    public class GeometryUtils
    {
        public static bool IsBoundingBoxInViewport(RectangleF viewport, RectangleF boundingBox)
        {
            RectangleF vp = viewport;
            RectangleF bb = boundingBox;

            if (bb.Right < vp.Left || bb.Left > vp.Right || bb.Bottom < vp.Top || bb.Top > vp.Bottom)
            {
                return false;
            }
            return true;
        }

        public static PointF MapInnerToScreen(PointF p, RectangleF viewport, float zoom)
        {
            float x = (p.X - viewport.X) * zoom;
            float y = (p.Y - viewport.Y) * zoom;
            
            return new PointF(x, y);
        }

        public static SizeF MapInnerToScreen(SizeF p, RectangleF viewport, float zoom)
        {
            float x = (p.Width) * zoom;
            float y = (p.Height) * zoom;

            return new SizeF(x, y);
        }

        public static PointF MapScreenToInner(Point p, RectangleF viewport, float zoom)
        {
            float x = viewport.X + p.X / zoom;
            float y = viewport.Y + p.Y / zoom;

            return new PointF(x, y);
        }

        public static float PointDistance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
