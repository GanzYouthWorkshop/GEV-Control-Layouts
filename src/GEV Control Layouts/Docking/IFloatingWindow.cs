using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Docking
{
    public interface IFloatingWindow
    {
        void Show();
        void Hide();
        string Text { get; set; }
        bool DockOnHostOnly { get; set; }
        bool DockOnInside { get; set; }

        event EventHandler Docking;
    }
}
