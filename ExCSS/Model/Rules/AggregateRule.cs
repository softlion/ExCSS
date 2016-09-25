using System.Collections.Generic;
using ExCSS.Model;
using System.Text;
using ExCSS.Model.Extensions;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public abstract class AggregateRule : RuleSet, ISupportsRuleSets
    {
        protected AggregateRule()
        {
            RuleSets = new List<RuleSet>();
        }

        public List<RuleSet> RuleSets { get; }

        protected StringBuilder RuleSetsToString(StringBuilder sb, bool friendlyFormat=false, int indentation=0)
        {
            //if (friendlyFormat) sb.NewLineIndent("", true, indentation + 1);
            
            foreach (var r in RuleSets)
            {
                r.ToString(sb, friendlyFormat, indentation + 1);
            }
            return sb;
        }
    }
}
