using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace GEV.Layouts
{
    public partial class GCLNumericUpDown : UserControl
    {
        public event EventHandler ValueChanged;

        public decimal Value
        {
            get
            {
                return this.m_Value;
            }

            set
            {
                if (this.IsHandleCreated)
                {
                    this.gclTextbox1.Invoke(new Action(() => this.gclTextbox1.Text = value.ToString()));
                }
                this.m_Value = value;
                this.ValueChanged?.Invoke(this, null);
            }
        }
        private decimal m_Value = 0;

        public decimal Increment { get; set; } = 1;
        public decimal Minimum { get; set; } = 0;
        public decimal Maximum { get; set; } = 100;
        public int DecimalPlaces { get; set; } = 0;

        public GCLNumericUpDown()
        {
            InitializeComponent();
            this.gclTextbox1.Text = this.Value.ToString();

            this.gclTextbox1.Validating += GclTextbox1_Validating;
        }

        private void GclTextbox1_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if(!Decimal.TryParse(this.gclTextbox1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                string decimalPlaces = new string('0', this.DecimalPlaces);
                this.gclTextbox1.Invoke(new Action(() => this.gclTextbox1.Text = this.Value.ToString("0,"+decimalPlaces)));
            }
            else
            {
                if(value < this.Minimum)
                {
                    this.Value = this.Minimum;
                }
                else if(value > this.Maximum)
                {
                    this.Value = this.Maximum;
                }
                else
                {
                    this.Value = value;
                }
            }
        }

        private void gclButton1_Click(object sender, EventArgs e)
        {
            decimal newValue = this.Value - this.Increment;
            this.Value = newValue < this.Minimum ? this.Minimum : newValue;
        }

        private void gclButton2_Click(object sender, EventArgs e)
        {
            decimal newValue = this.Value + this.Increment;
            this.Value = newValue > this.Maximum ? this.Maximum : newValue;
        }

        private void gclTextbox1_Enter(object sender, EventArgs e)
        {
            this.gclTextbox1.SelectAll();
        }
    }
}
