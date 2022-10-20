using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waters = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray());
            Stack<double> flours = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray());

            Dictionary<string, int> counter = new Dictionary<string, int>
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette", 0 },
                {"Bagel", 0 },
            };

            //Croissant – consists of 50% water and 50% flour
            //Muffin – consists of 40% water and 60% flour
            //Baguette – consists of 30% water and 70% flour
            //Bagel – consists of 20% water and 80% flour 

            while (waters.Count>0 && flours.Count>0)
            {
                double water = waters.Dequeue();
                double flour = flours.Pop();
                double calculatingWaterPercent = (water*100)/(water+flour);

                if (calculatingWaterPercent==50)
                {
                    counter["Croissant"]++;
                }
                else if (calculatingWaterPercent==40)
                {
                    counter["Muffin"]++;
                }
                else if (calculatingWaterPercent==30)
                {
                    counter["Baguette"]++;
                }
                else if (calculatingWaterPercent==20)
                {
                    counter["Bagel"]++;
                }
                else
                {
                    flour -= water;
                    flours.Push(flour);
                    counter["Croissant"]++;
                }
            }

            var sortedCounter = counter.Where(x=>x.Value>0).OrderByDescending(x=>x.Value).ThenBy(x=>x.Key);

            foreach (var item in sortedCounter)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            string watersLeft = waters.Count == 0 ? "None" : string.Join(", ",waters);
            string floursLeft = flours.Count == 0 ? "None" : string.Join(", ", flours);

            Console.WriteLine($"Water left: {watersLeft}");
            Console.WriteLine($"Flour left: {floursLeft}");
        }
    }
}
