using System;
using System.Collections.Generic;

namespace _7_Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            int count = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(kids);
            int counter = 0;

            while (queue.Count>1)
            {
                counter++;
                string firstKid = queue.Dequeue();
                if (counter==count)
                {
                    counter = 0;
                    Console.WriteLine($"Removed {firstKid}");
                    continue;
                }
                queue.Enqueue(firstKid);
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
