using System;
using ExCSS.Model;
using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class StyleRule : RuleSet, ISupportsSelector, ISupportsDeclarations
    {
        private readonly StyleDeclaration _declarations;
        private string cachedValue;

        public StyleRule() : this( new StyleDeclaration())
        {}

        public StyleRule(StyleDeclaration declarations) 
        {
            RuleType = RuleType.Style;
            _declarations = declarations;
        }

        public BaseSelector Selector { get { return selector; } set { selector = value; cachedValue=null; } }
        private BaseSelector selector;

        public string Value
        {
            get { return cachedValue ?? (cachedValue=Selector.ToString()); }
            set { selector = Parser.ParseSelector(value); cachedValue=value; }
        }

        public StyleDeclaration Declarations => _declarations;

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0)
        {
            return _declarations.ToString(Selector.ToString(sb.NewLineIndent(friendlyFormat, indentation)).Append('{'), friendlyFormat, indentation).NewLineIndent("}", friendlyFormat, indentation);
        }
    }
}
