using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList_Class
{
    internal class CustomList
    {
        private const int InitialCapacity = 2; //field is used to declare the initial capacity of the internal array
        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity]; //accept the range of array
        }
        public int[] Items { get { return items; } set { items = value; } } //hold all of our elements
        public int Index { get; set; } //indexer will provide us with functionality to access the elements 
        public int Counter { get; set; } //information of the actual count of the elements 
        public int this[int index]
        {
            get
            {
                if (index >= this.Counter)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return Items[index];
            }
            set
            {
                if (index >= this.Counter)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Items[index] = value;
            }
        }
        public void Add(int element) //which adds a new element to the end of our collection
        {
            if (this.Counter == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Counter] = element;
            Counter++;
        }

        private void Resize() //to increase the internal collection's length twice.
        {
            int[] copyOfArray = this.items;
            this.Items = new int[this.Items.Length * 2];
            for (int i = 0; i < copyOfArray.Length; i++)
            {
                this.Items[i] = copyOfArray[i];
            }
        }


        public void Shrink() //help us to decrease the internal collection's length twice.
        {

        }
        public void Shift() //help us to rearrange the internal collection's elements after removing one.
        {

        }
    }
}
