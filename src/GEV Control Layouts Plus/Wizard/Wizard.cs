using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tesztek
{
    public partial class Wizard : UserControl
    {
        public Wizard()
        {
            InitializeComponent();

            this.tabsMain.TabPages.Remove(this.tabPage1);
            this.tabsMain.SelectedTab = this.tabsMain.TabPages[0];
        }

        public void SetupTaskList()
        {
            foreach(TabPage tab in this.tabsMain.TabPages)
            {
                this.lbxTasks.Items.Add(tab.Text);
            }

            this.lbxTasks.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.tabsMain.SelectedIndex > 0)
            {
                TabPage next = this.tabsMain.TabPages[this.tabsMain.SelectedIndex - 1];

                if(this.BackClicked())
                {
                    this.tabsMain.SelectedIndex--;
                    this.btnBack.Enabled = this.tabsMain.SelectedIndex > 0;
                }
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.btnBack.Enabled = true;

            if(this.NextClicked())
            {
                if (this.tabsMain.SelectedIndex < this.tabsMain.TabPages.Count - 1)
                {
                    this.tabsMain.SelectedIndex++;
                }
            }
        }

        protected virtual bool BackClicked()
        {
            return true;
        }
        protected virtual bool NextClicked()
        {
            return true;
        }

        private void tabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                try
                {
                    this.lbxTasks.SelectedIndex = this.tabsMain.SelectedIndex;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void Wizard_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                this.tabsMain.ItemSize = new Size(0, 1);
                this.tabsMain.SizeMode = TabSizeMode.Fixed;
            }

            this.SetupTaskList();
        }

        private void lbxTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            Color c = this.lbxTasks.SelectedIndex == e.Index ? SystemColors.ActiveCaption : SystemColors.Control;

            using (Brush bg = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(bg, e.Bounds);
                e.Graphics.DrawString(this.lbxTasks.Items[e.Index].ToString(), this.lbxTasks.Font, Brushes.Black, e.Bounds);
            }
        }
    }
}
