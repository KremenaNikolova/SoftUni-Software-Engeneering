using System;

namespace _04_Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heighOfPyramid = int.Parse(Console.ReadLine());

            for (int i = 1; i <= heighOfPyramid; i++)
            {
                PrintThePyramid(1, i);
            }
            for (int i = heighOfPyramid-1; i >= 1; i--)
            {
                PrintThePyramid(1, i);
            }
            
        }

        static void PrintThePyramid(int start, int end)
        {
            for (int i=start; i <= end; i++)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }
      
       

    }
}

