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
    public partial class GCLTextbox : UserControl
    {
        [Browsable(true)]
        public Color BorderColor
        {
            get
            {
                return this.m_BorderColor;
            }

            set
            {
                this.m_BorderColor = value;
                base.BackColor = value;
            }
        }
        private Color m_BorderColor;

        [Browsable(true)]
        public Color ActiveBorderColor
        {
            get
            {
                return this.m_ActiveBorderColor;
            }

            set
            {
                this.m_ActiveBorderColor = value;
            }
        }
        private Color m_ActiveBorderColor;

        [Browsable(true)]
        public new Color BackColor
        {
            get
            {
                return this.m_InnerTextBox.BackColor;
            }

            set
            {
                this.m_InnerTextBox.BackColor = value;
            }
        }

        [Browsable(true)]
        public override string Text
        {
            get
            {
                return this.m_InnerTextBox.Text;
            }

            set
            {
                this.m_InnerTextBox.Text = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return this.m_InnerTextBox.ForeColor;
            }

            set
            {
                this.m_InnerTextBox.ForeColor = value;
            }
        }

        public bool UseSystemPasswordChar
        {
            get
            {
                return this.m_InnerTextBox.UseSystemPasswordChar;
            }

            set
            {
                this.m_InnerTextBox.UseSystemPasswordChar = value;
            }
        }

        public new event EventHandler TextChanged;
        public new event EventHandler Enter;

        public HorizontalAlignment TextAlign
        {
            get
            {
                return this.m_InnerTextBox.TextAlign;
            }

            set
            {

                this.m_InnerTextBox.TextAlign = value;
            }
        }

        public GCLTextbox()
        {
            InitializeComponent();

            this.ActiveBorderColor = GCLColors.AccentColor1;
            this.BorderColor = GCLColors.SoftBorder;
            this.BackColor = GCLColors.Shadow;
            this.ForeColor = GCLColors.PrimaryText;

            this.m_InnerTextBox.GotFocus += TextBox1_GotFocus;
            this.m_InnerTextBox.LostFocus += TextBox1_LostFocus;
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            base.BackColor = this.BorderColor;
        }

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            base.BackColor = this.ActiveBorderColor;
        }

        public void SelectAll()
        {
            this.m_InnerTextBox.SelectAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.TextChanged?.Invoke(this, e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.Enter?.Invoke(this, e);         
        }
    }
}
