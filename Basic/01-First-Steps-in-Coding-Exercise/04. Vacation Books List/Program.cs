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

//1.Брой страници в текущата книга – цяло число в интервала [1…1000]
//2.Страници, които прочита за 1 час – цяло число в интервала [1…1000]
//3.Броят на дните, за които трябва да прочете книгата – цяло число в интервала [1…1000]

//opredelen broi knigi joro
//колко часа на ден трябва да отделя, за да прочете необходимата литература.

//Да се отпечата на конзолата броят часове, които Жоро трябва да отделя за четене всеки ден.
