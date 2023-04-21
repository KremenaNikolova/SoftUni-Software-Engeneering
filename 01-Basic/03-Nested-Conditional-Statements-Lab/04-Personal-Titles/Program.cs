using System;

namespace _04_Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (age >= 16)
            {
                switch (gender)
                {
                    case "f":
                        Console.WriteLine("Ms.");
                        break;
                    case "m":
                        Console.WriteLine("Mr.");
                        break;
                }                    
            }
            else
            {
                switch (gender)
                {
                    case "f":
                        Console.WriteLine("Miss");
                        break;
                    case "m":
                        Console.WriteLine("Master");
                        break;
                }
            }
        }
    }
}
