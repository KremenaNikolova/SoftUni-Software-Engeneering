using System;

namespace _04_Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            for (int i = input.Length-1; i >= 0; i--)
            {
                Console.Write($"{input[i]} ");
            }


        }
    }
}
