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
    public class ComponentLayer : ILayer
    {
        public List<IComponent> Components { get; } = new List<IComponent>();

        public void Draw(Graphics g, RectangleF viewport, float zoom)
        {
            foreach(IComponent c in this.Components)
            {
                if(Implementation.GeometryUtils.IsBoundingBoxInViewport(viewport, c.BoundingBox))
                {
                    c.Draw(g, viewport, zoom);
                }
            }
        }
    }
}
