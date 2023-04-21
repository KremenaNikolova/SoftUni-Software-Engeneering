using System;

namespace _07._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
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
