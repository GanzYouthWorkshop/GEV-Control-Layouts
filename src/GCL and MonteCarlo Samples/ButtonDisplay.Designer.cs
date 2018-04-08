namespace WindowsFormsApplication3
{
    partial class ButtonDisplay
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
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(65)))));
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(171)))));
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(158)))), ((int)(((byte)(202)))));
            this.btnEdit.Location = new System.Drawing.Point(0, 0);
            this.btnEdit.Size = new System.Drawing.Size(150, 150);
            this.btnEdit.Text = "  EDIT";
            // 
            // ButtonDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ButtonDisplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
