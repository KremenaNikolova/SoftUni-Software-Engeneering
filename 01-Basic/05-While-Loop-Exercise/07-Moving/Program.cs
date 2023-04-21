using System;

namespace _07_Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int product = width * length * height;

            while (product > 0)
            {
                string boxes = Console.ReadLine();
                if (boxes != "Done")
                {
                    product -= int.Parse(boxes);
                    if (product < 0)
                    {
                        Console.WriteLine($"No more free space! You need {Math.Abs(product)} Cubic meters more.");
                    }
                }
                else
                {
                    Console.WriteLine($"{product} Cubic meters left.");
                    break;
                }
            }
        }
    }
}
