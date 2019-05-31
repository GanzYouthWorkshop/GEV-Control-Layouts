using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GEV.Layouts.Extended.MonteCarlo.HighLighters;
using GEV.Layouts.Extended.MonteCarlo.Implementation;

namespace GEV.Layouts.Extended.MonteCarlo
{
    public partial class MonteCarloEditor : UserControl, IGCLControl
    {
        public new string Text
        {
            get { return this.editor.Text; }
            set { this.editor.Text = value; }
        }

        public SyntaxHighlighterBase SyntaxHighlighter
        {
            get { return this.editor.SyntaxHighlighter; }
            set { this.editor.SyntaxHighlighter = value; }
        }

        [DefaultValue(true)]
        public bool ShowCodeMap
        {
            get { return this.m_ShowCodeMap; }
            set
            {
                this.m_ShowCodeMap = value;
                this.splitContainer1.Panel2Collapsed = !this.m_ShowCodeMap;
            }
        }
        private bool m_ShowCodeMap;

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return this.editor.ReadOnly; }
            set { this.editor.ReadOnly = value; }
        }

        [DefaultValue(true)]
        public bool ShowLineNumbers
        {
            get { return this.editor.ShowLineNumbers; }
            set { this.editor.ShowLineNumbers = value; }
        }

        public bool UseThemeColors
        {
            get { return this.m_UseThemeColors; }
            set { this.m_UseThemeColors = value; this.SetupColors(); }
        }
        private bool m_UseThemeColors;

        public MonteCarloTextBox Editor { get { return this.editor; } }
        public MonteCarloDocumentMap CodeMap { get { return this.documentMap; } }

        public MonteCarloEditor()
        {
            InitializeComponent();

            MonteCarloAutocompleteMenu popupMenu = new MonteCarloAutocompleteMenu(this.editor);
            popupMenu.MinFragmentLength = 1;

            this.editor.SyntaxHighlighter = new CSharpHighLighter();
        }

        #region Scrollozás
        private void AdjustScrollbars()
        {
            AdjustScrollbar(this.scrollVertical, this.editor.VerticalScroll.Maximum, this.editor.VerticalScroll.Value, this.editor.ClientSize.Height);
            AdjustScrollbar(this.scrollHorizontal, this.editor.HorizontalScroll.Maximum, this.editor.HorizontalScroll.Value, this.editor.ClientSize.Width);
        }

        private void AdjustScrollbar(ScrollBar scrollBar, int max, int value, int clientSize)
        {
            scrollBar.Maximum = max;
            scrollBar.Visible = max > 0;
            scrollBar.Value = Math.Min(scrollBar.Maximum, value);
        }

        private void editor_ScrollbarsUpdated(object sender, EventArgs e)
        {
            AdjustScrollbars();
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.editor.OnScroll(e, e.Type != ScrollEventType.ThumbTrack && e.Type != ScrollEventType.ThumbPosition);
        }

        #endregion

        #region Egyedi komment kinézet
        private TextStyle m_CommentStyle = new TextStyle(new SolidBrush(Color.FromArgb(76, 178, 80)), null, FontStyle.Regular);

        private void editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear previous highlighting
            e.ChangedRange.ClearStyle(m_CommentStyle);
            //highlight tags
            e.ChangedRange.SetStyle(m_CommentStyle, @"//.*$");
            e.ChangedRange.SetStyle(m_CommentStyle, new Regex(@"/\*.*[(\*/)|$]", RegexOptions.None));
        }
        #endregion

        private void SetupColors()
        {
            if (this.UseThemeColors)
            {
                this.editor.BackColor = GCLColors.SoftBorder;
                this.editor.IndentBackColor = GCLColors.SoftBorder;
                this.editor.ForeColor = GCLColors.PrimaryText;
                this.editor.LineNumberColor = GCLColors.SecondaryText;

                this.documentMap.BackColor = GCLColors.SoftBorder;

                this.scrollHorizontal.BackColor = GCLColors.SoftBorder;
                this.scrollVertical.BackColor = GCLColors.SoftBorder;
                this.scrollHorizontal.BorderColor = GCLColors.SoftBorder;
                this.scrollVertical.BorderColor = GCLColors.SoftBorder;
                this.scrollHorizontal.ThumbColor = GCLColors.SecondaryText;
                this.scrollVertical.ThumbColor = GCLColors.SecondaryText;

            }
            else
            {
                this.editor.BackColor = this.BackColor;
                this.editor.IndentBackColor = this.BackColor;
                this.editor.ForeColor = this.ForeColor;
                this.editor.LineNumberColor = GCLColors.SecondaryText;

                this.documentMap.BackColor = this.BackColor;

                this.scrollHorizontal.BackColor = this.BackColor;
                this.scrollVertical.BackColor = this.BackColor;
                this.scrollHorizontal.BorderColor = this.BackColor;
                this.scrollVertical.BorderColor = this.BackColor;
                this.scrollHorizontal.ThumbColor = GCLColors.SecondaryText;
                this.scrollVertical.ThumbColor = GCLColors.SecondaryText;
            }

            this.editor.Invalidate();
            this.documentMap.Invalidate();
            this.scrollHorizontal.Invalidate();
            this.scrollVertical.Invalidate();
        }
    }
}
