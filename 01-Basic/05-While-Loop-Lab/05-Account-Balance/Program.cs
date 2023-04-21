using System;

namespace _05_Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string moneyIvest = Console.ReadLine();

            double sum = 0;

            while (moneyIvest!="NoMoreMoney")
            {
                
                if (double.Parse(moneyIvest) < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {double.Parse(moneyIvest):f2}");
                sum += double.Parse(moneyIvest);
                moneyIvest = Console.ReadLine();

            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
