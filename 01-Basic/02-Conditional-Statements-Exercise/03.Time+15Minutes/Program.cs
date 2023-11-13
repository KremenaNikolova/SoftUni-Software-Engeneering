using System;

namespace _03.Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int totalInMinutes = hours * 60 + minutes + 15;
            int totalInHours = totalInMinutes / 60;
            int endMinutes = totalInMinutes % 60;

            if (totalInHours == 24)
            {
                totalInHours = 0;
            }
            if (endMinutes < 10)
            {
                Console.WriteLine($"{totalInHours}:0{endMinutes}");
            }
            
            else
            {
                Console.WriteLine($"{totalInHours}:{endMinutes}");
            }
        }
    }
}