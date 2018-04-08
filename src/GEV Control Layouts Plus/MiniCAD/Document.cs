using GEV.Layouts.Extended.MiniCAD.Components;
using GEV.Layouts.Extended.MiniCAD.Layers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Implementation
{
    [Serializable]
    public class Document
    {
        public List<ILayer> Layers { get; } = new List<ILayer>();

        public RectangleF BoundingBox
        {
            get
            {
                float x1 = 0;
                float y1 = 0;
                float x2 = 0;
                float y2 = 0;
                foreach(ILayer l in this.Layers)
                {
                    if(l is ComponentLayer)
                    {
                        foreach (IComponent c in (l as ComponentLayer).Components)
                        {
                            RectangleF bb = c.BoundingBox;

                            x1 = Math.Min(x1, bb.X);
                            y1 = Math.Min(y1, bb.Y);
                            x2 = Math.Max(x2, bb.X);
                            y2 = Math.Max(y2, bb.Y);
                        }
                    }
                }

                return new RectangleF(x1, y1, x2 - x1, y2 - y1);
            }
        }
    }
}
