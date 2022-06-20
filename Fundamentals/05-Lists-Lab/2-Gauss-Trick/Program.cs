using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();
            int originalInputLenght = input.Count;


            for (int i = 0; i < originalInputLenght / 2; i++)
            {
                input[i] = input[i] + input[input.Count-1];
                input.RemoveAt(input.Count-1);
            }
            Console.WriteLine(string.Join(" ", input));


        }
    }
}
