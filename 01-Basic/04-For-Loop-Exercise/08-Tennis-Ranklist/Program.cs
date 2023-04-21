using System;

namespace _08_Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            //            От конзолата първо се четат два реда:
            //•	Брой турнири, в които е участвал – цяло число в интервала[1…20] 
            int numTournament = int.Parse(Console.ReadLine());
            //•	Начален брой точки в ранглистата - цяло число в интервала[1...4000]
            int numPoints = int.Parse(Console.ReadLine());
            int totalPoints = 0;
            double wins = 0;

            for (int i = 1; i <= numTournament; i++)
            {
                //За всеки турнир се прочита отделен ред:
                //•	Достигнат етап от турнира – текст – "W", "F" или "SF"
                string stage = Console.ReadLine();

                switch (stage)
                {
                    //	W - ако е победител получава 2000 точки
                    case "W":
                        totalPoints = totalPoints + 2000;
                        wins = wins + 1;
                        break;
                    //	F - ако е финалист получава 1200 точки
                    case "F":
                        totalPoints = totalPoints + 1200;
                        break;
                    //	SF - ако е полуфиналист получава 720 точки
                    case "SF":
                        totalPoints = totalPoints + 720;
                        break;
                }

            }
            totalPoints = numPoints + totalPoints;
            double average = (totalPoints -numPoints) / numTournament;
            wins = (wins / numTournament) * 100;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {average}");
            Console.WriteLine($"{wins:f2}%");

//                       Отпечатват се три реда в следния формат:
//           •	"Final points: {брой точки след изиграните турнири}"
//           •	"Average points: {средно колко точки печели за турнир}"
//           •	"{процент спечелени турнири}%"




            //Напишете програма, която изчислява колко ще са точките на Григор след изиграване на всички турнири, като знаете с колко точки стартира сезона.Също изчислете колко точки средно печели от всички изиграни турнири и колко процента от турнирите е спечелил.

        }
    }
}
