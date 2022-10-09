using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box <T>
    {
        //private Stack<T> stack = new Stack<T>();
        private List<T> list;
        public Box()
        {
            list = new List<T>();
        }
        public int Count { get { return list.Count; } }

        public void Add (T element)
        {
           this.list.Insert(0, element);
           //this.stack.Push (element);
        }
        public T Remove()
        {
            T elementForRemove = list[0];
            list.RemoveAt(0);
            return elementForRemove;
            //return this.stack.Pop ();
        }

    }
}
