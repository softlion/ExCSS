
// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    public abstract class Term
    {
        public static readonly InheritTerm Inherit = new InheritTerm();
        public abstract void ToString(StringBuilder sb);

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }
    }
}
