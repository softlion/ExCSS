using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExCSS
{
    static class Utils
    {
        internal static string ConvertFromUtf32(int code)
        {
#if SALTARELLE
            // TODO should use String.fromCodePoint(), when it becomes more widely available
            return string.FromCharCode((char)code);
#else
            return char.ConvertFromUtf32(code);
#endif

        }

        internal static int ConvertToUtf32(string s, int index)
        {
#if SALTARELLE
            return s.CharCodeAt(index);
#else
            return char.ConvertToUtf32(s, index);
#endif
        }
    }
}
