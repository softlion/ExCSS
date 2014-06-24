using System;
using System.Globalization;

namespace ExCSS.Model.TextBlocks
{
    internal class UnitBlock : Block
    {
        private string _value;

        UnitBlock(GrammarSegment type)
        {
            GrammarSegment = type;
        }

        internal Single Value
        {
            get {
#if SALTARELLE
                return (float)double.Parse(_value);
#else
                return Single.Parse(_value, CultureInfo.InvariantCulture);
#endif
            }
        }

        internal string Unit { get; private set; }

        internal static UnitBlock Percentage(string value)
        {
            return new UnitBlock(GrammarSegment.Percentage) { _value = value, Unit = "%" };
        }

        internal static UnitBlock Dimension(string value, string dimension)
        {
            return new UnitBlock(GrammarSegment.Dimension) { _value = value, Unit = dimension };
        }

        public override string ToString()
        {
            return _value + Unit;
        }
    }
}
