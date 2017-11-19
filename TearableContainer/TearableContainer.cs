using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public partial class TearableContainer : Panel
    {
        Button b;
        Panel p;

        public TearableContainer()
        {
            InitializeComponent();

            b = new Button();
            b.Text = "Teszt";
            b.Dock = DockStyle.Top;
            //p = new Panel();
            //p.Dock = DockStyle.Fill;
            this.Controls.Add(b);
            //this.Controls.Add(p);

            this.ControlAdded += TearableContainer_ControlAdded;

            b.Click += B_Click;
        }

        private void B_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            Form f = new Form();
            foreach(Control c in this.Controls)
            {
                if (c != b)
                {
                    f.Controls.Add(c);
                }
            }
            f.Show();
        }

        private void TearableContainer_ControlAdded(object sender, ControlEventArgs e)
        {
            //this.Controls.Remove(this.b);
            e.Control.Dock = DockStyle.Fill;
            //this.Controls.Add(this.b);
        }
    }
}
