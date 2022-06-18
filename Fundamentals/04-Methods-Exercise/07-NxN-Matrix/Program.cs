using System;

namespace _07_NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            NxNMatrix(input);
        }

        private static void NxNMatrix(int input)
        {
            for (int rows = 1; rows <= input; rows++)
            {
                for (int col = 1; col <= input; col++)
                {
                    Console.Write(input + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
