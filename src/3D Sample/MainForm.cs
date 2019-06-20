using GEV.Layouts.D3;
using GEV.Layouts.D3.Data;
using GEV.Layouts.D3.Graphics.Mesh;
using GEV.Layouts.D3.Graphics.Renderable;
using GEV.Layouts.D3.Shading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_Sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            GCL3DViewport viewport = new GCL3DViewport()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DarkBlue,
            };

            viewport.Scene = new GCLScene();

            float maxX = 2.5f;
            float maxY = 1.5f;
            for (float x = -maxX; x < maxX; x += 0.65f)
            {
                for (float y = -maxY; y < maxY; y += 0.65f)
                {
                    viewport.Scene.SceneObjects.Add(
                        new SceneObject(
                            new ColoredRenderable(
                                new ColoredCube(Color.Red),
                                viewport.Scene.ShaderPrograms[ShaderProgram.DEFAULT_SOLID]),
                            new GCLVector4(x, y, 6f, 0),
                            new GCLVector4(0),
                            new GCLVector4(0),
                            new GCLVector3(0.3f),
                            0
                            ));
                }
            }

            viewport.Scene.SceneObjects.Add(
                        new SceneObject(
                            new ColoredRenderable(
                                //new ColoredCube(Color.Red),
                                new ColoredRangeMap(@"J:\Heightmap.png"),
                                viewport.Scene.ShaderPrograms[ShaderProgram.DEFAULT_SOLID]),
                            new GCLVector4(0, 0, 5f, 0),
                            new GCLVector4(0),
                            new GCLVector4(0, (float)(Math.PI / 2f), 0, 0),
                            new GCLVector3(0.01f),
                            0
                            ));




            this.Controls.Add(viewport);

            viewport.KeyPress += Viewport_KeyPress;
        }

        private void Viewport_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar.ToString().ToLower()[0];
            GCL3DViewport viewport = (GCL3DViewport)sender;

            switch (key)
            {
                case 'a': viewport.Camera.Move(0.1f, 0, 0); break;
                case 'd': viewport.Camera.Move(-0.1f, 0, 0); break;
                case 'w': viewport.Camera.Move(0, 0.1f, 0); break;
                case 's': viewport.Camera.Move(0, -0.1f, 0); break;
                case 'r': viewport.Camera.Move(0, 0, 0.1f); break;
                case 'f': viewport.Camera.Move(0, 0, -0.1f); break;

                case '0': viewport.RenderModeOverride = BasicRenderable.RenderModes.DontCare; break;
                case '1': viewport.RenderModeOverride = BasicRenderable.RenderModes.Points; break;
                case '2': viewport.RenderModeOverride = BasicRenderable.RenderModes.Lines; break;
                case '3': viewport.RenderModeOverride = BasicRenderable.RenderModes.Faces; break;
            }

            /*
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Key.PageDown) && _lastKeyboardState.IsKeyUp(Key.PageDown))
            {
            }
            if (keyState.IsKeyDown(Key.M))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Point);
            }
            if (keyState.IsKeyDown(Key.Comma))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            }
            if (keyState.IsKeyDown(Key.Period))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            }

            if (keyState.IsKeyDown(Key.A))
            {
                this.Camera.Move(0.1f, 0, 0);
            }
            if (keyState.IsKeyDown(Key.D))
            {
                this.Camera.Move(-0.1f, 0, 0);
            }
            if (keyState.IsKeyDown(Key.R))
            {
                this.Camera.Move(0, 0.1f, 0);
            }
            if (keyState.IsKeyDown(Key.F))
            {
                this.Camera.Move(0, -0.1f, 0);
            }
            if (keyState.IsKeyDown(Key.W))
            {
                this.Camera.Move(0, 0, 0.1f);
            }
            if (keyState.IsKeyDown(Key.S))
            {
                this.Camera.Move(0, 0, -0.1f);
            }
            _lastKeyboardState = keyState;*/
        }
    }
}
