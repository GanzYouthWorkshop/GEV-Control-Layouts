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
    public partial class MonteCarloEditor : UserControl
    {
        public MonteCarloEditor()
        {
            InitializeComponent();

            AutocompleteMenu popupMenu = new AutocompleteMenu(this.editor);
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

        TextStyle commentStyle = new TextStyle(new SolidBrush(Color.FromArgb(76, 178, 80)), null, FontStyle.Regular);

        private void editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear previous highlighting
            e.ChangedRange.ClearStyle(commentStyle);
            //highlight tags
            e.ChangedRange.SetStyle(commentStyle, @"//.*$");
            e.ChangedRange.SetStyle(commentStyle, new Regex(@"/\*.*[(\*/)|$]", RegexOptions.None));
        }
    }
}
