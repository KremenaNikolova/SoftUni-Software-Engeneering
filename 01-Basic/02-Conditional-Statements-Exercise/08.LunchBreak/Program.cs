using System;

namespace _08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int time = int.Parse(Console.ReadLine());
            int rest = int.Parse(Console.ReadLine());

            double timeLunch = rest * 1.0 / 8;
            double relaxTime = rest * 1.0 / 4;

            double endTime = rest - timeLunch - relaxTime;

            if (endTime >= time)
            {
                double timeLeft = endTime-time;
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(timeLeft)} minutes free time.");
            }
            else
            {
                double needTime = time-endTime;
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(needTime)} more minutes.");
            }

        }
    }
}
