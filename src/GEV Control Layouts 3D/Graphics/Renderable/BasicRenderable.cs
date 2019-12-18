using GEV.Layouts.D3.Camera;
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
    public abstract class BasicRenderable : IDisposable 
    {
        public enum RenderModes
        {
            DontCare = -1,

            Points = 6912,
            Lines = 6913,
            Faces = 6914,
        }

        public ShaderProgram Program { get; set; }
        public BasicMesh Mesh { get; }
        public RenderModes RenderMode { get; set; } = RenderModes.Faces;

        protected int m_VertexArrayPointer;
        protected int m_BufferPointer;

        protected int m_VerticeCount;

        public BasicRenderable(BasicMesh mesh, ShaderProgram program, RenderModes mode)
        {
            this.Mesh = mesh;
            this.Program = program;
            this.RenderMode = mode;

            this.m_VerticeCount = mesh.VertexCount;

            this.m_VertexArrayPointer = GL.GenVertexArray();
            GL.BindVertexArray(this.m_VertexArrayPointer);

            this.m_BufferPointer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.m_BufferPointer);

            int sizeofVertex = Marshal.SizeOf(mesh.UnboundVertices.GetValue(0).GetType());

            int bufferSize = sizeofVertex * mesh.VertexCount;
            this.CreateBuffer(bufferSize);

            this.BindVertexAttribute(0, 4, 0);
            this.BindVertexAttribute(1, 4, 16);

            GL.VertexArrayVertexBuffer(this.m_VertexArrayPointer, 0, this.m_BufferPointer, IntPtr.Zero, sizeofVertex);
        }

        protected abstract void CreateBuffer(int bufferSize);

        protected void BindVertexAttribute(int index, int size, int offset)
        {
            GL.VertexArrayAttribBinding(this.m_VertexArrayPointer, index, 0);
            GL.EnableVertexArrayAttrib(this.m_VertexArrayPointer, index);
            GL.VertexArrayAttribFormat(
                this.m_VertexArrayPointer,
                index,                      // attribute index, from the shader location = 0
                size,                       // size of attribute, vec4
                VertexAttribType.Float,     // contains floats
                false,                      // does not need to be normalized as it is already, floats ignore this flag anyway
                offset);                    // relative offset, first item
        }

        public void Bind()
        {
            GL.UseProgram(this.Program.ID);
            GL.BindVertexArray(this.m_VertexArrayPointer);
            GL.PolygonMode(MaterialFace.FrontAndBack, (PolygonMode)this.RenderMode);
        }

        public void Render()
        {
            GL.DrawArrays((PrimitiveType)this.Mesh.Composition, 0, this.m_VerticeCount);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                GL.DeleteVertexArray(this.m_VertexArrayPointer);
                GL.DeleteBuffer(this.m_BufferPointer);
            }
        }
    }
}
