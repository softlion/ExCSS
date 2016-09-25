using System.Linq;
using ExCSS.Model.Extensions;
using System.Text;
using System;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class SupportsRule : ConditionalRule
    {
        private string _condition;

        public SupportsRule()
        {
            RuleType = RuleType.Supports;
            _condition = string.Empty;
            AtRuleKeyword = "supports";
        }

        public string AtRuleKeyword { get; internal set; }

        public override string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public bool IsSupported{ get; set; }


        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0)
        {
            sb.NewLineIndent(friendlyFormat, indentation).Append('@').Append(AtRuleKeyword).Append(' ').Append(_condition).Append('{');
            return RuleSetsToString(sb, friendlyFormat, indentation).NewLineIndent("}", friendlyFormat, indentation);
        }
    }
}
