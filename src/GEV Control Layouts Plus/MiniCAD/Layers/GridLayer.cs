using GEV.Layouts.Extended.MiniCAD.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Layers
{
    [Serializable]
    public class GridLayer : ILayer
    {
        public float GridSize { get; set; } = 1;
        public Color GridColor { get; set; } = Color.Gray;
        public Color ZeroColor { get; set; } = Color.LightGreen;
        public float MinimumZoomLevel { get; set; } = 1.3f;

        public List<SnapPoint> SnapPoints { get; } = new List<SnapPoint>();

        public void Draw(Graphics g, RectangleF viewport, float zoom)
        {
            this.SnapPoints.Clear();

            if(zoom > this.MinimumZoomLevel)
            {
                float dx = viewport.X % this.GridSize;
                float startX = viewport.X - (this.GridSize + dx);
                float dy = viewport.Y % this.GridSize;
                float startY = viewport.Y - (this.GridSize + dy);

                using (Pen p = new Pen(this.GridColor))
                using (Pen p2 = new Pen(this.ZeroColor))
                {
                    for (float x = startX; x < viewport.Right; x += this.GridSize)
                    {
                        PointF start = Implementation.GeometryUtils.MapInnerToScreen(new PointF(x, startY), viewport, zoom);
                        PointF end = Implementation.GeometryUtils.MapInnerToScreen(new PointF(x, viewport.Bottom), viewport, zoom);

                        g.DrawLine(x != 0 ? p : p2, start, end);
                    }

                    for (float y = startY; y < viewport.Bottom; y += this.GridSize)
                    {
                        PointF start = Implementation.GeometryUtils.MapInnerToScreen(new PointF(startX, y), viewport, zoom);
                        PointF end = Implementation.GeometryUtils.MapInnerToScreen(new PointF(viewport.Right, y), viewport, zoom);

                        g.DrawLine(y != 0 ? p : p2, start, end);
                    }
                }

                for (float x = startX; x < viewport.Right; x += this.GridSize)
                {
                    for (float y = startY; y < viewport.Bottom; y += this.GridSize)
                    {
                        this.SnapPoints.Add(new SnapPoint(null, String.Format("Grid.[{0:0.00}; {1:0.00}]", x, y), new PointF(x, y), SnapPoint.Roles.CornerPoint));
                    }
                }
            }
        }
    }
}
