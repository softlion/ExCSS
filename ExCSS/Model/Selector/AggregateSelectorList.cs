using System;
using System.Text;
#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class AggregateSelectorList : SelectorList
    {
        public readonly string Delimiter;

        public AggregateSelectorList(string delimiter)
        {
            if (delimiter.Length > 1)
            {
                throw new ArgumentException("Expected single character delimiter or empty string", "delimiter");
            }
            
            Delimiter = delimiter;
        }

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0)
        {
            var first = true;
            foreach (var selector in Selectors)
            {
                if (first)
                    first = false;
                else
                    sb.Append(Delimiter);
                selector.ToString(sb, friendlyFormat, indentation + 1);                    
            }
            return sb;
        }
    }
}
