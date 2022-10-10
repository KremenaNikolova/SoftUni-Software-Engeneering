using System;

namespace GenericBoxofInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                box.List.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(box);
        }
    }
}
