using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class GenericRule : AggregateRule
    {
        private string _text;
        private bool _stopped;

        internal void SetInstruction(string text)
        {
            _text = text;
            _stopped = true;
        }

        internal void SetCondition(string text)
        {
            _text = text;
            _stopped = false;
        }

        
        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            if (_stopped)
                return sb.Append(_text).Append(';');

            return RuleSetsToString(sb.Append(_text).Append('{'), friendlyFormat, indentation).Append('}');
        }
    }
}
