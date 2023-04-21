using System;

namespace _03_Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());

            FirstToEndChar(firstChar, endChar);


        }

        static void FirstToEndChar(char firstChar, char endChar)
        {
            int startChar=Math.Min(firstChar, endChar);
            int lastChar=Math.Max(firstChar, endChar);
            if (startChar>lastChar)
            {
                Console.WriteLine($"{endChar} {firstChar}");
                return;
            }
            for (int i = startChar + 1; i < lastChar; i++)
            {
                char everyNextChar = (char)i;
                Console.Write(everyNextChar + " ");
            }
        }
    }
}
