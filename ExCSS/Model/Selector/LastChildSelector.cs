// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal sealed class LastChildSelector : BaseSelector
    {
        LastChildSelector()
        { }

        static LastChildSelector _instance;

        public static LastChildSelector Instance
        {
            get { return _instance ?? (_instance = new LastChildSelector()); }
        }

        public override void ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            sb.Append(':');
            sb.Append(PseudoSelectorPrefix.PseudoLastchild);
        }
    }
}