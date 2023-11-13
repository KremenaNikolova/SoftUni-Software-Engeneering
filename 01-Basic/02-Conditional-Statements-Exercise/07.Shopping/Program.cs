using System;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int nLev = n * 250;
            double mLev = nLev * 0.35;
            double mCost = m * mLev;
            double pLev = nLev * 0.1;
            double pCost = p * pLev;

            double endCost = nLev + mCost + pCost;

            if (n > m)
            {
                endCost -= (endCost * 0.15);
            }
            if (budged >= endCost)
            {
                double levaLeft = budged - endCost;
                Console.WriteLine($"You have {levaLeft:f2} leva left!");
            }
            else
            {
                double levaLeft = budged - endCost;
                Console.WriteLine($"Not enough money! You need {Math.Abs(levaLeft):f2} leva more!");
            }
        }
    }
}

