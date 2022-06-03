using System;

namespace _03._Deposit_Calculator
{
    //Вход Изход	Обяснения
    //200           1. Изчисляваме натрупаната лихва: 200 * 0.057(5.7 %) = 11.40 лв.
    //3             2.Изчисляваме лихвата за 1 месец: 11.40 лв. / 12 месеца = 0.95 лв.
    //5.7	202.85	3.Общата сума е: 200 лв. + 3 * 0.95 лв. = 202.85 лв.          

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

//сума ще получите в края на депозитния период при определен лихвен процент
//сума = депозирана сума  + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12)

////От конзолата се четат 3 реда:
//1.Депозирана сума – реално число в интервала [100.00 … 10000.00]
//2.Срок на депозита(в месеци) – цяло число в интервала [1…12]
//3.Годишен лихвен процент – реално число в интервала [0.00 …100.00]



