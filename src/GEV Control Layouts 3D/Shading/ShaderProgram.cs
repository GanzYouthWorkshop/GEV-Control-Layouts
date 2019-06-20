using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Shading
{
    public class ShaderProgram
    {
        public const string DEFAULT_SOLID = "DSOLID";
        public const string DEFAULT_TEXTURED = "DTEXTURE";
        public const string DEFAULT_TEXT = "DTEXT";
        public const string DEFAULT_GORAUD = "DGORAUD";
        public const string DEFAULT_PHONG = "DPHONG";

        public int ID { get; private set; }
        private List<int> m_Shaders = new List<int>();

        public ShaderProgram()
        {
            this.ID = GL.CreateProgram();
        }

        public void Link()
        {
            foreach (int shaderId in this.m_Shaders)
            {
                GL.AttachShader(this.ID, shaderId);
            }
            GL.LinkProgram(this.ID);

            this.Debug();

            foreach (int shaderId in this.m_Shaders)
            {
                GL.DetachShader(ID, shaderId);
                GL.DeleteShader(shaderId);
            }
        }

        public void AddShaderFromFile(ShaderType type, string path)
        {
            var src = File.ReadAllText(path);

            this.AddShader(type, src);
        }

        public void AddShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type);

            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);

            this.Debug();

            this.m_Shaders.Add(shader);
        }

        public void Debug()
        {
#if DEBUG
            string info = GL.GetProgramInfoLog(this.ID);
            if (!String.IsNullOrWhiteSpace(info))
            {
                Console.WriteLine($"GL.LinkProgram had info log: {info}");
            }
#endif
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                GL.DeleteProgram(this.ID);
            }
        }
    }
}
