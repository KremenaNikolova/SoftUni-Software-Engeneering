using System;

namespace _05_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            //Бюджет, реално число в интервала[10.00...5000.00].
            double budged = double.Parse(Console.ReadLine());
            //„summer” или “winter
            string season = Console.ReadLine();
            double cost = 0.0;
            string destination = "";
            string hotelOrCamp = "";
            //•	При 100лв.или по-малко – някъде в България
            //o	Лято – 30% от бюджета
            //o	Зима – 70% от бюджета
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
            //•	При 1000лв. или по малко – някъде на Балканите
            //o	Лято – 40% от бюджета
            //o	Зима – 80% от бюджета
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
            //•	При повече от 1000лв. – някъде из Европа
            //o	При пътуване из Европа, независимо от сезона ще похарчи 90% от бюджета.
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

//На конзолата трябва да се отпечатат два реда.
//•	Първи ред – „Somewhere in [дестинация]“ измежду “Bulgaria ", "Balkans” и ”Europe”
//•	Втори ред – “{Вид почивка} – { Похарчена сума}“


//Напишете програма, която да приема на входа бюджета и сезона, а на изхода да изкарва, къде ще почива програмиста и колко ще похарчи.

//Ако е лято ще почива на къмпинг
//Ако езимата в хотел
//Ако е в Европа, независимо от сезона ще почива в хотел
//Всеки къмпинг или хотел, според дестинацията, има собствена цена която отговаря на даден процент от бюджета:
