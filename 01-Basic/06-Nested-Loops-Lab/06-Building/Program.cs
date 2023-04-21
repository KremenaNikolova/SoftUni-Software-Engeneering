using System;

namespace _06_Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int stage = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = stage; i > 0; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i == stage)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if (i % 2 == 0 && i!=stage)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{j} ");
                    }
                    //Console.Write($"{i}{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
