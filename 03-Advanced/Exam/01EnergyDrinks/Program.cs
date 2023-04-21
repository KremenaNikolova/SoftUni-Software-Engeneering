using System;
using System.Collections.Generic;
using System.Linq;

namespace _01EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> energiDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int maxCaffeine = 0;

            while (caffeine.Count>0 && energiDrinks.Count>0)
            {
                int coffee = caffeine.Pop();
                int energyDrink = energiDrinks.Dequeue();
                int multiply = coffee * energyDrink;

                if (multiply+ maxCaffeine <= 300)
                {
                    maxCaffeine += multiply;
                }
                else
                {
                    energiDrinks.Enqueue(energyDrink);
                    maxCaffeine -= 30;
                    if (maxCaffeine < 0) maxCaffeine = 0;
                }
            }

            var printDrinks = energiDrinks.Count == 0 ? "At least Stamat wasn't exceeding the maximum caffeine." : $"Drinks left: {string.Join(", ", energiDrinks)}";
            Console.WriteLine(printDrinks);
            Console.WriteLine($"Stamat is going to sleep with {maxCaffeine} mg caffeine.");
        }
    }
}
