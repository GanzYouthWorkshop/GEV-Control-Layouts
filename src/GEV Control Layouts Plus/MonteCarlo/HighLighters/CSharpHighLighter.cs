using GEV.Layouts;
using GEV.Layouts.Extended.MonteCarlo.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MonteCarlo.HighLighters
{
    public class CSharpHighLighter : SyntaxHighlighterBase
    {
        protected Regex CSharpAttributeRegex = new Regex(@"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline | RegexCompiledOption);
        protected Regex CSharpClassNameRegex = new Regex(@"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline | RegexCompiledOption);

        protected Regex CSharpCommentRegex1 = new Regex(@"//.*$", RegexOptions.Multiline | RegexCompiledOption);
        protected Regex CSharpCommentRegex2 = new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexCompiledOption);
        protected Regex CSharpCommentRegex3 = new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);

        protected Regex CSharpKeywordRegex = new Regex(@"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b", RegexCompiledOption);
        protected Regex CSharpNumberRegex = new Regex(@"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b", RegexCompiledOption);
        protected Regex CSharpStringRegex = new Regex(@"'(?>(?:\\[^\r\n]|[^'\r\n])*)'?|(?<verbatimIdentifier>@)?""(?>(?:(?(verbatimIdentifier)""""|\\.)|[^""])*)""", RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexCompiledOption); //thanks to rittergig for this regex

        protected Regex HTMLTagContentRegex = new Regex(@"<[^>]+>", RegexCompiledOption);

        protected Style StringStyle { get; set; } = new TextStyle(new SolidBrush(Color.FromArgb(206, 145, 120)), null, FontStyle.Regular);
        protected Style CommentStyle { get; set; } = new TextStyle(new SolidBrush(GCLColors.SuccessGreen), null, FontStyle.Regular);
        protected Style NumberStyle { get; set; } = new TextStyle(new SolidBrush(Color.FromArgb(186, 206, 168)), null, FontStyle.Regular);
        protected Style AttributeStyle { get; set; } = new TextStyle(new SolidBrush(Color.FromArgb(55, 163, 110)), null, FontStyle.Regular);
        protected Style ClassNameStyle { get; set; } = new TextStyle(new SolidBrush(Color.FromArgb(55, 163, 110)), null, FontStyle.Regular);
        protected Style KeywordStyle { get; set; } = new TextStyle(new SolidBrush(Color.FromArgb(86, 156, 214)), null, FontStyle.Regular);
        protected Style CommentTagStyle { get; set; } = new TextStyle(new SolidBrush(Color.FromArgb(120, 120, 120)), null, FontStyle.Regular);

        public override void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)")) //operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }

        public override void Dispose()
        {
        }

        public override void HighlightSyntax(Range range)
        {
            range.tb.CommentPrefix = "//";
            range.tb.LeftBracket = '(';
            range.tb.RightBracket = ')';
            range.tb.LeftBracket2 = '{';
            range.tb.RightBracket2 = '}';
            range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            range.tb.AutoIndentCharsPatterns = @"^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;]+);^\s*(case|default)\s*[^:]*(?<range>:)\s*(?<range>[^;]+);";
            //clear style of changed range
            range.ClearStyle(StringStyle, CommentStyle, NumberStyle, AttributeStyle, ClassNameStyle, KeywordStyle);
            //

            range.SetStyle(StringStyle, CSharpStringRegex);
            range.SetStyle(CommentStyle, CSharpCommentRegex1);
            range.SetStyle(CommentStyle, CSharpCommentRegex2);
            range.SetStyle(CommentStyle, CSharpCommentRegex3);
            range.SetStyle(NumberStyle, CSharpNumberRegex);
            range.SetStyle(AttributeStyle, CSharpAttributeRegex);
            range.SetStyle(ClassNameStyle, CSharpClassNameRegex);
            range.SetStyle(KeywordStyle, CSharpKeywordRegex);

            //find document comments
            foreach (Range r in range.GetRanges(@"^\s*///.*$", RegexOptions.Multiline))
            {
                //remove C# highlighting from this fragment
                r.ClearStyle(StyleIndex.All);
                //do XML highlighting

                //
                r.SetStyle(CommentStyle);
                //tags
                foreach (Range rr in r.GetRanges(HTMLTagContentRegex))
                {
                    rr.ClearStyle(StyleIndex.All);
                    rr.SetStyle(CommentTagStyle);
                }
                //prefix '///'
                foreach (Range rr in r.GetRanges(@"^\s*///", RegexOptions.Multiline))
                {
                    rr.ClearStyle(StyleIndex.All);
                    rr.SetStyle(CommentTagStyle);
                }
            }

            //clear folding markers
            range.ClearFoldingMarkers();
            //set folding markers
            range.SetFoldingMarkers("{", "}"); //allow to collapse brackets block
            range.SetFoldingMarkers(@"#region\b", @"#endregion\b"); //allow to collapse #region blocks
            range.SetFoldingMarkers(@"/\*", @"\*/"); //allow to collapse comment block
        }
    }
}
