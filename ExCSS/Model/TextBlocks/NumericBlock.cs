using System;
using System.Globalization;

namespace ExCSS.Model.TextBlocks
{
    internal class NumericBlock : Block
    {
        private readonly string _data;

        internal NumericBlock(string number)
        {
            _data = number;
            GrammarSegment = GrammarSegment.Number;
        }

        public Single Value
        {
            get
            {
#if SALTARELLE
                return (float)double.Parse(_data);
#else
                return Single.Parse(_data, CultureInfo.InvariantCulture);
#endif
            }
        }
        
        public override string ToString()
        {
            return _data;
        }
    }
}
