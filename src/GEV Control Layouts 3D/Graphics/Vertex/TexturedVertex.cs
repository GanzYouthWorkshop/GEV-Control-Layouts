using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Graphics.Vertex
{
    public struct TexturedVertex : IVertex
    {
        private readonly Vector4 m_Position;
        private readonly Vector2 m_TextureCoordinate;

        public TexturedVertex(Vector4 position, Vector2 textureCoordinate)
        {
            m_Position = position;
            m_TextureCoordinate = textureCoordinate;
        }
    }
}
