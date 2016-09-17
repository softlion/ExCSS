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

        public override void ToString(StringBuilder builder, bool friendlyFormat, int indentation = 0)
        {
            var first = true;
            foreach (var selector in Selectors)
            {
                if (first) first = false;
                else builder.Append(Delimiter);
                selector.ToString(builder, friendlyFormat, indentation + 1);                    
                
            }
           
        }
    }
}
