using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] items;
        private const int capacity = 4;

        public Stack()
        {
            this.items = new T[capacity];
        }
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (items.Length==Count)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }
        public T Pop()
        {
           if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
           T removedElement = items[Count-1];
            Count--;
            return removedElement;
        }

        public void Resize()
        {
            T[] copyItems = new T[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                copyItems[i] = items[i];
            }
            items = copyItems;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count-1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
