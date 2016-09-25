using System;
using System.Text;

namespace ExCSS
{
    public class InheritTerm : Term
    {
        internal InheritTerm()
        {
        }

        public override StringBuilder ToString(StringBuilder sb)
        {
            return sb.Append( "inherit");
        }
    }
}

