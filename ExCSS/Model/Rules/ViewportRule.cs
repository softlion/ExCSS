using System;
using ExCSS.Model;
using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class ViewportRule : RuleSet, ISupportsDeclarations
    {

        private readonly StyleDeclaration _declarations;

        public ViewportRule() : this(new StyleDeclaration())
        { }

        public ViewportRule(StyleDeclaration declarations)
        {
            RuleType = RuleType.Viewport;
            _declarations = declarations;
            AtRuleKeyword = "viewport";
        }



        public StyleDeclaration Declarations
        {
            get { return _declarations; }
        }

        
        public string AtRuleKeyword { get; set; }

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0)
        {
            sb.Append('@').Append(AtRuleKeyword).Append('{');
            return _declarations.ToString(sb, friendlyFormat, indentation).NewLineIndent("}", friendlyFormat, indentation);
        }
    }
}
