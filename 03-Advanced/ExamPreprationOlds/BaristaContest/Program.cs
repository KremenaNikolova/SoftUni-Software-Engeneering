using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cofees = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] milks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> cofeesStack = new Stack<int>(cofees.Reverse());
            Stack<int> milksStack = new Stack<int>(milks);

            Dictionary<string, int> prepareDrinks = new Dictionary<string, int>();


            while (cofeesStack.Count > 0 && milksStack.Count > 0)
            {
                int cofeeQuantity = cofeesStack.Pop();
                int milkQuantity = milksStack.Pop();
                int sumMilkPlusCofees = cofeeQuantity + milkQuantity;

                switch (sumMilkPlusCofees)
                {
                    case 50:
                        if (!prepareDrinks.ContainsKey("Cortado"))
                        {
                            prepareDrinks.Add("Cortado", 0);
                        }
                        prepareDrinks["Cortado"]++;
                        break;
                    case 75:
                        if (!prepareDrinks.ContainsKey("Espresso"))
                        {
                            prepareDrinks.Add("Espresso", 0);
                        }
                        prepareDrinks["Espresso"]++;
                        break;
                    case 100:
                        if (!prepareDrinks.ContainsKey("Capuccino"))
                        {
                            prepareDrinks.Add("Capuccino", 0);
                        }
                        prepareDrinks["Capuccino"]++;
                        break;
                    case 150:
                        if (!prepareDrinks.ContainsKey("Americano"))
                        {
                            prepareDrinks.Add("Americano", 0);
                        }
                        prepareDrinks["Americano"]++;
                        break;
                    case 200:
                        if (!prepareDrinks.ContainsKey("Latte"))
                        {
                            prepareDrinks.Add("Latte", 0);
                        }
                        prepareDrinks["Latte"]++;
                        break;
                    default:
                        milksStack.Push(milkQuantity - 5);
                        break;
                }
            }

            if (cofeesStack.Count == 0 && milksStack.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (cofeesStack.Count == 0)
            {
                Console.WriteLine($"Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", cofeesStack)}");
            }
            if (milksStack.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ",milksStack)}");
            }
            var sortedDrinks = prepareDrinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToList();
            foreach (var drink in sortedDrinks)
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
