using System.Collections.Generic;

namespace ExCSS.Model.TextBlocks
{
    internal class RangeBlock : Block
    {
        public RangeBlock()
        {
            GrammarSegment = GrammarSegment.Range;
        }

        internal bool IsEmpty
        {
            get { return SelectedRange == null || SelectedRange.Length == 0; }
        }

        internal string[] SelectedRange { get; private set; }

        internal RangeBlock SetRange(string start, string end)
        {
#if SALTARELLE
            var startValue = int.Parse(start, 16);
#else
            var startValue = int.Parse(start, System.Globalization.NumberStyles.HexNumber);
#endif
            if (startValue > Specification.MaxPoint)
            {
                return this;
            }

            if (end == null)
            {
                SelectedRange = new [] { Utils.ConvertFromUtf32(startValue) };
            }
            else
            {
                var list = new List<string>();
#if SALTARELLE
                var endValue = int.Parse(end, 16);
#else
                var endValue = int.Parse(end, System.Globalization.NumberStyles.HexNumber);
#endif

                if (endValue > Specification.MaxPoint)
                {
                    endValue = Specification.MaxPoint;
                }

                for (; startValue <= endValue; startValue++)
                {
                    list.Add(Utils.ConvertFromUtf32(startValue));
                }

                SelectedRange = list.ToArray();
            }

            return this;
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return string.Empty;
            }

            if (SelectedRange.Length == 1)
            {
                return "#" + Utils.ConvertToUtf32(SelectedRange[0], 0)
#if SALTARELLE
                .ToString(16);
#else
                .ToString("x");
#endif
            }

            return "#" + Utils.ConvertToUtf32(SelectedRange[0], 0)
#if SALTARELLE
                .ToString(16)
#else
                .ToString("x")
#endif
            + "-#" +
            Utils.ConvertToUtf32(SelectedRange[SelectedRange.Length - 1], 0)
#if SALTARELLE
                .ToString(16);
#else
                .ToString("x");
#endif
        }
    }
}
