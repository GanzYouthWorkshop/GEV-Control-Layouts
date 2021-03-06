﻿using GEV.Layouts.Extended.MiniCAD.Components;
using GEV.Layouts.Extended.MiniCAD.Layers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Extended.MiniCAD.Implementation
{
    internal class MiniCADCanvas : Control
    {
        public PointF ViewportPosition { get; set; } = new PointF(0,0);
        public SizeF ViewPortSize { get; private set; } = new SizeF(0, 0);

        public float Zoom
        {
            get { return this.m_Zoom; }
            set { this.m_Zoom = value; this.CalculateViewport(); }
        }
        private float m_Zoom = 1;

        public RectangleF Viewport
        {
            get
            {
                return new RectangleF(this.ViewportPosition, this.ViewPortSize);
            }
        }

        public PointF CursorPosition { get; set; }

        public Document Document { get; set; }

        public SnapPoint SnapPointUnderCursor { get; private set; }

        public MiniCADCanvas()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            this.Resize += MiniCADCanvas_Resize;
            this.MouseMove += MiniCADCanvas_MouseMove;
            this.MouseDown += MiniCADCanvas_MouseDown;
            this.MouseUp += MiniCADCanvas_MouseUp;
            this.Click += MiniCADCanvas_Click;
        }

        private void MiniCADCanvas_Click(object sender, EventArgs e)
        {
            IComponent clicked = this.SearchComponent(this.CursorPosition);

            if(clicked is IEditableComponent)
            {
                (clicked as IEditableComponent).Clicked();
            }
        }

        private void MiniCADCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            IComponent clicked = this.SearchComponent(this.CursorPosition);

            if (clicked is IEditableComponent)
            {
                (clicked as IEditableComponent).MousePressedUp();
            }
        }

        private void MiniCADCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            IComponent clicked = this.SearchComponent(this.CursorPosition);

            if (clicked is IEditableComponent)
            {
                (clicked as IEditableComponent).MousePressedDown();
            }
        }

        private void MiniCADCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            SnapPoint sp = this.SearchSnapPoint(e.Location);
           
            if(sp != null)
            {
                this.CursorPosition = sp.AbsolutePosition;
            }
            else
            {
                this.CursorPosition = GeometryUtils.MapScreenToInner(e.Location, this.Viewport, this.Zoom);
            }

            if (this.SnapPointUnderCursor != sp)
            {
                this.Invalidate();
            }

            this.SnapPointUnderCursor = sp;


            IComponent clicked = this.SearchComponent(this.CursorPosition);

            if (clicked is IEditableComponent)
            {
                (clicked as IEditableComponent).MouseMoved();
            }
        }

        private void MiniCADCanvas_Resize(object sender, EventArgs e)
        {
            this.CalculateViewport();
        }

        public void CalculateViewport()
        {
            Size s = this.Size;
            PointF end = GeometryUtils.MapScreenToInner(new Point(s.Width - 1, s.Height - 1), this.Viewport, this.Zoom);

            this.ViewPortSize = new SizeF(end.X - this.Viewport.X, end.Y - this.Viewport.Y);
        }

        private SnapPoint SearchSnapPoint(PointF location)
        {
            foreach (ILayer layer in this.Document.Layers)
            {
                if(layer is ComponentLayer)
                {
                    ComponentLayer clayer = layer as ComponentLayer;
                    foreach (IComponent component in clayer.Components)
                    {
                        if(component is IEditableComponent)
                        {
                            IEditableComponent ecomponent = component as IEditableComponent;
                            foreach(SnapPoint sp in ecomponent.SnapPoints)
                            {
                                PointF p = GeometryUtils.MapInnerToScreen(sp.AbsolutePosition, this.Viewport, this.Zoom);

                                if(GeometryUtils.PointDistance(p, location) <= 7)
                                {
                                    return sp;
                                }
                            }
                        }
                    }
                }
            }

            foreach (ILayer layer in this.Document.Layers)
            {
                if (layer is GridLayer)
                {
                    GridLayer glayer = layer as GridLayer;
                    foreach (SnapPoint sp in glayer.SnapPoints)
                    {
                        PointF p = GeometryUtils.MapInnerToScreen(sp.RelativePosition, this.Viewport, this.Zoom);

                        if (GeometryUtils.PointDistance(p, location) <= 7)
                        {
                            return sp;
                        }
                    }
                }
            }
            return null;
        }

        private IComponent SearchComponent(PointF location)
        {
            foreach (ILayer layer in this.Document.Layers)
            {
                if (layer is ComponentLayer)
                {
                    ComponentLayer clayer = layer as ComponentLayer;
                    foreach (IComponent component in clayer.Components)
                    {
                        if (GeometryUtils.IsPontInBoundingBox(location, component.BoundingBox))
                        {
                            return component;
                        }
                    }
                }
            }

            return null;
        }

        public void Draw()
        {
            using (Graphics g = this.CreateGraphics())
            {
                this.OnPaint(new PaintEventArgs(g, this.Bounds));
            }
        }

        public void Draw(ILayer layer)
        {
            using (Graphics g = this.CreateGraphics())
            {
                layer.Draw(g, this.Viewport, this.Zoom);
            }
        }

        public void Draw(IComponent component)
        {
            using (Graphics g = this.CreateGraphics())
            {
                foreach (ILayer layer in this.Document.Layers)
                {
                    if(layer is ComponentLayer && (layer as ComponentLayer).Components.Contains(component))
                    {
                        if (GeometryUtils.IsBoundingBoxInViewport(this.Viewport, component.BoundingBox))
                        {
                            component.Draw(g, this.Viewport, this.Zoom);
                        }
                        return;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(this.Document != null)
            {
                foreach (ILayer layer in this.Document.Layers)
                {
                    layer.Draw(e.Graphics, this.Viewport, this.Zoom);
                }
            }

            if(this.SnapPointUnderCursor != null)
            {
                this.SnapPointUnderCursor.Draw(e.Graphics, this.Viewport, this.Zoom);
            }
        }
    }
}
