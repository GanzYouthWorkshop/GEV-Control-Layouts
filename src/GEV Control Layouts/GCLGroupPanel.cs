using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    //TODO: Add theming
    public class GCLGroupPanel : GCLPanel
    {
        public string Title
        {
            get { return this.m_Label.Text; }
            set { this.m_Label.Text = value; }
        }

        private Label m_Label = new Label()
        {
            Text = "GroupPanel"
        };

        public GCLGroupPanel()
        {
            this.m_Label.Dock = DockStyle.Top;

            this.Controls.Add(new Panel
            {
                Dock = DockStyle.Top,
                Height = 2,
                BackColor = GCLColors.SoftBorder,
            });
            this.Controls.Add(this.m_Label);
        }
    }
}
