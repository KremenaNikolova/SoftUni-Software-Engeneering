using System;

namespace _01_Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine().Split();
            //int num = int.Parse(Console.ReadLine());

            Random shuffleNumbers = new Random();

            for (int i = 0; i < inputWords.Length; i++)
            {
                int randomIndex = shuffleNumbers.Next(0, inputWords.Length);

                string word = inputWords[i];

                inputWords[i] = inputWords[randomIndex];
                inputWords[randomIndex] = word;
            }

            foreach (var item in inputWords)
            {
                Console.WriteLine(item);
            }

        }
    }
    
}
