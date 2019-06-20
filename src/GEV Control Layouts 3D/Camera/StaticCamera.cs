using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace GEV.Layouts.D3.Camera
{
    public class StaticCamera : ICamera
    {
        public float FieldOfView { get; set; } = 45;
        public Matrix4 LookAtMatrix { get; set; }
        public Matrix4 ProjectionMatrix { get; set; }

        public Vector3 LookAt { get; set; }

        public Vector3 Position
        {
            get { return this.m_Position; }
            set { this.m_Position = value; this.LookAtMatrix = Matrix4.LookAt(this.m_Position, this.LookAt, Vector3.UnitY); }
        }
        private Vector3 m_Position;


        public StaticCamera()
        {
            this.LookAt = new Vector3(0, 0, 0);
            this.Position = new Vector3(0, 0, 0);

        }

        public StaticCamera(Vector3 position, Vector3 target)
        {
            this.LookAt = target;
            this.Position = position;
        }

        public void Move(float dx, float dy, float dz, bool lookat = true)
        {
            if(lookat)
            {
                this.LookAt += new Vector3(dx, dy, dz);
            }

            this.Position += new Vector3(dx, dy, dz);
        }

        public void Orbit(float dx, float dy, float dz)
        {
        }

        public void Rotate(float dx, float dy, float dz)
        {
        }
    }
}
