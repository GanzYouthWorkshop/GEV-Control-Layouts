using GEV.Layouts.D3.Camera;
using GEV.Layouts.D3.Graphics.Renderable;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Data
{
    public class SceneObject
    {
        public BasicRenderable Model { get; set; }
        public GCLVector4 Position { get; set; }
        public GCLVector4 Direction { get; set; }
        public GCLVector4 Rotation { get; set; }
        public GCLVector3 Scale { get; set; }
        public float Velocity { get; set; }

        public SceneObject(BasicRenderable renderable, GCLVector4 position, GCLVector4 direction, GCLVector4 rotation, GCLVector3 scale, float velocity)
        {
            this.Model = renderable;
            this.Position = position;
            this.Direction = direction;
            this.Rotation = rotation;
            this.Velocity = velocity;
            this.Scale = scale;
        }

        public virtual void Render(ICamera camera, BasicRenderable.RenderModes renderModeOverride)
        {
            this.Model.Bind();

            if (renderModeOverride != BasicRenderable.RenderModes.DontCare)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, (PolygonMode)renderModeOverride);
            }

            Matrix4 proj = camera.ProjectionMatrix;
            GL.UniformMatrix4(20, false, ref proj);


            Matrix4 t2 = Matrix4.CreateTranslation(this.Position.X, this.Position.Y, this.Position.Z);
            Matrix4 r1 = Matrix4.CreateRotationX(this.Rotation.X);
            Matrix4 r2 = Matrix4.CreateRotationY(this.Rotation.Y);
            Matrix4 r3 = Matrix4.CreateRotationZ(this.Rotation.Z);
            Matrix4 s = Matrix4.CreateScale(this.Scale);

            Matrix4 modelView = r1 * r2 * r3 * s * t2 * camera.LookAtMatrix;
            GL.UniformMatrix4(21, false, ref modelView);

            this.Model.Render();
        }

        public double? IntersectsRay(Vector3 rayDirection, Vector3 rayOrigin)
        {
            float radius = this.Scale.X;
            Vector3 difference = ((Vector4)Position).Xyz - rayDirection;
            float differenceLengthSquared = difference.LengthSquared;
            float sphereRadiusSquared = radius * radius;
            if (differenceLengthSquared < sphereRadiusSquared)
            {
                return 0d;
            }

            float distanceAlongRay = Vector3.Dot(rayDirection, difference);
            if (distanceAlongRay < 0)
            {
                return null;
            }

            float dist = sphereRadiusSquared + distanceAlongRay * distanceAlongRay - differenceLengthSquared;
            double? result = (dist < 0) ? null : distanceAlongRay - (double?)Math.Sqrt(dist);

            return result;
        }

    }
}
