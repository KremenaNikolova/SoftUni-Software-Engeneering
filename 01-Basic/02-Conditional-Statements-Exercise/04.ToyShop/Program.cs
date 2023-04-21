using System;

namespace _04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Цена на екскурзията -реално число в интервала[1.00 … 10000.00]
            double priceVacation = double.Parse(Console.ReadLine());
            //2.Брой пъзели - цяло число в интервала[0… 1000]
            int numPuzzles = int.Parse(Console.ReadLine());
            //3.Брой говорещи кукли -цяло число в интервала[0 … 1000]
            int numDolls = int.Parse(Console.ReadLine());
            //4.Брой плюшени мечета -цяло число в интервала[0 … 1000]
            int numBears = int.Parse(Console.ReadLine());
            //5.Брой миньони - цяло число в интервала[0 … 1000]
            int numMinions = int.Parse(Console.ReadLine());
            //6.Брой камиончета - цяло число в интервала[0 … 1000]
            int numTrucks = int.Parse(Console.ReadLine());

            double totalNum = numBears + numDolls + numMinions + numPuzzles + numTrucks;
            double totalPrice = numBears*4.10 + numDolls*3 + numMinions*8.2 + numPuzzles*2.6 + numTrucks*2;

            if (totalNum >= 50)
            {
                totalPrice = totalPrice - (totalPrice * 0.25);
            }

            double naem = totalPrice * 0.1;

            double totalEnd = totalPrice - naem - priceVacation;

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
