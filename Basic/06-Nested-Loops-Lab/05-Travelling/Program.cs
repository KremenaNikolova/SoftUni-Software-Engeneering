using System;

namespace _05_Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double saved = 0;
            
            while (destination != "End")
            {
                double totalSaved = 0;
                double cost = double.Parse(Console.ReadLine());
                while (cost > totalSaved)
                {
                    saved = double.Parse(Console.ReadLine());
                    totalSaved += saved;
                    if (totalSaved >= cost)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        continue;
                    }
                }                
                destination = Console.ReadLine();
            }
            return;
        }
    }
}
