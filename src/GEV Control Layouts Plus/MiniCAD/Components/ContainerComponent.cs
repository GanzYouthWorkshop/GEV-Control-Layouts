using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Components
{
    public abstract class ContainerComponent : IComponent
    {
        public List<IComponent> Components { get; } = new List<IComponent>();

        public abstract RectangleF BoundingBox { get; }
        public PointF Position { get; set; }

        public virtual void Draw(Graphics g, RectangleF viewport, float zoom)
        {
            foreach(IComponent c in this.Components)
            {
                c.Draw(g, viewport, zoom);
            }
        }
    }
}
