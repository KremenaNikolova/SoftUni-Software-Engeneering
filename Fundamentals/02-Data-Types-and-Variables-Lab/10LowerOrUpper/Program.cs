using System;

namespace _10LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char justChar = char.Parse(Console.ReadLine());

            if (Char.IsUpper(justChar))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
