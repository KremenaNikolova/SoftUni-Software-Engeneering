using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steels = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> carbons = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> swordsCounter = new Dictionary<string, int>
            {
                {"Broadsword", 0},
                {"Gladius", 0},
                {"Katana", 0},
                {"Sabre", 0},
                {"Shamshir", 0},
            };

            //Gladius 70
            //Shamshir 80
            //Katana 90
            //Sabre	110
            //Broadsword 150


            while (steels.Count>0 && carbons.Count>0)
            {
                int steel = steels.Dequeue();
                int carbon = carbons.Pop();
                int sumSteelCarbon = steel + carbon;
                switch (sumSteelCarbon)
                {
                    case 70:
                        swordsCounter["Gladius"]++;
                        break;
                    case 80:
                        swordsCounter["Shamshir"]++;
                        break;
                    case 90:
                        swordsCounter["Katana"]++;
                        break;
                    case 110:
                        swordsCounter["Sabre"]++;
                            break;
                    case 150:
                        swordsCounter["Broadsword"]++;
                        break;
                    default:
                        carbons.Push(carbon + 5);
                        break;
                }

            }

            int createdSwords = swordsCounter.Sum(x => x.Value);

            var forgedSwords = createdSwords == 0 ? "You did not have enough resources to forge a sword." : $"You have forged {createdSwords} swords.";
            var steelsLeft = steels.Count == 0 ? "none" : string.Join(", ",steels);
            var carbonLeft = carbons.Count == 0 ? "none" : string.Join(", ",carbons);

            Console.WriteLine(forgedSwords);
            Console.WriteLine($"Steel left: {steelsLeft}");
            Console.WriteLine($"Carbon left: {carbonLeft}");

            foreach (var sword in swordsCounter.Where(x=>x.Value>0))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }


        }
    }
}
