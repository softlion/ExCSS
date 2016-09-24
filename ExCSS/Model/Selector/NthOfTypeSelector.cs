﻿
// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal sealed class NthOfTypeSelector : NthChildSelector
    {
        public override void ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            FormatSelector(sb, PseudoSelectorPrefix.PseudoFunctionNthOfType);
        }
    }
}