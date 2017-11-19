using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    internal class GCLMenuStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

            if (e.Item.Selected)
            {
                Color color = Color.FromArgb(57, 174, 169);
                using (SolidBrush brush = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else if(e.Item.OwnerItem == null && !e.Item.Pressed)
            {
                using (SolidBrush brush = new SolidBrush(GCLMenuStripColors.MainColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.SlateGray))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            //base.OnRenderImageMargin(e);
            using (SolidBrush brush = new SolidBrush(GCLMenuStripColors.MainColor))
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.Item.ForeColor = Color.White;
            e.Text = e.Text.ToUpper();
            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Color c = e.BackColor == Color.FromArgb(39, 54, 59) ? Color.FromArgb(39, 54, 59) : Color.SlateGray;

            using (Brush b = new SolidBrush(c))
            using (Pen p = new Pen(b))
            {
                e.Graphics.DrawRectangle(p, e.AffectedBounds);
            }
            //base.OnRenderToolStripBorder(e);
        }

        public GCLMenuStripRenderer() : base(new GCLMenuStripColors())
        {
        }
    }

}
