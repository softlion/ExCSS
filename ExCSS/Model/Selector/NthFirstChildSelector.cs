
// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal sealed class NthFirstChildSelector : NthChildSelector
    {
        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            return FormatSelector(sb, PseudoSelectorPrefix.PseudoFunctionNthchild);
        }
    }
}