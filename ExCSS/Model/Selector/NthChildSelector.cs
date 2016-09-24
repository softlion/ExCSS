
// ReSharper disable once CheckNamespace
using System.Text;

namespace ExCSS
{
    internal abstract class NthChildSelector : BaseSelector
    {
        public int Step;
        public int Offset;
        internal string FunctionText { get; set; }

        internal void FormatSelector(StringBuilder sb, string functionName)
        {
            sb.Append(':');
            sb.Append(functionName);
            sb.Append('(');

            if (string.IsNullOrEmpty(FunctionText))
            {
                sb.Append(Step);
                sb.Append('n');

                if (Offset >= 0) sb.Append('+');
                
                sb.Append(Offset);
            }
            else
            {
                sb.Append(FunctionText);
            }
            sb.Append(')');


        }

        public abstract override void ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0);
    }
}