using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class Property
    {
        public Property(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public Term Term { get; set; }

        public bool Important { get; set; }

        public override string ToString()
        {
            return ToString(new StringBuilder(), false).ToString();
        }

        public StringBuilder ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            sb.Indent(friendlyFormat, indentation).Append(Name).Append(':');
            Term?.ToString(sb);
            if (Important)
                sb.Append(" !important");
            return sb;
        }
    }
}
