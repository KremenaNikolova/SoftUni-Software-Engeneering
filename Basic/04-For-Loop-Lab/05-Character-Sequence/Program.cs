using System;

namespace _05_Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine(word[i]);
            }
        }
    }
}
