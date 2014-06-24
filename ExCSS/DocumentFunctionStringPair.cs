using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExCSS
{
    class DocumentFunctionStringPair
    {
        public string Item2;

        public DocumentFunction Item1;

        public DocumentFunctionStringPair(DocumentFunction item1, string item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
    }
}
