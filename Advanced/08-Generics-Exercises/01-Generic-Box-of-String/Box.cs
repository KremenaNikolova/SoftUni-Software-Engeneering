using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Generic_Box_of_String
{
    public class Box<T>
    {
        private List<T> collectingElements;
        public Box()
        {
            CollectingElements=new List<T>();
        }
        public List<T> CollectingElements { get; set; }
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var element in CollectingElements)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
