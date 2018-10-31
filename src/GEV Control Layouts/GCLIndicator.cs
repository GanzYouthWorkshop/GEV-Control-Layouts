using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts
{
    public class GCLIndicator : Label
    {
        public Color InactiveColor
        {
            get { return this.m_InactiveColor; }
            set { this.m_InactiveColor = value; this.Redraw(); }
        }
        private Color m_InactiveColor = GCLColors.ErrorRed;

        public Color ActiveColor
        {
            get { return this.m_ActiveColor; }
            set { this.m_ActiveColor = value; this.Redraw(); }
        }
        private Color m_ActiveColor = GCLColors.SuccessGreen;

        public object ActiveValue { get; set; } = true;

        public object CurrentValue
        {
            get
            {
                return this.m_CurrentValue;
            }
            set
            {
                if(!value.Equals(this.m_CurrentValue))
                {
                    this.m_CurrentValue = value;
                    this.Redraw();
                }
            }
        }
        private object m_CurrentValue = true;

        public GCLIndicator()
        {
            this.Size = new Size(40, 40);
            this.AutoSize = false;
            this.BackColor = this.ActiveColor;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Redraw()
        {
            if (this.m_CurrentValue.Equals(this.ActiveValue))
            {
                this.BackColor = this.ActiveColor;
            }
            else
            {
                this.BackColor = this.InactiveColor;
            }
            this.Invalidate();
        }
    }
}
