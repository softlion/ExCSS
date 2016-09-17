
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
            var format = Offset < 0
                ? ":{0}({1}n{2})"
                : ":{0}({1}n+{2})";

            sb.Append(string.IsNullOrEmpty(FunctionText)
                ? string.Format(format, functionName, Step, Offset)
                : string.Format(":{0}({1})", functionName, FunctionText));
        }

        public abstract override void ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0);
    }
}