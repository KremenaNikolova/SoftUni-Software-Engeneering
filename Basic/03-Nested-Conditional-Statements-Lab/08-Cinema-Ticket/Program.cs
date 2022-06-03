using System;

namespace _08_Cinema_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Да се напише програма която чете ден от седмицата (текст) – въведен от потребителя и принтира на конзолата цената на билет за кино според деня от седмицата:

            string day = Console.ReadLine();
            double price = 0;

            switch (day)
            {
                case "Monday":
                    price = 12;
                    break;
                case "Tuesday":
                    price = 12;
                    break;
                case "Wednesday":
                    price = 14;
                    break;
                case "Thursday":
                    price = 14;
                    break;
                case "Friday":
                    price = 12;
                    break;
                case "Saturday":
                    price = 16;
                    break;
                case "Sunday":
                    price = 16;
                    break;

            }
            Console.WriteLine($"{price}");
        }
    }
}
