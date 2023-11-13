using System;

namespace _01_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            double income = 0.0;

            if (projection == "Premiere")
            {
                income = row * column * 12;
            }
            else if (projection == "Normal")
            {
                income = row * column * 7.50;
            }
            else if (projection == "Discount")
            {
                income = row * column * 5.00;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
