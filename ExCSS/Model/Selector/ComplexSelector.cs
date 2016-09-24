using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class ComplexSelector : BaseSelector, IEnumerable<CombinatorSelector>
    {
        private readonly List<CombinatorSelector> _selectors;

        public ComplexSelector()
        {
            _selectors = new List<CombinatorSelector>();
        }

        public ComplexSelector AppendSelector(BaseSelector selector, Combinator combinator)
        {
            _selectors.Add(new CombinatorSelector(selector, combinator));
            return this;
        }

        public IEnumerator<CombinatorSelector> GetEnumerator()
        {
            return _selectors.GetEnumerator();
        }
       
        public void ConcludeSelector(BaseSelector selector)
        {
            _selectors.Add(new CombinatorSelector(selector, Combinator.Child));
        }

        public int Length
        {
            get { return _selectors.Count; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_selectors).GetEnumerator();
        }

        public override void ToString(StringBuilder builder, bool friendlyFormat, int indentation = 0)
        {

            if (_selectors.Count <= 0)
            {
                return;
            }

            var n = _selectors.Count - 1;

            for (var i = 0; i < n; i++)
            {
                _selectors[i].Selector.ToString(builder);
                builder.Append(_selectors[i].Character);
            }

            _selectors[n].Selector.ToString(builder);

        }
    }
}
