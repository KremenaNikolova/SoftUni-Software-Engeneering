using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] order = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(order);
            int biggestOrder = queue.Max();
            Console.WriteLine(biggestOrder);

            while (queue.Count>0)
            {
                if (queue.Peek() <=quantityFood)
                {
                    quantityFood -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
           
        }
    }
}
