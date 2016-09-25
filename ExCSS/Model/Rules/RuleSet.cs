using System.Text;

namespace ExCSS
{
    public abstract class RuleSet
    {
        internal RuleSet()
        {
            RuleType = RuleType.Unknown;
        }

        public RuleType RuleType { get; set; }

        public abstract StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0);

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb, false);
            return sb.ToString();
        }
    }
}
