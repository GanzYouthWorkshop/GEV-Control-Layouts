namespace GEV.Layouts.PropertyGrid.DisplayControls
{
    partial class ColorDisplay
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
            this.pnlColor = new GEV.Layouts.GCLPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(65)))));
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(171)))));
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(158)))), ((int)(((byte)(202)))));
            this.btnEdit.Location = new System.Drawing.Point(779, 0);
            this.btnEdit.Size = new System.Drawing.Size(34, 30);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(84)))), ((int)(((byte)(86)))));
            this.pnlColor.Location = new System.Drawing.Point(3, 5);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Padding = new System.Windows.Forms.Padding(10);
            this.pnlColor.Size = new System.Drawing.Size(19, 19);
            this.pnlColor.TabIndex = 1;
            this.pnlColor.Click += new System.EventHandler(this.OnSelect);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(31, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(745, 30);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Click += new System.EventHandler(this.OnSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlColor, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 30);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ColorDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorDisplay";
            this.Size = new System.Drawing.Size(813, 30);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GCLPanel pnlColor;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
