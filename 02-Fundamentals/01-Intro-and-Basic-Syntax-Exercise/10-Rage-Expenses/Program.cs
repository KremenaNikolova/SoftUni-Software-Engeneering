using System;

namespace _10_Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());

            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            int headsetTrashes = 0;
            int mouseTrashes = 0;
            int keyboardTrashes = 0;
            int displayTrashes = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headsetTrashes++;
                }

                if (i % 3 == 0)
                {
                    mouseTrashes++;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardTrashes++;

                    if (keyboardTrashes % 2 == 0)
                    {
                        displayTrashes++;
                    }
                }
            }

            decimal totalCost = headsetTrashes * headsetPrice + mouseTrashes * mousePrice + keyboardTrashes * keyboardPrice + displayTrashes * displayPrice;

            Console.WriteLine($"Rage expenses: {totalCost:f2} lv.");
        }
    }
}
