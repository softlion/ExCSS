using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class CharacterSetRule : RuleSet
    {
        public CharacterSetRule() 
        {
            RuleType = RuleType.Charset;
        }

        public string Encoding { get; internal set; }

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            return sb.NewLineIndent(friendlyFormat, indentation).Append("@charset '").Append(Encoding).Append("';");
        }
    }
}
