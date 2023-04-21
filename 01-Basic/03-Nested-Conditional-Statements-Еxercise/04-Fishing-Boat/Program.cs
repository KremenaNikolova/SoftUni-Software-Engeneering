using System;

namespace _04_Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {


            //• Бюджет на групата – цяло число в интервала[1…8000]
            int budged = int.Parse(Console.ReadLine());
            //•	Сезон –  текст: "Spring"-3000, "Summer"-4200, "Autumn"-4200, "Winter-2600"
            string season = Console.ReadLine();
            //•	Брой рибари – цяло число в интервала[4…18]
            int fishers = int.Parse(Console.ReadLine());
            double price = 0;
            int rent = 0;

            //Рибарите ползват допълнително 5% отстъпка, ако са четен брой освен ако не е есен - тогава нямат допълнителна отстъпка, която се начислява след като се приспадне отстъпката по горните критерии.
            //Напишете програма, която да пресмята дали рибарите ще съберат достатъчно пари. 

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }
            //В зависимост от броя си групата ползва отстъпка:
            // до 6 човека включително  –  отстъпка от 10 %.
            // от 7 до 11 човека включително  –  отстъпка от 15 %.
            // от 12 нагоре  –  отстъпка от 25 %.
            if (fishers <= 6)
            {
                price = price - price * 0.1;
            }
            else if (fishers>7 && fishers <= 11)
            {
                price = price - price * 0.15;
            }
            else if (fishers >= 12)
            {
                price = price - price * 0.25;
            }
            if(fishers%2==0 && season != "Autumn")
            {
                price = price - price * 0.05;
            }

            if (budged >= price)
            {
                Console.WriteLine($"Yes! You have {(budged-price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(price-budged):f2} leva.");
            }
        }
    }
}
//Да се отпечата на конзолата един ред:
//•	Ако бюджетът е достатъчен:
//"Yes! You have {останалите пари} leva left."
//•	Ако бюджетът НЕ Е достатъчен:
//"Not enough money! You need {сумата, която не достига} leva."
