using GEV.Layouts.D3.Graphics.Vertex;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Graphics.Mesh
{
    public abstract class BasicMesh
    {
        public enum CompositionModes
        {
            Points = 0,

            Lines = 1,
            LineStrip = 3,

            Triangles = 4,
            TriangleStrip = 5,
            TriangleFan = 6,

            Quads = 7,
            QuadStrip = 7,

            LineLoop = 2,
            Polygon = 9,
        }

        public Type VertexType { get; protected set; }
        public CompositionModes Composition { get; set; } = CompositionModes.TriangleStrip;

        public abstract int VertexCount { get; }

        public Array UnboundVertices { get; protected set; }
    }

    public class BasicMesh<T> : BasicMesh where T : struct, IVertex
    {
        public T[] Vertices
        {
            get { return (T[])this.UnboundVertices; }
            set { this.UnboundVertices = value; }
        }

        public override int VertexCount
        {
            get { return this.Vertices.Length; }
        }

        public BasicMesh()
        {
            this.VertexType = typeof(T);
        }
    }
}
