using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    internal class GCLMenuStripColors : ProfessionalColorTable
    {
        internal static Color MainColor;

        static GCLMenuStripColors()
        {
            MainColor = Color.FromArgb(51, 51, 51);
        }

        public override Color ToolStripDropDownBackground
        {
            get { return MainColor; }
        }

        public override Color ToolStripContentPanelGradientBegin
        {
            get { return MainColor; }
        }

        public override Color ToolStripContentPanelGradientEnd
        {
            get { return MainColor; }
        }

        public override Color MenuItemSelected
        {
            get { return MainColor; }
        }

        public override Color MenuItemBorder
        {
            get { return MainColor; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return MainColor; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return MainColor; }
        }

        public override Color MenuBorder
        {
            get { return MainColor; }
        }
    }

}
