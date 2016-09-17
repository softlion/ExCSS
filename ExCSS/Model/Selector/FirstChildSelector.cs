// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal sealed class FirstChildSelector : BaseSelector
    {
        FirstChildSelector()
        { }

        static FirstChildSelector _instance;

        public static FirstChildSelector Instance
        {
            get { return _instance ?? (_instance = new FirstChildSelector()); }
        }

        public override void ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            sb.Append(':');
            sb.Append(PseudoSelectorPrefix.PseudoFirstchild);
        }
    }
}