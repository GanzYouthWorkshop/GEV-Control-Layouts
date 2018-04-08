namespace GEV.Layouts.PropertyGrid.DisplayControls
{
    partial class EditFormDisplay
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
            this.btnEdit = new GEV.Layouts.GCLButton();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(76)))), ((int)(((byte)(79)))));
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(65)))));
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(171)))));
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(158)))), ((int)(((byte)(202)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnEdit.Location = new System.Drawing.Point(117, 0);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(33, 150);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // EditFormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEdit);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EditFormDisplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected GCLButton btnEdit;
    }
}
