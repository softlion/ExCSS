using System;
using System.Text;
#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

namespace ExCSS.Model.Extensions
{
    public static class StringExtensions
    {
        
        public static StringBuilder AppendTwoDigitHex(this StringBuilder sb, byte num)
        {
            var rem = num >> 4;

            sb.Append((char)(rem + (rem < 10 ? 48 : 55)));
            rem = num - 16 * rem;
            sb.Append((char)(rem + (rem < 10 ? 48 : 55)));
            return sb;
        }
        public static StringBuilder Indent(this StringBuilder sb, string value, bool friendlyFormat, int indentation)
        {
            if (!friendlyFormat)
                return sb.Append(value);


            for (var i = 0; i < indentation; i++)
                sb.Append('\t');
            
            return sb.Append(value);
        }

        public static StringBuilder Indent(this StringBuilder sb, bool friendlyFormat, int indentation)
        {
            if (friendlyFormat)
            {
                for (var i = 0; i < indentation; i++)
                    sb.Append('\t');
            }
            return sb;
        }

        
        public static StringBuilder NewLineIndent(this StringBuilder sb, string value, bool friendlyFormat, int indentation)
        {
            if (!friendlyFormat)
            {
                sb.Append(value);
                return sb;
            }

            return sb.AppendLine().Indent(value, true, indentation);
        }


        public static StringBuilder NewLineIndent(this StringBuilder sb, bool friendlyFormat, int indentation)
        {
            if (!friendlyFormat)
                return sb;

            sb.AppendLine();
            for (var i = 0; i < indentation; i++)
                sb.Append('\t');

            return sb;
        }
    }
}
