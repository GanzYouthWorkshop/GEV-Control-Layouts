using GEV.Layouts.D3.Graphics.Mesh;
using GEV.Layouts.D3.Graphics.Vertex;
using GEV.Layouts.D3.Shading;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Graphics.Renderable
{
    public class ColoredRenderable : BasicRenderable
    {
        public ColoredRenderable(BasicMesh<ColoredVertex> mesh, ShaderProgram program) : base(mesh, program, RenderModes.Faces)
        {
        }

        protected override void CreateBuffer(int bufferSize)
        {
            GL.NamedBufferStorage(this.m_BufferPointer, bufferSize, (this.Mesh.UnboundVertices as ColoredVertex[]), BufferStorageFlags.MapWriteBit);
        }
    }
}
