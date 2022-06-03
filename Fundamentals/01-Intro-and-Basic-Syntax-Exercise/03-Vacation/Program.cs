using System;

namespace _03_Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            switch (typeOfPeople)
            {
                case "Students":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = 8.45;
                            break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;
                        default:
                            break;
                    }
                    totalPrice = countOfPeople * price;
                    if (countOfPeople>=30)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;
                case "Business":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = 10.90;
                            break;
                        case "Saturday":
                            price = 15.60;
                            break;
                        case "Sunday":
                            price = 16;
                            break;
                        default:
                            break;
                    }
                    if (countOfPeople>=100)
                    {
                        countOfPeople -= 10;
                        totalPrice = countOfPeople * price;
                    }
                    else
                    {
                        totalPrice = countOfPeople * price;
                    }
                    break;
                case "Regular":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = 15;
                            break;
                        case "Saturday":
                            price = 20;
                            break;
                        case "Sunday":
                            price = 22.50;
                            break;
                        default:
                            break;
                    }
                    totalPrice = countOfPeople * price;
                    if (countOfPeople>=10 && countOfPeople<=20)
                    {
                        totalPrice -= totalPrice * 0.05;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
