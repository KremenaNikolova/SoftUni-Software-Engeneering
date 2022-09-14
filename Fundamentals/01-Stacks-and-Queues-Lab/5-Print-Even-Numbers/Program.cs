using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 ==0)
                {
                    queue.Enqueue(input[i]);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
