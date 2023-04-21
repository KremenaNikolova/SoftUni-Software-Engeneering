using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.AddFirst("Kremena");
            list.AddFirst("Valerieva");
            list.AddLast("Nikolova");

            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
