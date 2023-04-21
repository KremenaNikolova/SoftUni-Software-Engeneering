using System;
using System.Collections.Generic;

namespace _03_Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            int numWords = int.Parse(Console.ReadLine());
            int counter = 0;

            while (counter<numWords)
            {
                string inputKey = Console.ReadLine();
                string inputValue = Console.ReadLine();

                //List<string> synonymsListValue = new List<string>();
                if (!synonyms.ContainsKey(inputKey))
                {
                    //synonymsListValue.Add(inputValue);
                    synonyms.Add(inputKey, new List<string>());
                    synonyms[inputKey].Add(inputValue);
                }
                else
                {
                    synonyms[inputKey].Add(inputValue);
                }
                counter++;
            }

            foreach (var item in synonyms)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
