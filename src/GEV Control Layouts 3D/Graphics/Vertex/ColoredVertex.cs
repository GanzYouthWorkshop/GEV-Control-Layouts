using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Graphics.Vertex
{
    public struct ColoredVertex : IVertex
    {
        private readonly Vector4 m_Position;
        private readonly Color4 m_Color;

        public ColoredVertex(Vector4 position, Color4 color)
        {
            m_Position = position;
            m_Color = color;
        }
    }
}
