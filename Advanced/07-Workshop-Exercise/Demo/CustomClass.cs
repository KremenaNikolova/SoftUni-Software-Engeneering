using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    internal class CustomClass
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomClass()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (this.Count<= index)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (this.Count<=index)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[Count] = item;

            this.Count++;
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
    }
}
