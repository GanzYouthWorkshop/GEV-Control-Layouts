using System;
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
    public partial class GCLLineMonitor : UserControl
    {
        private int m_Value;
        public int Value
        {
            get { return this.m_Value; }
            set
            {
                this.m_Value = value;
                this.gclProgressBar1.Value = value;
                this.gclProgressBar1.Invalidate();
                this.SetText();
            }
        }

        private int m_MaxValue;
        public int MaxValue
        {
            get { return this.m_MaxValue; }
            set
            {
                this.m_MaxValue = value;
                this.gclProgressBar1.MaxValue = value;
                this.gclProgressBar1.Invalidate();
                this.SetText();
            }
        }

        private string m_Title;
        public string Title
        {
            get { return this.m_Title; }
            set
            {
                this.m_Title = value;
                this.lblName.Text = value;
            }
        }

        private string m_Format;
        public string Format
        {
            get { return this.m_Format; }
            set
            {
                this.m_Format = value;
                this.SetText();
            }
        }

        private Color m_ActiveColor;
        public Color ActiveColor
        {
            get { return this.m_ActiveColor; }
            set
            {
                this.m_ActiveColor = value;
                this.gclProgressBar1.ActiveColor = value;
            }
        }

        public GCLLineMonitor()
        {
            InitializeComponent();
            this.ActiveColor = GCLColors.AccentColor1;
        }

        private void SetText()
        {
            if(this.IsHandleCreated)
            {
                this.Invoke(new Action(() => this.lblFormattedInfo.Text = String.Format(this.Format, this.Value, this.MaxValue)));
            }
        }
    }
}
