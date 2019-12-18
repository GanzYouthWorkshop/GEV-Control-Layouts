using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Data
{
    public struct GCLVector2
    {
        public float X { get; }
        public float Y { get; }

        public GCLVector2(float val)
        {
            this.X = val;
            this.Y = val;
        }

        public GCLVector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator Vector2(GCLVector2 v)
        {
            return new Vector2(v.X, v.Y);
        }
    }

    public struct GCLVector3
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public GCLVector3(float val)
        {
            this.X = val;
            this.Y = val;
            this.Z = val;
        }

        public GCLVector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static implicit operator Vector3(GCLVector3 v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }
    }

    public struct GCLVector4
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public float W { get; }

        public GCLVector4(float val)
        {
            this.X = val;
            this.Y = val;
            this.Z = val;
            this.W = val;
        }

        public GCLVector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public static implicit operator Vector4(GCLVector4 v)
        {
            return new Vector4(v.X, v.Y, v.Z, v.W);
        }
    }
}
