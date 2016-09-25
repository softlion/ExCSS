using ExCSS.Model;
using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class KeyframeRule : RuleSet, ISupportsDeclarations
    {
        private string _value;

        public KeyframeRule()
        {
            Declarations = new StyleDeclaration();
            RuleType = RuleType.Keyframe;
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public StyleDeclaration Declarations { get; }

        

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            sb.Indent(string.Empty, friendlyFormat, indentation).Append(_value).Append('{');
            Declarations.ToString(sb, friendlyFormat, indentation);
            return sb.NewLineIndent("}", friendlyFormat, indentation);
        }
    }
}
