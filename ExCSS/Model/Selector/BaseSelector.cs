
// ReSharper disable once CheckNamespace
using System.Text;
using System;

namespace ExCSS
{
    public abstract class BaseSelector
    {
        public sealed override string ToString()
        {
            return ToString(new StringBuilder()).ToString();
        }

        public abstract StringBuilder ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0);
    }
}

