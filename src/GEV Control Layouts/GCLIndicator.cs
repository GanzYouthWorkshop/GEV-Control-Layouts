using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLIndicator : Panel
    {
        public Color InactiveColor { get; set; } = GCLColors.SuccessGreen;
        public Color ActiveColor { get; set; } = GCLColors.ErrorRed;

        public object ActiveValue { get; set; } = true;

        public object CurrentValue
        {
            get
            {
                return this.m_CurrentValue;
            }
            set
            {
                this.m_CurrentValue = value;
                if(this.m_CurrentValue.Equals(this.ActiveValue))
                {
                    this.BackColor = this.ActiveColor;
                }
                else
                {
                    this.BackColor = this.InactiveColor;
                }
            }
        }
        private object m_CurrentValue = true;

        public GCLIndicator()
        {
            this.BackColor = this.ActiveColor;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
