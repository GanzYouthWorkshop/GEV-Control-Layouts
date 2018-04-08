namespace GEV.Layouts
{
    partial class GCLLineMonitor
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
            this.lblFormattedInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gclProgressBar1 = new GEV.Layouts.GCLProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(10, 8);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(107, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "---";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFormattedInfo
            // 
            this.lblFormattedInfo.AutoSize = true;
            this.lblFormattedInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormattedInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(171)))));
            this.lblFormattedInfo.Location = new System.Drawing.Point(121, 8);
            this.lblFormattedInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormattedInfo.Name = "lblFormattedInfo";
            this.lblFormattedInfo.Size = new System.Drawing.Size(107, 24);
            this.lblFormattedInfo.TabIndex = 2;
            this.lblFormattedInfo.Text = "-";
            this.lblFormattedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFormattedInfo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gclProgressBar1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 59);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // gclProgressBar1
            // 
            this.gclProgressBar1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(171)))));
            this.tableLayoutPanel1.SetColumnSpan(this.gclProgressBar1, 2);
            this.gclProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gclProgressBar1.Location = new System.Drawing.Point(10, 34);
            this.gclProgressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.gclProgressBar1.MaxValue = 100;
            this.gclProgressBar1.Name = "gclProgressBar1";
            this.gclProgressBar1.Size = new System.Drawing.Size(218, 15);
            this.gclProgressBar1.TabIndex = 3;
            this.gclProgressBar1.Value = 30;
            // 
            // GCLLineMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GCLLineMonitor";
            this.Size = new System.Drawing.Size(238, 59);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFormattedInfo;
        private GCLProgressBar gclProgressBar1;
    }
}
