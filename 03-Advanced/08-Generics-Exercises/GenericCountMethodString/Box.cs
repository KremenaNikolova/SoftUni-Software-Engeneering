using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> items;

        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public int Compare(T compareItem)
        {
            int counter = 0;
            foreach (var item in Items)
            {
                int isBigger = item.CompareTo(compareItem);
                if (isBigger>0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
