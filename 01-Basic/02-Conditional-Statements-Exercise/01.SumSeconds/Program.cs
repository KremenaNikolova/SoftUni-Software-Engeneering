using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsFirst = int.Parse(Console.ReadLine());
            int secondsSecond = int.Parse(Console.ReadLine());
            int secondsThird = int.Parse(Console.ReadLine());

            int total = secondsFirst + secondsSecond + secondsThird;
            int minutes = total / 60;
            int seconds = total % 60;

            if (seconds <10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }

        }
    }
}