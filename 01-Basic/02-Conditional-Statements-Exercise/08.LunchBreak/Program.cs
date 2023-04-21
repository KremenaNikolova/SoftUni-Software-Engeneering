using System;

namespace _08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Име на сериал – текст
            string name = Console.ReadLine();
            //2.Продължителност на епизод  – цяло число в диапазона[10… 90]
            int time = int.Parse(Console.ReadLine());
            //3.Продължителност на почивката  – цяло число в диапазона[10… 120]
            int rest = int.Parse(Console.ReadLine());

            //Времето за обяд ще бъде 1/8 от времето за почивка,
            double timeLunch = rest * 1.0 / 8;
            //а времето за отдих ще бъде 1/4 от времето за почивка. 
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

            //•	Ако времето е достатъчно да изгледате епизода:
            //"You have enough time to watch {име на сериал} and left with {останало време} minutes free time."
            //•	Ако времето не Ви е достатъчно:
            //"You don't have enough time to watch {име на сериал}, you need {нужно време} more minutes."


        }
    }
}
