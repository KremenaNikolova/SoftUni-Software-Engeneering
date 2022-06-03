using System;

namespace _08TownInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfTheTown = Console.ReadLine();
            int population =int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {nameOfTheTown} has population of {population} and area {area} square km.");
        }
    }
}
