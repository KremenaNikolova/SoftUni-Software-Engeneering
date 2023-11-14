using System;

namespace _08_Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTournament = int.Parse(Console.ReadLine());
            int numPoints = int.Parse(Console.ReadLine());
            int totalPoints = 0;
            double wins = 0;

            for (int i = 1; i <= numTournament; i++)
            {
                string stage = Console.ReadLine();

                switch (stage)
                {
                    case "W":
                        totalPoints += 2000;
                        wins += 1;
                        break;
                    case "F":
                        totalPoints += 1200;
                        break;
                    case "SF":
                        totalPoints += 720;
                        break;
                }

            }
            totalPoints += totalPoints;
            double average = (totalPoints - numPoints) / numTournament;
            wins = (wins / numTournament) * 100;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {average}");
            Console.WriteLine($"{wins:f2}%");

        }
    }
}
