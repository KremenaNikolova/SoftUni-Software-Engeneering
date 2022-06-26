using System;

namespace _01_The_Hunting_Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfTheAdventure = int.Parse(Console.ReadLine());
            int countOfThePlayers = int.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double waterPerDayForOnePerson = double.Parse(Console.ReadLine());
            double foodPerDayForOnePerson = double.Parse(Console.ReadLine());

            double totalWater = daysOfTheAdventure * countOfThePlayers * waterPerDayForOnePerson;
            double totalFood = daysOfTheAdventure * countOfThePlayers * foodPerDayForOnePerson;

            double loseEnergy = 0;

            int countWaterDays = 0;
            int countFoodDays = 0;

            for (int i = 1; i <= daysOfTheAdventure; i++)
            {
                loseEnergy = double.Parse(Console.ReadLine());
                groupsEnergy = groupsEnergy - loseEnergy;

                if (groupsEnergy <= 0.0)
                {
                    break;
                }
                countWaterDays++;
                countFoodDays++;

                if (countWaterDays == 2)
                {
                    groupsEnergy = groupsEnergy + (groupsEnergy * 0.05);
                    totalWater = totalWater - (totalWater * 0.3);
                    countWaterDays = 0;
                }


                if (countFoodDays == 3)
                {
                    totalFood = totalFood - (totalFood / countOfThePlayers);
                    groupsEnergy = groupsEnergy + (groupsEnergy * 0.1);
                    countFoodDays = 0;
                }

            }
            if (groupsEnergy <= 0)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupsEnergy:f2} energy!");
            }

        }
    }
}
