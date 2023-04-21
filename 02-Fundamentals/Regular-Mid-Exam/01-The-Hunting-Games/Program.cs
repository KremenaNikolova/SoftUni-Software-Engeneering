using System;

namespace _01_The_Hunting_Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players  = int.Parse(Console.ReadLine());
            double totalEnergy = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());

            double totalWater = days * players  * food;
            double totalFood = days * players  * water;

            double loseEnergy = 0;

            int waterDay = 0;
            int foodDay = 0;

            for (int i = 1; i <= days; i++)
            {
                loseEnergy = double.Parse(Console.ReadLine());
                totalEnergy = totalEnergy - loseEnergy;

                if (totalEnergy <= 0.0)
                {
                    break;
                }
                waterDay++;
                foodDay++;

                if (waterDay == 2)
                {
                    totalEnergy = totalEnergy + (totalEnergy * 0.05);
                    totalWater = totalWater - (totalWater * 0.3);
                    waterDay = 0;
                }


                if (foodDay == 3)
                {
                    totalFood = totalFood - (totalFood / players );
                    totalEnergy = totalEnergy + (totalEnergy * 0.1);
                    foodDay = 0;
                }

            }
            if (totalEnergy <= 0)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {totalEnergy:f2} energy!");
            }

        }
    }
}