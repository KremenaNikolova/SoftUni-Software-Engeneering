using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _16_Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([:]{2}|[*]{2})([A-Z][a-z]{2,})\1";

            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> emojis = new List<string>();

            int coolThreshold = 1;
            for (int i = 0; i < text.Length; i++)
            {
                char charr = text[i];
                if (char.IsDigit(charr))
                {
                    int num = int.Parse(charr.ToString());
                    coolThreshold*= num;
                }
            }
            int counterEmojis = 0;
            foreach (var match in matches)
            {
                string str = match.ToString();
                int result = 0;
                for (int i = 2; i < str.Length-2; i++)
                {
                    char charr = str[i];
                    result += charr;
                }
                if (result>coolThreshold)
                {
                    emojis.Add(str);
                }
                counterEmojis++;
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{counterEmojis} emojis found in the text. The cool ones are:");
            foreach (var emoji in emojis)
            {
                Console.WriteLine(emoji);
            }
            
        }
    }
}
