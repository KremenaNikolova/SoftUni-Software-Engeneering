using System;

namespace _07._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            //• Брой пилешки менюта – цяло число в интервала[0 … 99]
            //•	Брой менюта с риба – цяло число в интервала[0 … 99]
            //•	Брой вегетариански менюта – цяло число в интервала[0 … 99]

            int chikens = int.Parse(Console.ReadLine());
            int fishes = int.Parse(Console.ReadLine());
            int vegeterians = int.Parse(Console.ReadLine());
            double endPrice = (chikens * 10.35) + (fishes * 12.40) + (vegeterians * 8.15);
            double desert = endPrice * 0.2;
            double all = endPrice + desert + 2.50;

            Console.WriteLine(all);


        }
    }
}

//•	Пилешко меню –  10.35 лв. 
//•	Меню с риба – 12.40 лв. 
//•	Вегетарианско меню  – 8.15 лв

//Напишете програма, която изчислява колко ще струва на група хора да си поръчат храна за вкъщи.

//Групата ще си поръча и десерт, чиято цена е равна на 20% от общата сметка (без доставката). 
//Цената на доставка е 2.50 лв и се начислява най-накрая.  
