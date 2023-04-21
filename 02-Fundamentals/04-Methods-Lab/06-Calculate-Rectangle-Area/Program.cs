using System;

namespace _06_Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = (PrintTheArea(width, height));

            Console.WriteLine(area);

        }
        static double PrintTheArea(double width, double height)
        {
            return width * height;
        }

    }
}
