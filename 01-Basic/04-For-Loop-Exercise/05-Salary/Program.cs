using System;

namespace _05_Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Брой отворени табове в браузъра n -цяло число в интервала[1...10]
            int tabs = int.Parse(Console.ReadLine());
            //Заплата - число в интервала[500...1500]
            double salary = double.Parse(Console.ReadLine());
         
            for (int i = 0; i <=tabs; i++)
            {
                string name = Console.ReadLine();

                switch (name)
                {
                    case "Facebook":
                        salary = salary - 150;
                        break;
                        
                    case "Instagram":
                        salary = salary - 100;
                        break;
                    case "Reddit":
                        salary = salary - 50;
                        break;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine($"{salary}");
            }
        }
    }
}
//"Facebook " -> 150 лв.
//"Instagram"-> 100 лв.
//"Reddit"-> 50 лв.
