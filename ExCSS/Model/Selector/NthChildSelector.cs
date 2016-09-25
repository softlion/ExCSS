
// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal abstract class NthChildSelector : BaseSelector
    {
        public int Step;
        public int Offset;
        internal string FunctionText { get; set; }

        internal StringBuilder FormatSelector(StringBuilder sb, string functionName)
        {
            sb.Append(':').Append(functionName).Append('(');

            if (string.IsNullOrEmpty(FunctionText))
            {
                sb.Append(Step).Append('n');

                if (Offset >= 0)
                    sb.Append('+');
                
                sb.Append(Offset);
            }
            else
            {
                sb.Append(FunctionText);
            }
            return sb.Append(')');
        }
    }
}