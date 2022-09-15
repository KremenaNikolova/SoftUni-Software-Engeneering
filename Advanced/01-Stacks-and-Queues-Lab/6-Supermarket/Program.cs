using System;
using System.Collections.Generic;

namespace _6_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();
            while (input!="End")
            {
                if (input == "Paid")
                {
                    while (queue.Count>0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    input = Console.ReadLine();
                    continue;
                }
                queue.Enqueue(input);
                input = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
