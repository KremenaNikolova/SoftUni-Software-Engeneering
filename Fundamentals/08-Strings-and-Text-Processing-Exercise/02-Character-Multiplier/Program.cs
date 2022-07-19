using System;
using System.Text;

namespace _02_Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string firstWord = input[0];
            string secondWord = input[1];

            Console.WriteLine(SumOfTwoWords(firstWord, secondWord)); 


        }

        public static int SumOfTwoWords(string str1, string str2)
        {
            int sum = 0;

            string shortest = string.Empty;
            string longest = string.Empty;

            if (str1.Length>str2.Length)
            {
                longest = str1;
                shortest = str2;
            }
            else
            {
                longest = str2;
                shortest = str1;
            }

            for (int i = shortest.Length-1; i >= 0 ; i--)
            {
                sum += longest[i] * shortest[i];
            }
            for (int i = longest.Length-1; i >= shortest.Length; i--)
            {
                sum += longest[i];
            }

            return sum;
        }
    }
}
