using GEV.Layouts.D3.Graphics.Vertex;
using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Graphics.Mesh
{
    public class ColoredCube : BasicMesh<ColoredVertex>
    {
        public ColoredCube(Color c)
        {
            this.Composition = CompositionModes.TriangleStrip;

            float side = 0.5f;
            Color4 color = new Color4(0.1f, 0.9f, 0.3f, 1.0f);// new Color4(c.R, c.G, c.B, c.A);
            this.Vertices = new ColoredVertex[]
            {
                new ColoredVertex(new Vector4(-side, -side, -side, 1.0f),   color),
                new ColoredVertex(new Vector4(-side, -side, side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, -side, side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, side, side, 1.0f),     color),

                new ColoredVertex(new Vector4(side, -side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(side, side, -side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, -side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, -side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, side, -side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, side, side, 1.0f),      color),

                new ColoredVertex(new Vector4(-side, -side, -side, 1.0f),   color),
                new ColoredVertex(new Vector4(side, -side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, -side, side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, -side, side, 1.0f),    color),
                new ColoredVertex(new Vector4(side, -side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(side, -side, side, 1.0f),     color),

                new ColoredVertex(new Vector4(-side, side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, side, -side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, side, -side, 1.0f),     color),
                new ColoredVertex(new Vector4(-side, side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, side, side, 1.0f),      color),

                new ColoredVertex(new Vector4(-side, -side, -side, 1.0f),   color),
                new ColoredVertex(new Vector4(-side, side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(side, -side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(side, -side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(-side, side, -side, 1.0f),    color),
                new ColoredVertex(new Vector4(side, side, -side, 1.0f),     color),

                new ColoredVertex(new Vector4(-side, -side, side, 1.0f),    color),
                new ColoredVertex(new Vector4(side, -side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(-side, side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(-side, side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, -side, side, 1.0f),     color),
                new ColoredVertex(new Vector4(side, side, side, 1.0f),      color),
            };
        }
    }
}
