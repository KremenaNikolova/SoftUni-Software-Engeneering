using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double needMoneyforVacation = double.Parse(Console.ReadLine());
            double moneyWeGot = double.Parse(Console.ReadLine());
            int days = 0;
            int spendingDays = 0;

            while (spendingDays < 5)
            {
                string saveOrSpend = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

               if (saveOrSpend == "spend")
                {
                    moneyWeGot = moneyWeGot - money;
                    if (moneyWeGot<0)
                    {
                        moneyWeGot = 0;
                    }
                    spendingDays++;
                }
                else if(saveOrSpend == "save")
                {
                    moneyWeGot += money;
                    spendingDays = 0;
                }

                days++;
                if (needMoneyforVacation <= moneyWeGot)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    break;
                }
            }
            if (spendingDays >= 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{days}");
            }                
        }
    }
}
