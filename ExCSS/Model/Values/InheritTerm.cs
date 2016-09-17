using System;
using System.Text;

namespace ExCSS
{
    public class InheritTerm : Term
    {
        internal InheritTerm()
        {
        }

        public override void ToString(StringBuilder sb)
        {
            sb.Append( "inherit");
        }
    }
}

