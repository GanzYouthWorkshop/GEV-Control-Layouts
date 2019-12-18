namespace GEV.Layouts.Docking
{
    partial class DockablePanelHeader
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
            this.label1 = new System.Windows.Forms.Label();
            this.gclButton1 = new GEV.Layouts.GCLButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlpFormHeader_MouseDown);
            // 
            // gclButton1
            // 
            this.gclButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(76)))), ((int)(((byte)(79)))));
            this.gclButton1.Checked = false;
            this.gclButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gclButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(65)))));
            this.gclButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(171)))));
            this.gclButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(158)))), ((int)(((byte)(202)))));
            this.gclButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gclButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gclButton1.Location = new System.Drawing.Point(207, 0);
            this.gclButton1.Margin = new System.Windows.Forms.Padding(0);
            this.gclButton1.Name = "gclButton1";
            this.gclButton1.Size = new System.Drawing.Size(16, 17);
            this.gclButton1.TabIndex = 1;
            this.gclButton1.Text = "✖";
            this.gclButton1.UseThemeColors = false;
            this.gclButton1.UseVisualStyleBackColor = false;
            this.gclButton1.Click += new System.EventHandler(this.gclButton1_Click);
            // 
            // DockablePanelHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.gclButton1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DockablePanelHeader";
            this.Size = new System.Drawing.Size(223, 17);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlpFormHeader_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GCLButton gclButton1;
        internal System.Windows.Forms.Label label1;
    }
}
