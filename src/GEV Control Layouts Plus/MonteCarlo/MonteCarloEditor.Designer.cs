using GEV.Layouts.Extended.MonteCarlo.Implementation;

namespace GEV.Layouts.Extended.MonteCarlo
{
    partial class MonteCarloEditor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editor = new GEV.Layouts.Extended.MonteCarlo.Implementation.MonteCarloTextBox();
            this.documentMap = new GEV.Layouts.Extended.MonteCarlo.Implementation.MonteCarloDocumentMap();
            this.scrollHorizontal = new GEV.Layouts.Extended.ScrollBar();
            this.scrollVertical = new GEV.Layouts.Extended.ScrollBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editor)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.scrollHorizontal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.scrollVertical, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1015, 631);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.scrollHorizontal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.scrollHorizontal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tableLayoutPanel1.SetColumnSpan(this.scrollHorizontal, 2);
            this.scrollHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollHorizontal.Location = new System.Drawing.Point(0, 611);
            this.scrollHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.scrollHorizontal.Maximum = 100;
            this.scrollHorizontal.Name = "scrollHorizontal";
            this.scrollHorizontal.Orientation = System.Windows.Forms.ScrollOrientation.HorizontalScroll;
            this.scrollHorizontal.Size = new System.Drawing.Size(994, 20);
            this.scrollHorizontal.TabIndex = 3;
            this.scrollHorizontal.Text = "scrollBar2";
            this.scrollHorizontal.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.scrollHorizontal.ThumbSize = 10;
            this.scrollHorizontal.Value = 0;
            this.scrollHorizontal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // editor
            // 
            this.editor.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.editor.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.editor.AutoScrollMinSize = new System.Drawing.Size(263, 22);
            this.editor.BackBrush = null;
            this.editor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.editor.CaretColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.editor.CharHeight = 22;
            this.editor.CharWidth = 12;
            this.editor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.editor.DescriptionFile = "";
            this.editor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.FoldingIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(178)))), ((int)(((byte)(80)))));
            this.editor.Font = new System.Drawing.Font("Courier New", 12F);
            this.editor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.editor.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.editor.IsReplaceMode = false;
            this.editor.LeftBracket = '(';
            this.editor.LeftBracket2 = '{';
            this.editor.LeftPadding = 30;
            this.editor.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.editor.Location = new System.Drawing.Point(3, 3);
            this.editor.Name = "editor";
            this.editor.Paddings = new System.Windows.Forms.Padding(0);
            this.editor.RightBracket = ')';
            this.editor.RightBracket2 = '}';
            this.editor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(210)))));
            this.editor.ServiceLinesColor = System.Drawing.SystemColors.ScrollBar;
            this.editor.ShowFoldingLines = true;
            this.editor.Size = new System.Drawing.Size(788, 605);
            this.editor.TabIndex = 4;
            this.editor.Text = "fastColoredTextBox1";
            this.editor.Zoom = 100;
            this.editor.TextChanged += new System.EventHandler<GEV.Layouts.Extended.MonteCarlo.Implementation.TextChangedEventArgs>(this.editor_TextChanged);
            this.editor.ScrollbarsUpdated += new System.EventHandler(this.editor_ScrollbarsUpdated);
            // 
            // documentMap
            // 
            this.documentMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.documentMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(210)))));
            this.documentMap.Location = new System.Drawing.Point(794, 0);
            this.documentMap.Margin = new System.Windows.Forms.Padding(0);
            this.documentMap.Name = "documentMap";
            this.documentMap.ScrollbarVisible = false;
            this.documentMap.Size = new System.Drawing.Size(200, 611);
            this.documentMap.TabIndex = 1;
            this.documentMap.Target = this.editor;
            this.documentMap.Text = "documentMap1";
            // 
            // scrollHorizontal
            // 
            this.scrollHorizontal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.scrollHorizontal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.scrollHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollHorizontal.Location = new System.Drawing.Point(0, 497);
            this.scrollHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.scrollHorizontal.Maximum = 100;
            this.scrollHorizontal.Name = "scrollHorizontal";
            this.scrollHorizontal.Orientation = System.Windows.Forms.ScrollOrientation.HorizontalScroll;
            this.scrollHorizontal.Size = new System.Drawing.Size(745, 16);
            this.scrollHorizontal.TabIndex = 3;
            this.scrollHorizontal.Text = "scrollBar2";
            this.scrollHorizontal.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.scrollHorizontal.ThumbSize = 10;
            this.scrollHorizontal.Value = 0;
            this.scrollHorizontal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // scrollVertical
            // 
            this.scrollVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.scrollVertical.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.scrollVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollVertical.Location = new System.Drawing.Point(994, 0);
            this.scrollVertical.Margin = new System.Windows.Forms.Padding(0);
            this.scrollVertical.Maximum = 100;
            this.scrollVertical.Name = "scrollVertical";
            this.scrollVertical.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scrollVertical.Size = new System.Drawing.Size(21, 611);
            this.scrollVertical.TabIndex = 2;
            this.scrollVertical.Text = "scrollBar1";
            this.scrollVertical.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.scrollVertical.ThumbSize = 10;
            this.scrollVertical.Value = 0;
            this.scrollVertical.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // MonteCarloEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MonteCarloEditor";
            this.Size = new System.Drawing.Size(1015, 631);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MonteCarloDocumentMap documentMap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ScrollBar scrollHorizontal;
        private ScrollBar scrollVertical;
        private Implementation.MonteCarloTextBox editor;
    }
}
