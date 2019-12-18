using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Camera
{
    public interface ICamera
    {
        float FieldOfView { get; set; }
        Vector3 Position { get; set; }
        Vector3 LookAt { get; set; }

        Matrix4 LookAtMatrix { get; set; }
        Matrix4 ProjectionMatrix { get; set; }

        void Move(float dx, float dy, float dz, bool lookat = true);
    }
}
