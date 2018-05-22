namespace GEV.Layouts.Extended.MiniCAD
{
    partial class MiniCADEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniCADEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scrollBar1 = new GEV.Layouts.Extended.ScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.scrollBar2 = new GEV.Layouts.Extended.ScrollBar();
            this.canvas = new GEV.Layouts.Extended.MiniCAD.Implementation.MiniCADCanvas();
            this.toolTip1 = new GEV.Layouts.GCLToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.scrollBar1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 448);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 16);
            this.panel1.TabIndex = 2;
            // 
            // scrollBar1
            // 
            this.scrollBar1.BorderColor = System.Drawing.Color.Silver;
            this.scrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollBar1.Location = new System.Drawing.Point(600, 0);
            this.scrollBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scrollBar1.Maximum = 100;
            this.scrollBar1.Name = "scrollBar1";
            this.scrollBar1.Orientation = System.Windows.Forms.ScrollOrientation.HorizontalScroll;
            this.scrollBar1.Size = new System.Drawing.Size(223, 16);
            this.scrollBar1.TabIndex = 2;
            this.scrollBar1.Text = "scrollBar1";
            this.scrollBar1.ThumbColor = System.Drawing.Color.Gray;
            this.scrollBar1.ThumbSize = 10;
            this.scrollBar1.Value = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(823, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 16);
            this.panel2.TabIndex = 3;
            // 
            // scrollBar2
            // 
            this.scrollBar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.scrollBar2.BorderColor = System.Drawing.Color.Silver;
            this.scrollBar2.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrollBar2.Location = new System.Drawing.Point(823, 0);
            this.scrollBar2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scrollBar2.Maximum = 100;
            this.scrollBar2.Name = "scrollBar2";
            this.scrollBar2.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scrollBar2.Size = new System.Drawing.Size(15, 448);
            this.scrollBar2.TabIndex = 3;
            this.scrollBar2.Text = "scrollBar2";
            this.scrollBar2.ThumbColor = System.Drawing.Color.Gray;
            this.scrollBar2.ThumbSize = 10;
            this.scrollBar2.Value = 0;
            // 
            // canvas
            // 
            this.canvas.CursorPosition = ((System.Drawing.PointF)(resources.GetObject("canvas.CursorPosition")));
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Document = null;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(838, 448);
            this.canvas.TabIndex = 0;
            this.canvas.Text = "miniCADCanvas1";
            this.canvas.ViewportPosition = ((System.Drawing.PointF)(resources.GetObject("canvas.ViewportPosition")));
            this.canvas.Zoom = 1F;
            this.canvas.MouseEnter += new System.EventHandler(this.canvas_MouseEnter);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.miniCADCanvas1_MouseMove);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.toolTip1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(65)))));
            this.toolTip1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.UseThemeColors = true;
            // 
            // MiniCADEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollBar2);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MiniCADEditor";
            this.Size = new System.Drawing.Size(838, 464);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Implementation.MiniCADCanvas canvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private ScrollBar scrollBar1;
        private ScrollBar scrollBar2;
        private System.Windows.Forms.Panel panel2;
        private GEV.Layouts.GCLToolTip toolTip1;
    }
}
