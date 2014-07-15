using System;
using ExCSS.Model;
using ExCSS.Model.Extensions;

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

        public override string ToString()
        {
            return ToString(false);
        }

        public string AtRuleKeyword { get; set; }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return
                "@" + AtRuleKeyword + "{" +
                _declarations.ToString(friendlyFormat, indentation) +
                "}".NewLineIndent(friendlyFormat, indentation);
        }
    }
}
