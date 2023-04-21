using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string regexPattern = @"\#{1}[A-z]{3,}\#{2}[A-z]{3,}\#{1}|\@{1}[A-z]{3,}\@{2}[A-z]{3,}\@{1}";
            //([@|#{1}])([A-Za-z]{3,})(\1)(\1)([A-Za-z]{3,})(\1)
            List<string> matchedWords = new List<string>();
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();

            MatchCollection matches = Regex.Matches(text, regexPattern);
            int wordsCounter = 0;

            foreach (var match in matches)
            {
                wordsCounter++;
                matchedWords.Add(match.ToString());
            }

            if (wordsCounter<=0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            Console.WriteLine($"{wordsCounter} word pairs found!");

            for (int i = 0; i < matchedWords.Count; i++)
            {
                string word = matchedWords[i];
                string firstHalf = string.Empty;
                string secondHalf = string.Empty;
                string reversedSecondHalf = string.Empty;

                for (int j = 1; j < word.Length/2-1; j++)
                {
                    firstHalf += word[j];
                    
                }
                for (int k = word.Length - 2; k >= word.Length / 2 +1; k--)
                {
                    secondHalf += word[k];
                }
                for (int l = secondHalf.Length-1; l >= 0; l--)
                {
                    reversedSecondHalf += secondHalf[l];
                }
                //Console.WriteLine(firstHalf);
                //Console.WriteLine(secondHalf);
                //Console.WriteLine(reversedSecondHalf);

                if (firstHalf== secondHalf)
                {
                    mirrorWords.Add(firstHalf, reversedSecondHalf); 
                }
            }
            List<string> final = new List<string>();

            if (mirrorWords.Count<=0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine("The mirror words are:");
            foreach (var mirrors in mirrorWords)
            {
                final.Add($"{mirrors.Key} <=> {mirrors.Value}");

            }

            Console.WriteLine(string.Join(", ", final));



        }
    }
}
