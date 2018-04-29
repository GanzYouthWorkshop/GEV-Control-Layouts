using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.PropertyGrid
{
    public class CommandResult
    {
        public MessageBoxIcon Icon { get; set; }
        public MessageBoxButtons Buttons { get; set; }
        public string HeaderText { get; set; }
        public string Text { get; set; }
    }
}
