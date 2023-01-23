using System;

namespace _09._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double vollume = lenght * width * height;
            double liters = vollume / 1000;
            double endLiters = liters * (1 - percent / 100);

            Console.WriteLine(endLiters);

        }
    }
}