namespace GEV.Layouts
{
    partial class GCLTextbox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_InnerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_InnerTextBox
            // 
            this.m_InnerTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.m_InnerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_InnerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_InnerTextBox.Location = new System.Drawing.Point(2, 2);
            this.m_InnerTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.m_InnerTextBox.Name = "m_InnerTextBox";
            this.m_InnerTextBox.Size = new System.Drawing.Size(136, 15);
            this.m_InnerTextBox.TabIndex = 0;
            this.m_InnerTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.m_InnerTextBox.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // GCLTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.m_InnerTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GCLTextbox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(140, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_InnerTextBox;
    }
}
