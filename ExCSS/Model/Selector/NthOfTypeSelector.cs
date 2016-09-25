
// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal sealed class NthOfTypeSelector : NthChildSelector
    {
        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            return FormatSelector(sb, PseudoSelectorPrefix.PseudoFunctionNthOfType);
        }
    }
}