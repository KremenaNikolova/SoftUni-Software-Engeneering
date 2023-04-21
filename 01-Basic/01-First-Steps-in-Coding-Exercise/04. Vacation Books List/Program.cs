using System;

namespace _04._Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int readPerHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int hoursPerBook = pages / readPerHours;
            int result = hoursPerBook / days;

            Console.WriteLine(result);
        }
    }
}
