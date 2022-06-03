using System;

namespace _06_Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string film = Console.ReadLine();
            double freeSpots = double.Parse(Console.ReadLine());
            double allTickets = 0;
            double allTicketsCurrentFilm = 0;
            double student = 0;
            double standard = 0;
            double kid = 0;

            while (film != "Finish")
            {
                allTicketsCurrentFilm = 0;
                for (int i = 0; i < freeSpots; i++)
                {
                    string ticket = Console.ReadLine();                    
                    if (ticket == "End")
                    {
                        break;
                    }
                    else if (ticket == "student")
                    {
                        student++;
                    }
                    else if (ticket == "standard")
                    {
                        standard++;
                    }
                    else if (ticket == "kid")
                    {
                        kid++;
                    }
                    allTicketsCurrentFilm++;
                    allTickets++;
                }
                if (freeSpots == allTicketsCurrentFilm)
                {
                    Console.WriteLine($"{film} - 100.00% full.");
                }
                else
                {
                    Console.WriteLine($"{film} - {allTicketsCurrentFilm/(freeSpots*0.01):f2}% full.");
                }

                film = Console.ReadLine();
                if (film == "Finish")
                {
                    Console.WriteLine($"Total tickets: {allTickets}");
                    Console.WriteLine($"{student / (allTickets/100):f2}% student tickets.");
                    Console.WriteLine($"{standard / (allTickets / 100):f2}% standard tickets.");
                    Console.WriteLine($"{kid / (allTickets / 100):f2}% kids tickets.");
                    return;
                }
                freeSpots = int.Parse(Console.ReadLine());
            }
        }
    }
}
