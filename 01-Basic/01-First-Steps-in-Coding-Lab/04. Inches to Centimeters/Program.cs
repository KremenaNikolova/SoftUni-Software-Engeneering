using System;

namespace FirstLab08012022
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = 2.54;
            double summ = a * b;

            Console.WriteLine($"{summ} cm");
        }
    }
}