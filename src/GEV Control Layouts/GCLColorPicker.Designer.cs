namespace GEV.Layouts
{
    partial class GCLColorPicker
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nudBlue = new GEV.Layouts.GCLNumericUpDown();
            this.nudGreen = new GEV.Layouts.GCLNumericUpDown();
            this.nudRed = new GEV.Layouts.GCLNumericUpDown();
            this.gclPanel1 = new GEV.Layouts.GCLPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "R:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "G:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GEV.Layouts.Properties.Resources.colorpicker;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 185);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GCLColorPicker_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GCLColorPicker_MouseClick);
            // 
            // nudBlue
            // 
            this.nudBlue.Increment = 1;
            this.nudBlue.Location = new System.Drawing.Point(222, 134);
            this.nudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBlue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBlue.Name = "nudBlue";
            this.nudBlue.Size = new System.Drawing.Size(80, 22);
            this.nudBlue.TabIndex = 7;
            this.nudBlue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBlue.ValueChanged += new System.EventHandler(this.OnColorInputChange);
            // 
            // nudGreen
            // 
            this.nudGreen.Increment = 1;
            this.nudGreen.Location = new System.Drawing.Point(222, 106);
            this.nudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudGreen.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudGreen.Name = "nudGreen";
            this.nudGreen.Size = new System.Drawing.Size(80, 22);
            this.nudGreen.TabIndex = 6;
            this.nudGreen.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudGreen.ValueChanged += new System.EventHandler(this.OnColorInputChange);
            // 
            // nudRed
            // 
            this.nudRed.Increment = 1;
            this.nudRed.Location = new System.Drawing.Point(222, 78);
            this.nudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRed.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRed.Name = "nudRed";
            this.nudRed.Size = new System.Drawing.Size(80, 22);
            this.nudRed.TabIndex = 2;
            this.nudRed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRed.ValueChanged += new System.EventHandler(this.OnColorInputChange);
            // 
            // gclPanel1
            // 
            this.gclPanel1.BackColor = System.Drawing.Color.White;
            this.gclPanel1.Location = new System.Drawing.Point(194, 7);
            this.gclPanel1.Name = "gclPanel1";
            this.gclPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.gclPanel1.Size = new System.Drawing.Size(108, 63);
            this.gclPanel1.TabIndex = 1;
            // 
            // GCLColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudBlue);
            this.Controls.Add(this.nudGreen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudRed);
            this.Controls.Add(this.gclPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GCLColorPicker";
            this.Size = new System.Drawing.Size(308, 195);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private GCLPanel gclPanel1;
        private GCLNumericUpDown nudRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private GCLNumericUpDown nudGreen;
        private GCLNumericUpDown nudBlue;
    }
}
