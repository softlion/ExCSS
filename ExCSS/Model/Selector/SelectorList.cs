using System.Collections;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public abstract class SelectorList : BaseSelector, IEnumerable<BaseSelector>
    {
        protected List<BaseSelector> Selectors;

        protected SelectorList()
        {
            Selectors = new List<BaseSelector>();
        }

        public int Length => Selectors.Count;

        public BaseSelector this[int index]
        {
            get { return Selectors[index]; }
            set { Selectors[index] = value; }
        }

        public SelectorList AppendSelector(BaseSelector selector)
        {
            Selectors.Add(selector);
            return this;
        }

        public SelectorList RemoveSelector(SimpleSelector selector)
        {
            Selectors.Remove(selector);
            return this;
        }

        public SelectorList ClearSelectors()
        {
            Selectors.Clear();
            return this;
        }

        public IEnumerator<BaseSelector> GetEnumerator()
        {
            return Selectors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Selectors).GetEnumerator();
        }
    }
}
