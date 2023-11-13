using System;

namespace _05.GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double perClothe = double.Parse(Console.ReadLine());
            double allClothes = statists * perClothe;

            double decor = budged * 0.1;
            double endCost = 0;

            if (statists > 150)
            {
                double discount = allClothes - (allClothes * 0.1);
                endCost = decor + discount;
            }
            else
            {
                endCost = decor + allClothes;
            }
            if (endCost > budged)
            {
                double difference = endCost - budged;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(difference):f2} leva more.");
            }
            else if (endCost <= budged)
            {
                double leftMoney = budged - endCost;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftMoney:f2} leva left.");
            }

        }
    }
}

