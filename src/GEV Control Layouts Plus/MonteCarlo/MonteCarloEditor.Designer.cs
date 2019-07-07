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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editor = new GEV.Layouts.Extended.MonteCarlo.Implementation.MonteCarloTextBox();
            this.documentMap = new GEV.Layouts.Extended.MonteCarlo.Implementation.MonteCarloDocumentMap();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editor)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(761, 513);
            this.splitContainer1.SplitterDistance = 572;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
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
            this.editor.AutoScrollMinSize = new System.Drawing.Size(222, 18);
            this.editor.BackBrush = null;
            this.editor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.editor.CaretColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.editor.CharHeight = 18;
            this.editor.CharWidth = 10;
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
            // MonteCarloEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.splitContainer1);
            this.Name = "MonteCarloEditor";
            this.Size = new System.Drawing.Size(761, 513);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MonteCarloDocumentMap documentMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Implementation.MonteCarloTextBox editor;
    }
}
