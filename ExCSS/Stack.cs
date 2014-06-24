using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExCSS
{
    public class Stack<T>
    {

        private List<T> items;
        public void Clear()
        {
            items.Clear();
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public T Peek()
        {
            return items[items.Count - 1];
        }


        public T Pop()
        {
            items.RemoveAt(items.Count - 1);
            return items[items.Count];
        }


        public void Push(T value)
        {
            items.Add(value);
        }


    }
}
