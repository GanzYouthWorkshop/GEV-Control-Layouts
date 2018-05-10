using GEV.Layouts;
using GEV.Layouts.Extended.MiniCAD.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class LightColors : GCLForm
    {
        public LightColors()
        {
            InitializeComponent();

            this.gclPropertyGrid1.DataSource = new SimpleDataStructure();
            this.gclPropertyGrid2.DataSource = this;

            this.miniCADEditor1.Document = new GEV.Layouts.Extended.MiniCAD.Implementation.Document();
            this.miniCADEditor1.Document.Layers.Add(new GridLayer() { GridSize = 1, GridColor = Color.CadetBlue, MinimumZoomLevel = 5 });
            this.miniCADEditor1.Document.Layers.Add(new GridLayer() { GridSize = 5, GridColor = Color.Aqua });
            this.miniCADEditor1.Document.Layers.Add(new ComponentLayer());
        }

        private void gclButton1_Click(object sender, EventArgs e)
        {
            Color c = GCLColors.AlertYellow;
        }
    }
}
