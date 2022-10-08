using System;

namespace CustomList_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(3);
            list.Add(25);
            list.Add(33);
            Console.WriteLine(list.Contains(66));
            list.RemoveAt(2);

            list.Insert(0, 55);

            list.Contains(1);
            list.Contains(55);

            list.Swap(0, 2);

            list.ForEachPrint(l => Console.Write(l + " "));
        }
    }
}
