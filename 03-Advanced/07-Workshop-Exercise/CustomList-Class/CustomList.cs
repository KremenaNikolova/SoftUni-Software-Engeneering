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

        public int RemoveAt(int index) //remove an item on the given index and return the item
        {
            if (this.Counter <= index)
            {
                throw new ArgumentOutOfRangeException();
            }
            int removedItem = this.items[index];
            this.items[index] = default(int);
            this.ShiftLeft(index);
            this.Counter--;
            if (this.items.Length / 4 >= this.Counter)
            {
                this.Shrink();
            }
            return removedItem;
        }
        public void Shrink() //help us to decrease the internal collection's length twice.
        {
            int[] copyOfArray = new int[items.Length / 2];
            for (int i = 0; i < copyOfArray.Length; i++)
            {
                copyOfArray[i] = items[i];
            }
            this.items = copyOfArray;
        }
        public void ShiftLeft(int index) //help us to rearrange the internal collection's elements after removing one.
        {
            for (int i = index; i < this.Counter - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        public void ShiftRight(int index)
        {
            for (int i = this.Counter; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }
        public void Insert(int index, int item)
        {
            if (index >= this.Counter)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.Items.Length == Counter)
            {
                this.Resize();
            }
            this.ShiftRight(index);
            this.items[index] = item;
            this.Counter++;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < this.Counter; i++)
            {
                if (this.items[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || this.Counter <= secondIndex)
            {
                throw new ArgumentOutOfRangeException();
            }
            int copyOfFirstIndexItem = this.items[firstIndex];
            int copyOfSecondIndexItem = this.items[secondIndex];
            this.items[firstIndex] = copyOfSecondIndexItem;
            this.items[secondIndex] = copyOfFirstIndexItem;
        }

        public void ForEachPrint(Action<int> action)
        {
            for (int i = 0; i < Counter; i++)
            {
                int currElement = this.items[i];
                action(currElement);
            }
        }
    }
}
