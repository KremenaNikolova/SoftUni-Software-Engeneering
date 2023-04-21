using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string emojisPattern = @"(:{2}|\*{2})([A-Z][a-z]{2,})\1";

            string input = Console.ReadLine();
            int coolThreshold = 1;

            for (int i = 0; i < input.Length; i++)
            {
                char charr = input[i];
                if (char.IsDigit(charr))
                {
                    int digit = int.Parse(charr.ToString());

                    //Console.WriteLine($"{coolThreshold} * {digit} = {coolThreshold * digit}");
                    coolThreshold *= digit;
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");

            MatchCollection matches = Regex.Matches(input, emojisPattern);
            int counter = 0;
            List<string> specialEmojis = new List<string>();
            foreach (var match in matches)
            {
                string matchToString = match.ToString();
                int specialSum = 0;
                counter++;
                for (int i = 0; i < matchToString.Length; i++)
                {
                    char isLetter = matchToString[i];
                    
                    if (char.IsLetter(isLetter))
                    {
                        specialSum += (int)isLetter;
                    }

                }
                if (specialSum >= coolThreshold)
                {
                    specialEmojis.Add(matchToString);
                }
            }

            Console.WriteLine($"{counter} emojis found in the text. The cool ones are:");

            foreach (var emoji in specialEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
