using System;

namespace _06_Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int product = width * length;

            while (product > 0)
            {
                string dropCake = (Console.ReadLine());
                if (dropCake != "STOP")
                {
                    product -= int.Parse(dropCake);
                    if (product < 0)
                    {
                        Console.WriteLine($"No more cake left! You need {Math.Abs(product)} pieces more.");
                    }
                }
                else
                {
                    Console.WriteLine($"{product} pieces are left.");
                    break;
                }
            }
        }
    }
}
