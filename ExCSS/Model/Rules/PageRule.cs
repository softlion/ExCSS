using ExCSS.Model;
using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class PageRule : RuleSet, ISupportsSelector, ISupportsDeclarations
    {
        private readonly StyleDeclaration _declarations;
        private BaseSelector _selector;

        public PageRule() 
        {
            _declarations = new StyleDeclaration();
            RuleType = RuleType.Page;
        }

        internal PageRule AppendRule(Property rule)
        {
            _declarations.Properties.Add(rule);
            return this;
        }

        public BaseSelector Selector
        {
            get { return _selector; }
            set
            {
                _selector = value;
            }
        }

        public StyleDeclaration Declarations
        {
            get { return _declarations; }
        }

     

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            sb.NewLineIndent(friendlyFormat, indentation).Append("@page ");
            _selector?.ToString(sb.Append(':'));
            return _declarations.ToString(sb.Append('{'), friendlyFormat, indentation).NewLineIndent("}", friendlyFormat, indentation);
        }
    }
}
