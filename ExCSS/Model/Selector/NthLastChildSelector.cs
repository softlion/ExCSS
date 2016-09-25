using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    internal sealed class NthLastChildSelector : NthChildSelector
    {
        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            return FormatSelector(sb, PseudoSelectorPrefix.PseudoFunctionNthlastchild);
        }
    }
}