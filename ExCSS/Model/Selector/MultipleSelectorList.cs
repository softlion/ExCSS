using System.Text;
#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class MultipleSelectorList : SelectorList
    {
        internal static MultipleSelectorList Create(params SimpleSelector[] selectors)
        {
            var multiple = new MultipleSelectorList();

            foreach (var selector in selectors)
                multiple.Selectors.Add(selector);

            return multiple;
        }

        internal bool IsInvalid { get; set; }

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0)
        {
            if (Selectors.Count <= 0)
                return sb;

            Selectors[0].ToString(sb);
            for (var i = 1; i < Selectors.Count; i++)
                Selectors[i].ToString(sb.Append(','));
            return sb;
        }
    }
}
