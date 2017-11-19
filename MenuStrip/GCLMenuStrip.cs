using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLMenuStrip : MenuStrip
    {
        public GCLMenuStrip() : base()
        {
            this.Renderer = new GCLMenuStripRenderer();
            //this.RenderMode = ToolStripRenderMode.Custom;
            this.BackColor = Color.FromArgb(52, 73, 94);
            this.ForeColor = Color.White;
        }
    }
}
