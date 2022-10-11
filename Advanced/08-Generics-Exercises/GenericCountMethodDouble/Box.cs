using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> list;

        public Box()
        {
            List= new List<T>();
        }
        public List<T> List { get; set; }

        public int CompareCount(T compareNumber)
        {
            int counter = 0;
            foreach (var item in List)
            {
                int isBigger = item.CompareTo(compareNumber);
                if (isBigger>0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
