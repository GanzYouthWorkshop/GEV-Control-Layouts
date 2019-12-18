using GEV.Layouts.Extended.MiniCAD.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GEV.Layouts.Extended.MiniCAD.Implementation;

namespace WindowsFormsApplication3.MiniCadComponent
{
    public class FunctionalBox : ContainerComponent, IEditableComponent
    {
        public override RectangleF BoundingBox { get; }

        public int EditState { get; set; } = 0;
        public bool IsEdited { get; set; } = false;

        public bool Selected { get; set; } = false;

        public List<SnapPoint> SnapPoints { get; } = new List<SnapPoint>();

        public FunctionalBox()
        {
            this.SnapPoints.Add(new SnapPoint(this, "Center", new PointF(40, 50), SnapPoint.Roles.WeightPoint));
        }

        public event EventHandler Click;
        public event EventHandler MouseDown;
        public event EventHandler MouseUp;
        public event EventHandler MouseMove;

        public override void Draw(Graphics g, RectangleF viewport, float zoom)
        {
            PointF pos = new PointF(20, 20);
            SizeF size = new SizeF(40, 60);

            PointF posScr = GeometryUtils.MapInnerToScreen(pos, viewport, zoom);
            SizeF sizeScr = GeometryUtils.MapInnerToScreen(size, viewport, zoom);
            g.FillRectangle(Brushes.BlueViolet, new RectangleF(posScr, sizeScr));
        }

        public void Clicked()
        {
            throw new NotImplementedException();
        }

        public void MousePressedDown()
        {
            throw new NotImplementedException();
        }

        public void MousePressedUp()
        {
            throw new NotImplementedException();
        }

        public void MouseMoved()
        {
            throw new NotImplementedException();
        }
    }
}
