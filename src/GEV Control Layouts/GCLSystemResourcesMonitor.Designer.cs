namespace GEV.Layouts
{
    partial class GCLSystemResourcesMonitor
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
            this.lmNetwork = new GEV.Layouts.GCLLineMonitor();
            this.lmRAM = new GEV.Layouts.GCLLineMonitor();
            this.lmCPU = new GEV.Layouts.GCLLineMonitor();
            this.SuspendLayout();
            // 
            // lmNetwork
            // 
            this.lmNetwork.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            this.lmNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            this.lmNetwork.Format = "{0}% / {1}%";
            this.lmNetwork.Location = new System.Drawing.Point(0, 104);
            this.lmNetwork.Margin = new System.Windows.Forms.Padding(0);
            this.lmNetwork.MaxValue = 100;
            this.lmNetwork.Name = "lmNetwork";
            this.lmNetwork.Size = new System.Drawing.Size(345, 52);
            this.lmNetwork.TabIndex = 12;
            this.lmNetwork.Title = "Hálózat";
            this.lmNetwork.Value = 10;
            // 
            // lmRAM
            // 
            this.lmRAM.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(87)))), ((int)(((byte)(152)))));
            this.lmRAM.Dock = System.Windows.Forms.DockStyle.Top;
            this.lmRAM.Format = "{0}% / {1}%";
            this.lmRAM.Location = new System.Drawing.Point(0, 52);
            this.lmRAM.Margin = new System.Windows.Forms.Padding(0);
            this.lmRAM.MaxValue = 100;
            this.lmRAM.Name = "lmRAM";
            this.lmRAM.Size = new System.Drawing.Size(345, 52);
            this.lmRAM.TabIndex = 11;
            this.lmRAM.Title = "RAM";
            this.lmRAM.Value = 10;
            // 
            // lmCPU
            // 
            this.lmCPU.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(134)))), ((int)(((byte)(171)))));
            this.lmCPU.Dock = System.Windows.Forms.DockStyle.Top;
            this.lmCPU.Format = "{0}% / {1}%";
            this.lmCPU.Location = new System.Drawing.Point(0, 0);
            this.lmCPU.Margin = new System.Windows.Forms.Padding(0);
            this.lmCPU.MaxValue = 100;
            this.lmCPU.Name = "lmCPU";
            this.lmCPU.Size = new System.Drawing.Size(345, 52);
            this.lmCPU.TabIndex = 10;
            this.lmCPU.Title = "CPU";
            this.lmCPU.Value = 10;
            // 
            // GCLSystemResourcesMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lmNetwork);
            this.Controls.Add(this.lmRAM);
            this.Controls.Add(this.lmCPU);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GCLSystemResourcesMonitor";
            this.Size = new System.Drawing.Size(345, 162);
            this.ResumeLayout(false);

        }

        #endregion

        private GCLLineMonitor lmNetwork;
        private GCLLineMonitor lmRAM;
        private GCLLineMonitor lmCPU;
    }
}
