using System;
using System.Text;

namespace _03_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string finalWordResult = Console.ReadLine();

            while (finalWordResult.Contains(wordToRemove))
            {
                finalWordResult = finalWordResult.Replace(wordToRemove, string.Empty);
            }

            Console.WriteLine(finalWordResult);

        }
    }
}
