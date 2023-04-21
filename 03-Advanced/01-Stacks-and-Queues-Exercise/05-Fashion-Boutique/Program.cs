using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int originOfRackCapacity = rackCapacity;
            Stack<int> clothes = new Stack<int>(clothesInTheBox);
            int rackCounter = 1;

            while (clothes.Count>0)
            {
                int currBox = clothes.Pop();
                if (currBox<=rackCapacity)
                {
                    rackCapacity -= currBox;
                }
                else
                {
                    rackCounter++;
                    rackCapacity = originOfRackCapacity;
                    rackCapacity -= currBox;
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
