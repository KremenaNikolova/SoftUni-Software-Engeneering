using System;

namespace _07_Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            //Входът се чете от конзолата и съдържа точно 2 реда, въведени от потребителя:
            //•	На първия ред е месецът – May, June, July, August, September или October
            string month = Console.ReadLine();
            //•	На втория ред е броят на нощувките – цяло число в интервала[0... 200]
            int numNights = int.Parse(Console.ReadLine());
            double priceStuido = 0.0;
            double priceApartment = 0.0;

            //•	За студио, при повече от 7 нощувки през май и октомври: 5 % намаление.
            //•	За студио, при повече от 14 нощувки през май и октомври: 30 % намаление.
            //•	За студио, при повече от 14 нощувки през юни и септември: 20 % намаление.
            //•	За апартамент, при повече от 14 нощувки, без значение от месеца : 10 % намаление.

            //       Май и октомври          Юни и септември          Юли и август
            //       Студио – 50 лв          Студио – 75.20 лв.       Студио – 76 лв./ нощувка
            //       Апартамент – 65 лв.     Апартамент – 68.70 лв.   Апартамент – 77 лв./ нощувка

            switch (month)
            {
                case "May":
                case "October":
                    priceStuido = 50;
                    priceApartment = 65;
                    if (numNights > 14)
                    {
                        priceStuido = priceStuido - priceStuido * 0.3;
                        priceApartment = priceApartment - priceApartment * 0.1;
                    }
                    else if (14 > numNights && numNights > 7)
                    {
                        priceStuido = priceStuido - priceStuido * 0.05;
                    }
                    break;
                case "June":
                case "September":
                    priceStuido = 75.20;
                    priceApartment = 68.70;
                    if (numNights > 14)
                    {
                        priceStuido = priceStuido - priceStuido * 0.2;
                        priceApartment = priceApartment - priceApartment * 0.1;
                    }
                    break;
                case "July":
                case "August":
                    priceStuido = 76;
                    priceApartment = 77;
                    if (numNights > 14)
                    {
                        priceApartment = priceApartment - priceApartment * 0.1;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {numNights * priceApartment:f2} lv.");
            Console.WriteLine($"Studio: {numNights * priceStuido:f2} lv.");

        }
    }
}
//Да се отпечатат на конзолата 2 реда:
//•	На първия ред: “Apartment: { цена за целият престой}
//lv.”
//•	На втория ред: “Studio: { цена за целият престой}
//lv.“
//Цената за целия престой форматирана с точност до два знака след десетичната запетая.

