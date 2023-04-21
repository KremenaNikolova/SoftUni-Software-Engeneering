using System;

namespace _11RefactorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double Lenght, Width, Height = 0;

            Console.Write("Length: ");
            double lenght = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());

            double volume = (lenght * width * height) / 3;

            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
