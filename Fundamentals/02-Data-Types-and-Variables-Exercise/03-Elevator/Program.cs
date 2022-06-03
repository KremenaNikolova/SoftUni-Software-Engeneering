using System;

namespace _03_Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeole = int.Parse(Console.ReadLine());
            int capacityOfTheElevator = int.Parse(Console.ReadLine());

            double neededCoursesWithElevator = (double)numberOfPeole / capacityOfTheElevator;

            Console.WriteLine(Math.Ceiling(neededCoursesWithElevator));
        }
    }
}
