using System;

namespace _08._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());

            double shoes = tax - (tax * 0.4);
            double clothes = shoes - (shoes * 0.2);
            double ball = clothes * 1 / 4;
            double accessories = ball * 1 / 5;
            double endPrice = tax + shoes + clothes + ball + accessories;

            Console.WriteLine(endPrice);

        }
    }
}