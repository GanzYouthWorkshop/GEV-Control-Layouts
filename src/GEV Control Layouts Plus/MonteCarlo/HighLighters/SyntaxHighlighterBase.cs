﻿using GEV.Layouts.Extended.MonteCarlo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GEV.Layouts.Extended.MonteCarlo.HighLighters
{
    public abstract class SyntaxHighlighterBase : IDisposable
    {
        public static RegexOptions RegexCompiledOption
        {
            get
            {
                return RegexOptions.Compiled;
            }
        }
        protected static readonly Platform platformType = PlatformType.GetOperationSystemPlatform();

        public abstract void AutoIndentNeeded(object sender, AutoIndentEventArgs args);
        public abstract void HighlightSyntax(Range range);
        public abstract void Dispose();
    }
}
