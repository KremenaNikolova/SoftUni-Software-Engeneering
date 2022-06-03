using System;

namespace _03.Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Да се напише програма, която чете час и минути от 24-часово денонощие,въведени от потребителя
            //и изчислява колко ще е часът след 15 минути.
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


//Резултатът да се отпечата във формат часове:минути.
//Часовете винаги са между 0 и 23, а минутите винаги са между 0 и 59.
//Часовете се изписват с една или две цифри.
//Минутите се изписват винаги с по две цифри, с водеща нула, когато е необходимо. 