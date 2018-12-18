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
        List<TestDataStructure> test;

        public LightColors()
        {
            InitializeComponent();

            this.gclPropertyGrid1.DataSource = new SimpleDataStructure();
            this.gclPropertyGrid2.DataSource = this;

            this.miniCADEditor1.Document = new GEV.Layouts.Extended.MiniCAD.Implementation.Document();
            this.miniCADEditor1.Document.Layers.Add(new GridLayer() { GridSize = 1, GridColor = Color.CadetBlue, MinimumZoomLevel = 5 });
            this.miniCADEditor1.Document.Layers.Add(new GridLayer() { GridSize = 5, GridColor = Color.Aqua });
            this.miniCADEditor1.Document.Layers.Add(new ComponentLayer());

            test = new List<TestDataStructure>()
            {
                new TestDataStructure() { One = 1, Four = "LOLOLOLO" },
                new TestDataStructure() { One = 2, Four = "TEST" },
                new TestDataStructure() { One = 3 },
                new TestDataStructure() { One = 4 },
                new TestDataStructure() { One = 5 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 1, Four = "ROFL" },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 8 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
            };

            this.vanillaCheckedDataGrid1.UserDataPersistence = GEV.Layouts.Vanilla.VanillaDataGrid.PersistenceCheckTypes.ByKey;
            this.vanillaCheckedDataGrid1.PersistenceKeys = new List<string>() { "One", "Four" };

            this.vanillaCheckedDataGrid1.DataSource = test;

        }

        private void gclButton1_Click(object sender, EventArgs e)
        {
            Color c = GCLColors.AlertYellow;
        }

        private void gclPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gclButton2_Click(object sender, EventArgs e)
        {
            List<TestDataStructure> test2 = new List<TestDataStructure>();
            test2.AddRange(this.test);

            test2 = new List<TestDataStructure>()
            {
                new TestDataStructure() { One = 1, Four = "OLO" },
                new TestDataStructure() { One = 2, Four = "TEST" },
                new TestDataStructure() { One = 3 },
                new TestDataStructure() { One = 4 },
                new TestDataStructure() { One = 5 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 1, Four = "ROFL" },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 8 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
                new TestDataStructure() { One = 6 },
            };
            this.vanillaCheckedDataGrid1.DataSource = test2;

            this.test = test2;
        }
    }
}
