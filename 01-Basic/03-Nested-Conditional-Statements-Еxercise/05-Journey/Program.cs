using System;

namespace _05_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double cost = 0.0;
            string destination = "";
            string hotelOrCamp = "";

            if (budged <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        hotelOrCamp = "Camp";
                        cost = budged * 0.3;
                        break;
                    case "winter":
                        hotelOrCamp = "Hotel";
                        cost = budged * 0.7;
                        break;
                }
            }
            else if (budged <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        hotelOrCamp = "Camp";
                        cost = budged * 0.4;
                        break;
                    case "winter":
                        hotelOrCamp = "Hotel";
                        cost = budged * 0.8;
                        break;
                }
            }
            else if (budged > 1000)
            {
                destination = "Europe";
                switch (season)
                {
                    case "summer":
                    case "winter":
                        hotelOrCamp = "Hotel";
                        cost = budged * 0.9;
                        break;
                }
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{hotelOrCamp} - {cost:f2}");
        }
    }
}
