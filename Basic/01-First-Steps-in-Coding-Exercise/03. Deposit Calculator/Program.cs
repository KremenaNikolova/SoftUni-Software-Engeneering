using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposite = double.Parse(Console.ReadLine());
            int termDeposite = int.Parse(Console.ReadLine());
            double divident = double.Parse(Console.ReadLine());
            double dividentPercent = divident / 100;
            double sumEnd = deposite + termDeposite * ((deposite * dividentPercent) / 12);

            Console.WriteLine(sumEnd);
        }
    }
}



