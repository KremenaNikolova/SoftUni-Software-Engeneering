using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>
            {
                { "pear", new HashSet<char>() },
                { "flour",new HashSet<char>() },
                { "pork",new HashSet<char>() },
                { "olive", new HashSet<char>() },
            };

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();

                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        word.Value.Add(vowel);
                    }

                    if (word.Key.Contains(consonant))
                    {
                        word.Value.Add(consonant);
                    }

                }
                vowels.Enqueue(vowel);
            }

            Dictionary<string, HashSet<char>> foundWords = new Dictionary<string, HashSet<char>>(words.Where(x => x.Value.Count == x.Key.Length));

            Console.WriteLine($"Words found: {foundWords.Count()}{Environment.NewLine}{string.Join(Environment.NewLine, foundWords.Keys)}");
        }
    }
}
