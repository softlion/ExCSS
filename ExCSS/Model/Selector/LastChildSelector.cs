// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal sealed class LastChildSelector : BaseSelector
    {
        static LastChildSelector _instance;

        public static LastChildSelector Instance => _instance ?? (_instance = new LastChildSelector());

        private LastChildSelector()
        {
        }

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            return sb.Append(':').Append(PseudoSelectorPrefix.PseudoLastchild);
        }
    }
}