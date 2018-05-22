namespace GEV.Layouts.PropertyGrid
{
    partial class GCLPropertyGrid
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlCategoryPresenters = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Symbol", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(582, 47);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "[NAME]";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblType.Location = new System.Drawing.Point(0, 47);
            this.lblType.Margin = new System.Windows.Forms.Padding(0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(47, 19);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "[TYPE]";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProperty.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProperty.Location = new System.Drawing.Point(0, 436);
            this.lblProperty.Margin = new System.Windows.Forms.Padding(0);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(101, 19);
            this.lblProperty.TabIndex = 2;
            this.lblProperty.Text = "[PROPNAME]";
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescription.Location = new System.Drawing.Point(0, 455);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(582, 58);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "[DESCRIPTION]";
            // 
            // pnlCategoryPresenters
            // 
            this.pnlCategoryPresenters.AutoScroll = true;
            this.pnlCategoryPresenters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategoryPresenters.Location = new System.Drawing.Point(0, 66);
            this.pnlCategoryPresenters.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCategoryPresenters.Name = "pnlCategoryPresenters";
            this.pnlCategoryPresenters.Size = new System.Drawing.Size(582, 370);
            this.pnlCategoryPresenters.TabIndex = 4;
            // 
            // GCLPropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCategoryPresenters);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.Name = "GCLPropertyGrid";
            this.Size = new System.Drawing.Size(582, 513);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlCategoryPresenters;
    }
}
