using System;

namespace _01_Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            string book = "";
            int counter = 0;

            while (book!= "No More Books" || book != favoriteBook)
            {
               
                book = Console.ReadLine();

                if (book == favoriteBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                else if (book=="No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
                counter++;
            }
        }
    }
}
