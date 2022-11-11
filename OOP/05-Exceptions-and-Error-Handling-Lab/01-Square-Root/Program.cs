using System;
using System.Data;

namespace _01_Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {


            try
            {
                double input = double.Parse(Console.ReadLine());
                if (input < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(input));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}