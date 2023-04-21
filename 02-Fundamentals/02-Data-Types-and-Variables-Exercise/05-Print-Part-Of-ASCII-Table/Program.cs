using System;

namespace _05_Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i <= endNumber; i++)
            {
                char symbolOfAscii = (char)i;
                Console.Write(symbolOfAscii + " ");
            }
        }
    }
}
