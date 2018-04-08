using GEV.Layouts.Extended.MiniCAD.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Components
{
    public class SnapPoint : IDrawable
    {
        public enum Roles
        {
            CornerPoint,
            MidPoint,
            WeightPoint,

            Connector,
            GroupConnector
        }

        public enum Symbols
        {
            Rectangle,
            Circle,
            Triangle
        }

        public PointF Position { get; set; }
        public string Name { get; set; }
        public IEditableComponent Owner { get; set; }

        public Color Color { get; set; }
        public Symbols Symbol { get; set; }
        public List<SnapPoint> Bindings { get; } = new List<SnapPoint>();
        public bool EnableMultipleBinding { get; }

        public SnapPoint(IEditableComponent owner, string name, PointF position, Roles role)
        {
            this.Owner = owner;
            this.Name = name;
            this.Position = position;

            switch (role)
            {
                case Roles.CornerPoint:
                    this.Color = GCLColors.AccentColor1;
                    this.Symbol = Symbols.Rectangle;
                    break;
                case Roles.WeightPoint:
                    this.Color = Color.Orange;
                    this.Symbol = Symbols.Circle;
                    break;
            }
        }

        public void Draw(Graphics g, RectangleF viewport, float zoom)
        {
            using (Brush b = new SolidBrush(this.Color))
            {
                PointF p = GeometryUtils.MapInnerToScreen(this.Position, viewport, zoom);
                RectangleF r = new RectangleF(p.X - 5, p.Y - 5, 10, 10);

                switch (this.Symbol)
                {
                    case Symbols.Rectangle:
                        g.FillRectangle(b, r);
                        break;
                    case Symbols.Circle:
                        g.FillEllipse(b, r);
                        break;
                }
            }
        }
    }
}
