namespace GEV.Layouts.Docking
{
    partial class FloatingWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gclWindowGrab1 = new GEV.Layouts.GCLWindowGrab();
            this.SuspendLayout();
            // 
            // gclWindowGrab1
            // 
            this.gclWindowGrab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gclWindowGrab1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gclWindowGrab1.Location = new System.Drawing.Point(0, 221);
            this.gclWindowGrab1.Margin = new System.Windows.Forms.Padding(2);
            this.gclWindowGrab1.Name = "gclWindowGrab1";
            this.gclWindowGrab1.Size = new System.Drawing.Size(282, 32);
            this.gclWindowGrab1.TabIndex = 0;
            // 
            // FloatingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.gclWindowGrab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FloatingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FloatingWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private GCLWindowGrab gclWindowGrab1;
    }
}