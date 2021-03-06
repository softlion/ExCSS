﻿using System;
using ExCSS.Model;
using System.Text;
// ReSharper disable once CheckNamespace

namespace ExCSS
{
    public sealed class SimpleSelector : BaseSelector
    {
        private readonly string _code;
        internal static readonly SimpleSelector All = new SimpleSelector("*");

        public SimpleSelector(string selectorText)
        {
            _code = selectorText;
        }
        public SimpleSelector(string part1, string part2)
        {
            _code = part1 + part2;
        }

        public SimpleSelector(char part1, string part2)
        {
            _code = part1 + part2;
        }

        internal static SimpleSelector PseudoElement(string pseudoElement)
        {
            return new SimpleSelector("::", pseudoElement);
        }

        internal static SimpleSelector PseudoClass(string pseudoClass)
        {
            return new SimpleSelector(':', pseudoClass);
        }

        internal static SimpleSelector Class(string match)
        {
            return new SimpleSelector('.', match);
        }

        internal static SimpleSelector Id(string match)
        {
            return new SimpleSelector('#', match);
        }

        internal static SimpleSelector AttributeUnmatched(string match)
        {
            return new SimpleSelector("[" + match + "]");
        }

        internal static SimpleSelector AttributeMatch(string match, string value)
        {
            var code = "[" + match + "=\"" + GetValueAsString(value) + "\"]";
            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeNegatedMatch(string match, string value)
        {
            var code = "[" + match + "!=\"" + GetValueAsString(value) + "\"]";
            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeSpaceSeparated(string match, string value)
        {
            var code = "[" + match + "~=\"" + GetValueAsString(value) + "\"]";

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeStartsWith(string match, string value)
        {
            var code = "[" + match + "^=\"" + GetValueAsString(value) + "\"]";

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeEndsWith(string match, string value)
        {
            var code = "[" + match + "$=\"" + GetValueAsString(value) + "\"]";

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeContains(string match, string value)
        {
            var code = "[" + match + "*=\"" + GetValueAsString(value) + "\"]";

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeDashSeparated(string match, string value)
        {
            var code = "[" + match + "|=\"" + GetValueAsString(value) + "\"]";
            return new SimpleSelector(code);
        }

        internal static SimpleSelector Type(string match)
        {
            return new SimpleSelector(match);
        }

        private static string GetValueAsString(string value)
        {
            var containsSpace = false;

            for (var i = 0; i < value.Length; i++)
            {
                if (!value[i].IsSpaceCharacter())
                    continue;
                containsSpace = true;
                break;
            }

            if (!containsSpace)
                return value;

            if (value.IndexOf(Specification.SingleQuote) != -1)
                return "\"" + value + "\"";

            return "'" + value + "'";
        }

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            return sb.Append(_code);
        }
    }
}
