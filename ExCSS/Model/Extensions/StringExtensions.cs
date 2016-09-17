using System;
using System.Text;
#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

namespace ExCSS.Model.Extensions
{
    public static class StringExtensions
    {
        
        public static void AppendTwoDigitHex(this StringBuilder sb, byte num)
        {
            var rem = num >> 4;

            sb.Append((char)(rem + (rem < 10 ? 48 : 55)));
            rem = num - 16 * rem;
            sb.Append((char)(rem + (rem < 10 ? 48 : 55)));

        }
        public static void Indent(this StringBuilder sb, string value, bool friendlyFormat, int indentation)
        {
            if (!friendlyFormat)
            {
                sb.Append(value);
                return;
            }


            for (var i = 0; i < indentation; i++)
            {
                sb.Append('\t');
            }
            sb.Append(value);
        }

        public static void Indent(this StringBuilder sb, bool friendlyFormat, int indentation)
        {
            if (!friendlyFormat) return;

            for (var i = 0; i < indentation; i++)
            {
                sb.Append('\t');
            }
        }

        
        public static void NewLineIndent(this StringBuilder sb, string value, bool friendlyFormat, int indentation)
        {
            if (!friendlyFormat)
            {
                sb.Append(value);
                return;
            }

            sb.AppendLine();
            sb.Indent(value, true, indentation);
        }


        public static void NewLineIndent(this StringBuilder sb, bool friendlyFormat, int indentation)
        {
            if (!friendlyFormat)
            {
                return;
            }

            sb.AppendLine();
            for (var i = 0; i < indentation; i++)
            {
                sb.Append('\t');
            }
        }

        
    }
}
