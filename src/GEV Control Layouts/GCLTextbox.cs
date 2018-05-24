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
    public partial class GCLTextbox : UserControl, IGCLControl
    {
        public new event EventHandler TextChanged;
        public new event EventHandler Enter;
        public new event KeyPressEventHandler KeyPress;
        public new event KeyEventHandler KeyDown;
        public new event KeyEventHandler KeyUp;
        public new event EventHandler LostFocus;

        private bool m_Selected = false;

        public Color BorderColor { get; set; }
        public Color ActiveBorderColor { get; set; }
        public new Color BackColor { get; set; }
        public bool UseThemeColors { get; set; } = true;

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
            this.m_InnerTextBox.KeyPress += M_InnerTextBox_KeyPress;
            this.m_InnerTextBox.KeyDown += M_InnerTextBox_KeyDown;
            this.m_InnerTextBox.KeyUp += M_InnerTextBox_KeyUp;
        }

        private void M_InnerTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.KeyUp?.Invoke(this, e);
        }

        private void M_InnerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.KeyDown?.Invoke(this, e);
        }

        private void M_InnerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.KeyPress?.Invoke(this, e);
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            m_Selected = false;
            this.Invalidate();
            this.LostFocus?.Invoke(this, e);
        }

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            m_Selected = true;
            this.Invalidate();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            Color back = this.UseThemeColors ? GCLColors.Shadow : this.BackColor;
            Color border;
            if(this.UseThemeColors)
            {
                border = this.m_Selected ? GCLColors.AccentColor1 : GCLColors.SoftBorder;
            }
            else
            {
                border = this.m_Selected ? this.ActiveBorderColor : this.BorderColor;
            }
            Color fore = this.UseThemeColors ? GCLColors.PrimaryText : this.ForeColor;

            base.BackColor = border;
            this.m_InnerTextBox.BackColor = back;
            this.m_InnerTextBox.ForeColor = fore;
            base.OnPaint(e);
        }

        public new bool Focus()
        {
            m_Selected = true;
            bool result = this.m_InnerTextBox.Focus();
            return result;
        }
    }
}
