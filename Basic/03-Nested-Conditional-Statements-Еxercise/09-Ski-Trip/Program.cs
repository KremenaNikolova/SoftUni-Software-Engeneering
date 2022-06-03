using System;

namespace _09_Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Входът се чете от конзолата и се състои от три реда:
            //•	Първи ред -дни за престой -цяло число в интервала[0...365]
            int days = int.Parse(Console.ReadLine());
            //•	Втори ред -вид помещение - "room for one person-18lv", "apartment-25lv" или "president apartment-35lv"
            string room = Console.ReadLine();
            //•	Трети ред -оценка - "positive"  или "negative"
            string vote = Console.ReadLine();
            double price = 0.0;

            // вид помещение          по - малко от 10 дни      между 10 и 15 дни        повече от 15 дни
            //room for one person     не ползва намаление       не ползва намаление      не ползва намаление
            //apartment               30 % от крайната цена     35 % от крайната цена    50 % от крайната цена
            //president apartment     10 % от крайната цена     15 % от крайната цена    20 % от крайната цена

            if(room== "room for one person")
            {
                price = (days-1) * 18;
            }
            else if(room== "apartment")
            {
                price = (days-1) * 25;
                if (days < 10)
                {
                    price = price - price * 0.3;
                }
                else if (days>=10 && days < 15)
                {
                    price = price - price * 0.35;
                }
                else if (days >= 15)
                {
                    price -= price * 0.5;
                }
            }
            else if(room== "president apartment")
            {
                price = (days-1) * 35;
                if (days < 10)
                {
                    price = price - price * 0.1;
                }
                else if (days >= 10 && days < 15)
                {
                    price = price - price * 0.15;
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
