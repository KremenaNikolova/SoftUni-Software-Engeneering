using System;

namespace C34
{
    class Program
    {
        static void Main(string[] args)
        {
            int budjet = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());

            double SpringBoat = 3000;
            double SummerAutumnBoat = 4200;
            double WinterBoat = 2600;
            double discount = 0.00;
            double evendiscount = 0.05;
            double Price = 0.00;

            switch (season)
            {
                case "Spring":
                    if (fishers <= 6)
                    {
                        discount = SpringBoat * 0.1;
                        Price = SpringBoat - discount;
                    }
                    else if ((fishers > 6) && (fishers <= 11))
                    {
                        discount = SpringBoat * 0.15;
                        Price = SpringBoat - discount;
                    }
                    else if (fishers >= 12)
                    {
                        discount = SpringBoat * 0.25;
                        Price = SpringBoat - discount;
                    }
                    if (fishers % 2 == 0)
                    {
                        Price = Price - (Price * evendiscount);
                    }
                    break;
                case "Summer":
                    if (fishers <= 6)
                    {
                        discount = SummerAutumnBoat * 0.1;
                        Price = SummerAutumnBoat - discount;
                    }
                    else if ((fishers > 6) && (fishers <= 11))
                    {
                        discount = SummerAutumnBoat * 0.15;
                        Price = SummerAutumnBoat - discount;
                    }
                    else if (fishers >= 12)
                    {
                        discount = SummerAutumnBoat * 0.25;
                        Price = SummerAutumnBoat - discount;
                    }
                    if (fishers % 2 == 0)
                    {
                        Price = Price - (Price * evendiscount);
                    }
                    break;
                case "Autumn":
                    if (fishers <= 6)
                    {
                        discount = SummerAutumnBoat * 0.1;
                        Price = SummerAutumnBoat - discount;
                    }
                    else if ((fishers > 6) && (fishers <= 11))
                    {
                        discount = SummerAutumnBoat * 0.15;
                        Price = SummerAutumnBoat - discount;
                    }
                    else if (fishers >= 12)
                    {
                        discount = SummerAutumnBoat * 0.25;
                        Price = SummerAutumnBoat - discount;
                    }
                    break;
                case "Winter":
                    if (fishers <= 6)
                    {
                        discount = WinterBoat * 0.1;
                        Price = WinterBoat - discount;
                    }
                    else if ((fishers > 6) && (fishers <= 11))
                    {
                        discount = WinterBoat * 0.15;
                        Price = WinterBoat - discount;
                    }
                    else if (fishers >= 12)
                    {
                        discount = WinterBoat * 0.25;
                        Price = WinterBoat - discount;
                    }
                    if (fishers % 2 == 0)
                    {
                        Price = Price - (Price * evendiscount);
                    }
                    break;
            }
            if (budjet > Price)
            {
                double left = budjet - Price;
                Console.WriteLine($"Yes! You have {left:f2} leva left.");
            }
            else
            {
                double left = Price - budjet;
                Console.WriteLine($"Not enough money! You need {left:f2} leva.");
            }
        }
    }
}