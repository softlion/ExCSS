// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal sealed class FirstChildSelector : BaseSelector
    {
        static FirstChildSelector _instance;

        public static FirstChildSelector Instance => _instance ?? (_instance = new FirstChildSelector());

        private FirstChildSelector()
        {
        }

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0)
        {
            return sb.Append(':').Append(PseudoSelectorPrefix.PseudoFirstchild);
        }
    }
}