
// ReSharper disable once CheckNamespace
using System.Text;
using System;

namespace ExCSS
{
    public abstract class BaseSelector
    {
        public sealed override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb, false);
            return sb.ToString();
        }

        public abstract void ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0);

        
    }
}

