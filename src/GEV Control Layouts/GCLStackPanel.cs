using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLStackPanel : Panel
    {
        public GCLStackPanel()
        {
            this.BackColor = GCLColors.Shadow;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }
    }
}
