using System;

namespace _06._Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int liter = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double lastPrice = (nylon + 2) * 1.50 + (paint + (paint*0.1)) * 14.50 + 
                (liter * 5) + 0.40;

            double maistor = (lastPrice * 30 / 100) * hours;

            double last = lastPrice + maistor;

            Console.WriteLine(last);

            
        }
    }
}
