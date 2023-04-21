//void AddFirst(int element) – adds an element at the beginning of the collection
//void AddLast(int element) – adds an element at the end of the collection
//int RemoveFirst() – removes the element at the beginning of the collection
//int RemoveLast() – removes the element at the end of the collection
//void ForEach() – goes through the collection and executes a given action
//int[] ToArray() – returns the collection as an array

using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    internal class DoublyLinkedList //it's head + tail + operations
    {
        private class ListNode //its value + next node + previous node
        {

            private ListNode head;
            private ListNode tail;

            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public ListNode(int value)
            {
                this.Value = value;
            }
            public int Count { get; set; }

            public void AddFirst(int value)
            {
                if (this.Count == 0)
                {
                    this.head = this.tail = new ListNode(value);
                }
                else
                {
                    ListNode newHead = new ListNode(value); //създаваме нов лист
                    newHead.NextNode = this.head; //запазваме стойността на хийда
                    this.head.PreviousNode = newHead; //
                    this.head = newHead;
                }
                this.Count++;
            }

            public void AddLast(int value)
            {
                if (this.Count == 0)
                {
                    this.tail = this.head = new ListNode(value);
                }
                else
                {
                    ListNode newTail = new ListNode(value);
                    newTail.NextNode = this.tail;
                    this.tail.PreviousNode = newTail;
                    this.tail = newTail;
                }
                this.Count++;
            }

            public int RemoveFirst()
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("The list is empty");
                }

                int firstElement = this.head.Value;
                this.head = this.head.NextNode;
                if (this.head!=null)
                {
                    this.head.PreviousNode = null;
                }
                else
                {
                    this.tail=null;
                }
                this.Count--;
                return firstElement;

            }

            public int RemoveLast()
            {
                if (this.Count==0)
                {
                    throw new InvalidOperationException("The list is empty");
                }
                int lastElement = this.tail.Value;
                this.tail=this.tail.PreviousNode;
                if (this.tail!=null)
                {
                    this.tail.NextNode = null;
                }
                else
                {
                    this.head = null;
                }
                this.Count--;
                return lastElement;
            }

            public void ForEach(Action<int> action)
            {
                var currNode = this.head;
                while (currNode!=null)
                {
                    action(currNode.Value);
                    currNode = currNode.NextNode;
                }
            }

            public int[] ToArray()
            {
                int[] array = new int[this.Count]; //count is contains number of list
                int counter = 0;
                ListNode currNode = this.head;
                while (currNode!=null)
                {
                    array[counter] = currNode.Value;
                    currNode=currNode.NextNode;
                    counter++;
                }
                return array;
            }
        }







        

    }
}
