namespace GEV.Layouts
{
    partial class GCLWindowGrab
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
            this.lblGrab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGrab
            // 
            this.lblGrab.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.lblGrab.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblGrab.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(171)))));
            this.lblGrab.Location = new System.Drawing.Point(897, 0);
            this.lblGrab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrab.Name = "lblGrab";
            this.lblGrab.Size = new System.Drawing.Size(24, 26);
            this.lblGrab.TabIndex = 1;
            this.lblGrab.Text = "␥";
            this.lblGrab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGrab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblGrab_MouseMove);
            // 
            // GCLWindowGrab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.lblGrab);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GCLWindowGrab";
            this.Size = new System.Drawing.Size(921, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGrab;
    }
}
