using System;
using System.Collections.Generic;
using System.Text;

namespace _1ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index = 0;
        public ListyIterator(List<T> items)
        {
            this.items = items;
        }
        public List<T> Elements { get; set; }
        public int Index { get; set; }
        public bool Move() //should move an internal index position to the next index in the list. The method should return true, if it had successfully moved the index and false, if there is no next index.
        {
            if (index + 1 < items.Count)
            {
                index++;
                return true;
            }
            return false;

        }
        public bool HasNext() //should return true, if there is a next index and false, if the index is already at the last element of the list.
        {
            return index + 1 < items.Count;
        }
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(items[index]);
        }
    }
}
