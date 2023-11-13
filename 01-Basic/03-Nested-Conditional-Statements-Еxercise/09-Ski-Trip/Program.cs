using System;

namespace _09_Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string vote = Console.ReadLine();
            double price = 0.0;

            if (room == "room for one person")
            {
                price = (days - 1) * 18;
            }
            else if (room == "apartment")
            {
                price = (days - 1) * 25;
                if (days < 10)
                {
                    price -= price * 0.3;
                }
                else if (days >= 10 && days < 15)
                {
                    price -= price * 0.35;
                }
                else if (days >= 15)
                {
                    price -= price * 0.5;
                }
            }
            else if (room == "president apartment")
            {
                price = (days - 1) * 35;
                if (days < 10)
                {
                    price -= price * 0.1;
                }
                else if (days >= 10 && days < 15)
                {
                    price -= price * 0.15;
                }
                else if (days >= 15)
                {
                    price -= price * 0.2;
                }
            }
            switch (vote)
            {
                case "positive":
                    price += price * 0.25;
                    break;
                case "negative":
                    price -= price * 0.1;
                    break;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
