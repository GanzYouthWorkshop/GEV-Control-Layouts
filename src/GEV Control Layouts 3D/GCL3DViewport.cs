using GEV.Layouts.D3.Camera;
using GEV.Layouts.D3.Data;
using GEV.Layouts.D3.Graphics.Renderable;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.D3
{
    public class GCL3DViewport : UserControl
    {
        private GLControl m_InnerDisplay;
        private Timer m_AutoTimer;

        public event EventHandler FrameRendering;

        public ICamera Camera { get; set; }
        public GCLScene Scene { get; set; }

        public BasicRenderable.RenderModes RenderModeOverride { get; set; } = BasicRenderable.RenderModes.DontCare;

        public bool AutomaticUpdate
        {
            get { return this.m_AutoTimer.Enabled; }
            set { this.m_AutoTimer.Enabled = value; }
        }

        public int AutoFPS
        {
            get { return 1000 / this.m_AutoTimer.Interval; }
            set { this.m_AutoTimer.Interval = 1000 / value; }
        }

        public GCL3DViewport() : base()
        {
            this.Camera = new StaticCamera();

            this.m_InnerDisplay = new GLControl()
            {
                Dock = DockStyle.Fill,
            };

            this.m_AutoTimer = new Timer()
            {
                Interval = 33,
                Enabled = true
            };

            this.m_InnerDisplay.CreateControl();
            this.Controls.Add(this.m_InnerDisplay);

            OpenTK.Toolkit.Init();

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.PointSize(3);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);

            this.Scene = new GCLScene();

            this.m_AutoTimer.Tick += M_AutoTimer_Tick;
            this.Disposed += OnClosed;

            this.m_InnerDisplay.MouseDown += (o, e) => this.OnMouseDown(e);
            this.m_InnerDisplay.MouseUp += (o, e) => this.OnMouseUp(e);
            this.m_InnerDisplay.MouseClick += (o, e) => this.OnMouseClick(e);
            this.m_InnerDisplay.MouseDoubleClick += (o, e) => this.OnMouseDoubleClick(e);
            this.m_InnerDisplay.MouseWheel += (o, e) => this.OnMouseWheel(e);

            this.m_InnerDisplay.Click += (o, e) => this.OnClick(e);
            this.m_InnerDisplay.DoubleClick += (o, e) => this.OnDoubleClick(e);

            this.m_InnerDisplay.DragDrop += (o, e) => this.OnDragDrop(e);

            this.m_InnerDisplay.KeyDown += (o, e) => this.OnKeyDown(e);
            this.m_InnerDisplay.KeyUp += (o, e) => this.OnKeyUp(e);
            this.m_InnerDisplay.KeyPress += (o, e) => this.OnKeyPress(e);
        }

        private void M_AutoTimer_Tick(object sender, EventArgs e)
        {
            this.FrameRendering?.Invoke(this, new EventArgs());
            this.RenderFrame(new FrameEventArgs(this.AutoFPS));
        }

        protected override void OnResize(EventArgs e)
        {
            this.m_InnerDisplay.Width = this.Width;
            this.m_InnerDisplay.Height = this.Height;
            GL.Viewport(0, 0, this.m_InnerDisplay.Width, this.m_InnerDisplay.Height);
            CreateProjection();
        }

        private void CreateProjection()
        {
            if(this.Height > 0)
            {
                float aspectRatio = (float)(this.Width / this.Height);
                float fov = this.Camera.FieldOfView * ((float)Math.PI / 180f);

                this.Camera.ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(fov, aspectRatio, 0.001f, 4000f);
            }
        }

        public SceneObject ObjectAtViewport(Point p)
        {
            return this.FindClosestObjectHitByRay(this.ViewportToSceneCoordinates(p));
        }

        private Vector3 ViewportToSceneCoordinates(Point p)
        {
            //http://antongerdelan.net/opengl/raycasting.html
            //viwport koordináták
            float x = (2f * p.X) / Width - 1f;
            float y = 1f - (2f * p.Y) / Height;
            float z = 1f;
            Vector3 rayNormalizedDeviceCoordinates = new Vector3(x, y, z);

            //clip koordináták
            Vector4 rayClip = new Vector4(rayNormalizedDeviceCoordinates.X, rayNormalizedDeviceCoordinates.Y, -1f, 1f);

            //kamera koordináták
            Vector4 rayEye = this.Camera.ProjectionMatrix.Inverted() * rayClip;
            rayEye = new Vector4(rayEye.X, rayEye.Y, -1f, 0f);

            //világ koordináták
            Vector3 rayWorldCoordinates = (this.Camera.LookAtMatrix.Inverted() * rayEye).Xyz;
            rayWorldCoordinates.Normalize();

            return rayWorldCoordinates;
        }

        private SceneObject FindClosestObjectHitByRay(Vector3 rayWorldCoordinates)
        {
            SceneObject result = null;
            double? bestDistance = null;

            foreach (SceneObject gameObject in this.Scene.SceneObjects)
            {
                double? candidateDistance = gameObject.IntersectsRay(rayWorldCoordinates, this.Camera.Position);

                if (!candidateDistance.HasValue)
                {
                    continue;
                }

                if (!bestDistance.HasValue)
                {
                    bestDistance = candidateDistance;
                    result = gameObject;

                    continue;
                }

                if (candidateDistance < bestDistance)
                {
                    bestDistance = candidateDistance;
                    result = gameObject;
                }
            }

            return result;
        }

        protected void RenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(this.BackColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (SceneObject obj in this.Scene.SceneObjects)
            {
                obj.Render(this.Camera, this.RenderModeOverride);
            }

            this.m_InnerDisplay.SwapBuffers();
        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            this.Scene?.Dispose();
            this.m_InnerDisplay.Dispose();
        }

        #region *** TEMP ***********************************************************************

        protected override void OnLoad(EventArgs e)
        {
            this.Camera.LookAt = new Vector3(0, 0, 6f);
            this.Camera.Position = new Vector3(0, 0, 0);
        }
        #endregion
    }
}
