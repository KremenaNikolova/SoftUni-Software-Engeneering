using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<int[]> vs = new Queue<int[]>();
            for (int i = 0; i < petrolPumps; i++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                vs.Enqueue(inputNumbers);
            }
            int startIndex = 0;

            while (true)
            {
                bool IsComplete = true;
                int totalLiters = 0;
                foreach (int[] item in vs)
                {
                    int liters = item[0];
                    int distance = item[1];
                    totalLiters += liters;
                    // 10 - 11
                    if (totalLiters - distance < 0)
                    {
                        startIndex++;
                        int[] currentPum = vs.Dequeue();
                        vs.Enqueue(currentPum);
                        IsComplete = false;
                        break;
                    }
                    totalLiters -= distance;
                }
                if (IsComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }


        }
    }
}