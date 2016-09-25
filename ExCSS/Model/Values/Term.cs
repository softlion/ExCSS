
// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    public abstract class Term
    {
        public static readonly InheritTerm Inherit = new InheritTerm();

        public abstract StringBuilder ToString(StringBuilder sb);

        public override string ToString()
        {
            return ToString(new StringBuilder()).ToString();
        }
    }
}
