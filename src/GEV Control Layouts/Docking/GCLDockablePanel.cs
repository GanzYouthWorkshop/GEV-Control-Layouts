using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Docking
{
    public class GCLDockablePanel : GCLPanel
    {
        internal DockablePanelHeader Header { get; } = new DockablePanelHeader()
        {
            Dock = DockStyle.Top
        };

        internal Panel ControlContainer { get; } = new Panel()
        {
            Dock = DockStyle.Fill
        };

        public string Title
        {
            get { return this.Header.label1.Text; }
            set { this.Header.label1.Text = value; }
        }

        public GCLDockablePanel()
        {
            this.Padding = new Padding(1);
            this.Controls.Add(this.Header);
            //this.Controls.Add(this.ControlContainer);

            this.ControlAdded += GCLDockablePanel_ControlAdded;
        }

        private void GCLDockablePanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if(e.Control != this.Header)
            {
                this.Controls.Remove(this.Header);
                this.Controls.Add(this.Header);
            }
        }
    }
}
