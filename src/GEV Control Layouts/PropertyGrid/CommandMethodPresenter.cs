using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using GEV.Layouts.Meta;

namespace GEV.Layouts.PropertyGrid
{
    [ToolboxItem(false)]
    internal partial class CommandMethodPresenter : ElementPresenter
    {
        public MethodInfo Method
        {
            get
            {
                return (MethodInfo)this.ReflectionInfo;
            }

            set
            {
                this.ReflectionInfo = value;
            }
        }

        public CommandMethodPresenter()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public override void BuildGUI()
        {
            this.lblName.Text = PropertyGridUtils.GetLocalizedName(this.Method);
            this.gclButton1.Text = PropertyGridUtils.GetLocalizedCommandName(this.Method);
        }

        public override void ForceValidate()
        {
        }

        private void gclButton1_Click(object sender, EventArgs e)
        {
            try
            {
                object result =  this.Method.Invoke(this.DataSource, null);

                if(result != null && this.Method.GetCustomAttribute<GCLCommandAttribute>(true).ShowResultInMessageBox)
                {
                    if (result is CommandResult)
                    {
                        CommandResult cr = (CommandResult)result;
                        MessageBox.Show(cr.Text, cr.HeaderText, cr.Buttons, cr.Icon, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show(result.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Masszív elbaszás folyamatban! - {0}", ex.Message);
            }
        }
    }
}
