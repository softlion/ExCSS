
// ReSharper disable once CheckNamespace
namespace ExCSS
{
    internal sealed class NthOfTypeSelector : NthChildSelector
    {
        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return FormatSelector(PseudoSelectorPrefix.PseudoFunctionNthOfType);
        }
    }
}