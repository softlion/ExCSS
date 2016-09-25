using ExCSS.Model.Extensions;
using System.Text;
// ReSharper disable once CheckNamespace


namespace ExCSS
{
    public class NamespaceRule : RuleSet
    {
        public NamespaceRule() 
        {
            RuleType = RuleType.Namespace;
        }

        public string Uri { get; set; }

        public string Prefix { get; set; }

        
        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0)
        {
            sb.NewLineIndent(friendlyFormat, indentation);
            if (string.IsNullOrEmpty(Prefix))
                sb.Append("@namespace '").Append(Uri).Append("';");
            else
                sb.Append("@namespace ").Append(Prefix).Append(" '").Append(Uri).Append("';");
            return sb;
        }
    }
}
