using System;

namespace _04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVacation = double.Parse(Console.ReadLine());
            int numPuzzles = int.Parse(Console.ReadLine());
            int numDolls = int.Parse(Console.ReadLine());
            int numBears = int.Parse(Console.ReadLine());
            int numMinions = int.Parse(Console.ReadLine());
            int numTrucks = int.Parse(Console.ReadLine());

            double totalNum = numBears + numDolls + numMinions + numPuzzles + numTrucks;
            double totalPrice = numBears * 4.10 + numDolls * 3 + numMinions * 8.2 + numPuzzles * 2.6 + numTrucks * 2;

            if (totalNum >= 50)
            {
                totalPrice -= (totalPrice * 0.25);
            }

            double rent = totalPrice * 0.1;

            double totalEnd = totalPrice - rent - priceVacation;

            if (totalEnd >= 0)
            {
                Console.WriteLine($"Yes! {totalEnd:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(totalEnd):f2} lv needed.");
            }

        }
    }
}
