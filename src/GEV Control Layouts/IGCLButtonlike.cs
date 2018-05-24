using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public interface IGCLButtonlike : IGCLControl
    {
        Color BackColor { get; set; }
        Color ForeColor { get; set; }
        FlatButtonAppearance FlatAppearance { get; }
        Size Size { get; set; }
        Font Font { get; set; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        string Text { get; set; }
        bool Checked { get; set; }
        Image Image { get; set; }
        ImageList ImageList { get; set; }
        int ImageIndex { get; set; }
        string ImageKey { get; set; }
        ContentAlignment ImageAlign { get; set; }
        Padding Padding { get; set; }
        ContentAlignment TextAlign { get; set; }


        bool IsHovered { get; }
        bool IsPressed { get; }
    }
}
