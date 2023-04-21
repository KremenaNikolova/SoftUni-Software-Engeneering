using System;

namespace _01_Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numberOfTheDay = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", };

            int number = int.Parse(Console.ReadLine());

            if (number>=1 && number<=7)
            {
                Console.WriteLine(numberOfTheDay[number-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");   
            }
        }
    }
}
