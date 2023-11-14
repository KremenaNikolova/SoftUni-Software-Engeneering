using System;

namespace _05_Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 0; i <= tabs; i++)
            {
                string name = Console.ReadLine();

                switch (name)
                {
                    case "Facebook":
                        salary -= 150;
                        break;

                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
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
