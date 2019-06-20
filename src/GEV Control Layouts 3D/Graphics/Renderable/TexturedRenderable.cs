using GEV.Layouts.D3.Graphics.Mesh;
using GEV.Layouts.D3.Graphics.Vertex;
using GEV.Layouts.D3.Shading;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Graphics.Renderable
{
    public class TexturedRenderable : BasicRenderable
    {
        public TexturedRenderable(BasicMesh<TexturedVertex> mesh, ShaderProgram program) : base(mesh, program, RenderModes.Faces)
        {
        }

        protected override void CreateBuffer(int bufferSize)
        {
            GL.NamedBufferStorage(this.m_BufferPointer, bufferSize, (this.Mesh.UnboundVertices as TexturedVertex[]), BufferStorageFlags.MapWriteBit);
        }
    }
}
