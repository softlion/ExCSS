using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExCSS
{
    public class Stack<T>
    {

        public Stack()
        {
            items = new List<T>();
        }


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
            var k = items[items.Count - 1];
            ((dynamic)items).length--;
            return k;
        }


        public void Push(T value)
        {
            items.Add(value);
        }


    }
}
