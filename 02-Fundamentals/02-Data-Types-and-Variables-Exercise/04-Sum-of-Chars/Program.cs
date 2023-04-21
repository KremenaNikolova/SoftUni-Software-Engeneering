using System;

namespace _04_Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            
            int sumOfChars = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                char ofAlphabet = char.Parse(Console.ReadLine());
                int ofChar = (int)ofAlphabet;
                sumOfChars += ofChar;

            }
            Console.WriteLine($"The sum equals: {sumOfChars}");



        }
    }
}
