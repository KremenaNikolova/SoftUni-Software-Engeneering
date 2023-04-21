using System;

namespace _02_Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string justWord = Console.ReadLine().ToLower();

            Console.WriteLine(FindTheVowels(justWord));

        }
        static int FindTheVowels(string justWord)
        {
            int counter = 0;
            for (int i = 0; i < justWord.Length; i++)
            {
                char[] vowels = justWord.ToCharArray();
                if ("aouei".Contains(vowels[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
