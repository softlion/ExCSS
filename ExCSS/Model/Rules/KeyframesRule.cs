using System;
using System.Collections.Generic;
using System.Linq;
using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class KeyframesRule : RuleSet, IRuleContainer
    {
        private readonly List<RuleSet> _ruleSets;
        private string _identifier;

        public KeyframesRule()
        {
            _ruleSets = new List<RuleSet>();
            RuleType = RuleType.Keyframes;
            AtRuleKeyword = "keyframes";
        }

        public string Identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        //TODO change to "keyframes"
        public List<RuleSet> Declarations
        {
            get { return _ruleSets; }
        }

        
        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            sb.NewLineIndent(friendlyFormat, indentation).Append('@').Append(AtRuleKeyword).Append(' ').Append(_identifier).Append('{');

            //if (friendlyFormat) sb.NewLineIndent("", true, indentation + 1);
            foreach (var r in _ruleSets)
            {
                //if (first) first = false;
                if (friendlyFormat) sb.NewLineIndent("", friendlyFormat, indentation);
                r.ToString(sb, friendlyFormat, indentation + 1);
            }

            return sb.NewLineIndent("}", friendlyFormat, indentation);                
        }

        public string AtRuleKeyword { get; set; }
    }
}
