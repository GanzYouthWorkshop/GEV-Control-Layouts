using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GEV.Layouts.Docking
{
    [Browsable(false)]
    internal partial class DockablePanelHeader : UserControl
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public bool OwnerIsFloating { get; internal set; } = false;

        public DockablePanelHeader()
        {
            InitializeComponent();
        }

        private void tlpFormHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ParentForm != null && e.Button == MouseButtons.Left && this.OwnerIsFloating)
            {
                ReleaseCapture();
                if(this.ParentForm is FloatingWindow)
                {
                    ((FloatingWindow)this.ParentForm).PerformOnMove();
                }
                SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void gclButton1_Click(object sender, EventArgs e)
        {
            if (this.OwnerIsFloating)
            {
                this.ParentForm.Close();
            }
            else
            {
                this.Parent.Hide();
            }
        }
    }
}
