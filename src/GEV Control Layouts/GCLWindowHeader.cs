﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public partial class GCLWindowHeader : UserControl
    {
        public GCLWindowHeader()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return this.m_Title; }
            set { this.label1.Text = this.m_Title = value; }
        }
        private string m_Title = "Window";

        public bool ShowWindowButtons
        {
            get { return this.m_ShowWindowButtons; }
            set
            {
                this.m_ShowWindowButtons = value;
                this.btnMinimize.Visible = value;
                this.btnMaximize.Visible = value;
            }
        }
        private bool m_ShowWindowButtons = true;

        public bool ShowCloseButton
        {
            get { return this.m_ShowCloseButton; }
            set
            {
                this.m_ShowCloseButton = value;
                this.btnClose.Visible = value;
            }
        }
        private bool m_ShowCloseButton = true;


        #region Window controls
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnMaximizeWindow_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                if(this.ParentForm is GCLForm)
                {
                    GCLForm form = (GCLForm)this.ParentForm;
                    Screen screen = Screen.FromControl(this);
                    int x = screen.WorkingArea.X - screen.Bounds.X;
                    int y = screen.WorkingArea.Y - screen.Bounds.Y;

                    if (form.HideStartMenuOnMaximize)
                    {
                        form.SetMaximizeBounds(new Rectangle(0, 0, screen.Bounds.Width, screen.Bounds.Height));
                    }
                    else
                    {
                        form.SetMaximizeBounds(new Rectangle(x, y, screen.WorkingArea.Width, screen.WorkingArea.Height));
                    }
                }
                this.ParentForm.WindowState = this.ParentForm.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            }
        }

        private void btnMinimizeWindow_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void tlpFormHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ParentForm != null && e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void tableLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.WindowState = this.ParentForm.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            }
        }
    }
}
