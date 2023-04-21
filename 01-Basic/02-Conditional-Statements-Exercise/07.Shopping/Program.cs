using System;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Бюджетът на Петър -реално число в интервала[0.0…100000.0]
            double budged = double.Parse(Console.ReadLine());
            //2.Броят видеокарти - цяло число в интервала[0…100]
            int n = int.Parse(Console.ReadLine());
            //3.Броят процесори - цяло число в интервала[0…100]
            int m = int.Parse(Console.ReadLine());
            //4.Броят рам памет -цяло число в интервала[0…100]
            int p = int.Parse(Console.ReadLine());

            //•	Видеокарта – 250 лв./бр.
            int nLev = n * 250;
            //•	Процесор – 35 % от цената на закупените видеокарти/ бр.
            double mLev = nLev * 0.35;
            double mCost = m * mLev;
            //•	Рам памет – 10 % от цената на закупените видеокарти/ бр.
            double pLev = nLev * 0.1;
            double pCost = p * pLev;

            double endCost = nLev + mCost + pCost;

            //. Ако броя на видеокартите е по-голям от този на процесорите получава 15% отстъпка от крайната сметка
            if (n > m)
            {
                endCost = endCost - (endCost * 0.15);
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

//•	Ако бюджета е достатъчен:
//"You have {остатъчен бюджет} leva left!"
//•	Ако сумата надхвърля бюджета:
//"Not enough money! You need {нужна сума} leva more!"
//Резултатът да се форматира до втория знак след десетичната запетая.

