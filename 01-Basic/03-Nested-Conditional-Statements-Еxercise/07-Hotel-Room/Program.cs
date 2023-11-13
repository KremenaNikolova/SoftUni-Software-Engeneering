using System;

namespace _07_Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numNights = int.Parse(Console.ReadLine());
            double priceStuido = 0.0;
            double priceApartment = 0.0;

            switch (month)
            {
                case "May":
                case "October":
                    priceStuido = 50;
                    priceApartment = 65;
                    if (numNights > 14)
                    {
                        priceStuido -= priceStuido * 0.3;
                        priceApartment -= priceApartment * 0.1;
                    }
                    else if (14 > numNights && numNights > 7)
                    {
                        priceStuido -= priceStuido * 0.05;
                    }
                    break;
                case "June":
                case "September":
                    priceStuido = 75.20;
                    priceApartment = 68.70;
                    if (numNights > 14)
                    {
                        priceStuido -= priceStuido * 0.2;
                        priceApartment -= priceApartment * 0.1;
                    }
                    break;
                case "July":
                case "August":
                    priceStuido = 76;
                    priceApartment = 77;
                    if (numNights > 14)
                    {
                        priceApartment -= priceApartment * 0.1;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {numNights * priceApartment:f2} lv.");
            Console.WriteLine($"Studio: {numNights * priceStuido:f2} lv.");

        }
    }
}

