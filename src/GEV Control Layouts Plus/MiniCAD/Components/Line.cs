using GEV.Layouts.Extended.MiniCAD.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MiniCAD.Components
{
    public class Line : IEditableComponent
    {
        public RectangleF BoundingBox
        {
            get
            {
                float x = Math.Min(this.Start.X, this.End.X);
                float y = Math.Min(this.Start.Y, this.End.Y);
                float w = Math.Abs(this.Start.X - this.End.X);
                float h = Math.Abs(this.Start.Y - this.End.Y);
                return new RectangleF(x, y, w, h);
            }
        }

        public PointF Start { get; set; }
        public PointF End { get; set; }

        public PointF Position { get; set; }
        public List<SnapPoint> SnapPoints { get; } = new List<SnapPoint>();
        public bool Selected { get; set; }

        public bool IsEdited { get; set; } = false;
        public int EditState { get; set; } = 0;

        public Line(bool editMode = false)
        {
            if(editMode)
            {
                this.IsEdited = true;
                this.EditState = 0;
            }
            this.SnapPoints.Add(new SnapPoint(this, "Start", new PointF(0, 0), SnapPoint.Roles.CornerPoint));
            this.SnapPoints.Add(new SnapPoint(this, "End", new PointF(5, 5), SnapPoint.Roles.CornerPoint));
        }
        public event EventHandler MouseDown;
        public event EventHandler MouseUp;
        public event EventHandler Click;
        public event EventHandler MouseMove;

        public void Draw(Graphics g, RectangleF viewport, float zoom)
        {
            PointF startScr = GeometryUtils.MapInnerToScreen(Start, viewport, zoom);
            PointF endScr = GeometryUtils.MapInnerToScreen(End, viewport, zoom);
            g.DrawLine(Pens.LightGreen, startScr, endScr);
        }

        public void Clicked()
        {
            this.Click?.Invoke(this, null);
        }

        public void MousePressedDown()
        {
            this.MouseDown?.Invoke(this, null);
        }

        public void MousePressedUp()
        {
            this.MouseUp?.Invoke(this, null);
        }

        public void MouseMoved()
        {
            this.MouseMove?.Invoke(this, null);
        }
    }
}
