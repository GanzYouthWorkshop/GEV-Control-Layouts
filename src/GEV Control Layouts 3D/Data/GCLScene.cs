using GEV.Layouts.D3.Shading;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Data
{
    public class GCLScene : IDisposable
    {
        public Dictionary<string, ShaderProgram> ShaderPrograms { get; } = new Dictionary<string, ShaderProgram>();
        public List<SceneObject> SceneObjects { get; } = new List<SceneObject>(); //TODO techdump

        public GCLScene()
        {
            ShaderProgram tmp;

            tmp = new ShaderProgram();
            tmp.AddShaderFromFile(ShaderType.VertexShader, @"Components\Shaders\1Vert\textVert.c");
            tmp.AddShaderFromFile(ShaderType.FragmentShader, @"Components\Shaders\5Frag\textFrag.c");
            tmp.Link();
            this.ShaderPrograms.Add(ShaderProgram.DEFAULT_TEXT, tmp);

            tmp = new ShaderProgram();
            tmp.AddShaderFromFile(ShaderType.VertexShader, @"Components\Shaders\1Vert\simplePipeVert.c");
            tmp.AddShaderFromFile(ShaderType.FragmentShader, @"Components\Shaders\5Frag\simplePipeFrag.c");
            tmp.Link();
            this.ShaderPrograms.Add(ShaderProgram.DEFAULT_SOLID, tmp);

            tmp = new ShaderProgram();
            tmp.AddShaderFromFile(ShaderType.VertexShader, @"Components\Shaders\1Vert\gouraudPipeSolidVert.c");
            tmp.AddShaderFromFile(ShaderType.FragmentShader, @"Components\Shaders\5Frag\gouraudPipeFrag.c");
            tmp.Link();
            this.ShaderPrograms.Add(ShaderProgram.DEFAULT_GORAUD, tmp);

            tmp = new ShaderProgram();
            tmp.AddShader(ShaderType.VertexShader, @"Components\Shaders\1Vert\phongPipeSolidVert.c");
            tmp.AddShader(ShaderType.FragmentShader, @"Components\Shaders\5Frag\phongPipeFrag.c");
            tmp.Link();
            this.ShaderPrograms.Add(ShaderProgram.DEFAULT_PHONG, tmp);

            tmp = new ShaderProgram();
            tmp.AddShaderFromFile(ShaderType.VertexShader, @"Components\Shaders\1Vert\simplePipeTexVert.c");
            tmp.AddShaderFromFile(ShaderType.FragmentShader, @"Components\Shaders\5Frag\simplePipeTexFrag.c");
            tmp.Link();
            this.ShaderPrograms.Add(ShaderProgram.DEFAULT_TEXTURED, tmp);
        }

        public void Dispose()
        {
            foreach(KeyValuePair<string, ShaderProgram> sp in this.ShaderPrograms)
            {
                sp.Value.Dispose();
            }
        }
    }
}
