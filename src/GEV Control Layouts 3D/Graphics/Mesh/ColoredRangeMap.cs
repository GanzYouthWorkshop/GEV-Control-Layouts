using GEV.Layouts.D3.Graphics.Vertex;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.D3.Graphics.Mesh
{
    public class ColoredRangeMap : BasicMesh<ColoredVertex>
    {
        public ColoredRangeMap(string file)
        {
            this.Composition = CompositionModes.TriangleStrip;

            using (Bitmap map = new Bitmap(file))
            {
                BitmapData mapdata = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadOnly, map.PixelFormat);

                int bpp = mapdata.Stride / map.Width;
                int bufferSize = mapdata.Stride * map.Width;
                byte[] buffer = new byte[bufferSize];

                Marshal.Copy(mapdata.Scan0, buffer, 0, bufferSize);

                float[,] rangemap = new float[map.Width, map.Height];

                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Width; x++)
                    {
                        byte[] unit = new byte[bpp];
                        int bufferStart = (y * mapdata.Stride) + x * bpp;

                        rangemap[x, y] = (float)buffer[bufferStart] / 100f;
                    }
                }

                Color4 c = new Color4(0.1f, 0.9f, 0.3f, 1.0f);
                List<ColoredVertex> vertices = new List<ColoredVertex>();


                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Width; x++)
                    {
                        if (x < map.Width - 1 && y < map.Height - 1)
                        {
                            c = new Color4(rangemap[x, y], 0.9f, 0.3f, 1.0f);

                            vertices.Add(new ColoredVertex(new OpenTK.Vector4(x, y, rangemap[x, y] * 10, 1), c));
                            vertices.Add(new ColoredVertex(new OpenTK.Vector4(x, y + 1, rangemap[x, y + 1] * 10, 1), c));
                            vertices.Add(new ColoredVertex(new OpenTK.Vector4(x + 1, y + 1, rangemap[x + 1, y + 1] * 10, 1), c));

                            vertices.Add(new ColoredVertex(new OpenTK.Vector4(x, y, rangemap[x, y] * 10, 1), c));
                            vertices.Add(new ColoredVertex(new OpenTK.Vector4(x + 1, y, rangemap[x + 1, y] * 10, 1), c));
                            vertices.Add(new ColoredVertex(new OpenTK.Vector4(x + 1, y + 1, rangemap[x + 1, y + 1] * 10, 1), c));
                        }
                    }
                }

                this.Vertices = vertices.ToArray();
            }
        }
    }
}
