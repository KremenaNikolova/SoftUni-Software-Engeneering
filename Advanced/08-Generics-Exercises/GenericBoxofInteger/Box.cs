using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofInteger
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            List = new List<T>();
        }
        public List<T> List { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in List)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
