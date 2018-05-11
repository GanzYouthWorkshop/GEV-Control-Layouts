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

        public string Title
        {
            get { return this.Header.label1.Text; }
            set { this.Header.label1.Text = value; }
        }

        public GCLDockablePanel()
        {
            this.Padding = new Padding(1);
            this.Controls.Add(this.Header);
        }
    }
}
