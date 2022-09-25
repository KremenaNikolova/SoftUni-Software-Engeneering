//Write a program that reads a list of words from a given file (e. g. words.txt) and finds how many times each of the words occurs in another file (e. g. text.txt). Matching should be case-insensitive. The result should be written to an output text file (e. g. output.txt). Sort the words by frequency in descending order.
using System;
using System.IO;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";


            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader words = new StreamReader(wordsFilePath))
            {
                string[] input = words.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                using (StreamReader text = new StreamReader(textFilePath))
                {
                    char[] separators = { ' ', '.', ',', '-', '?', '!', };
                    string[] checkText = text.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    using (StreamWriter output = new StreamWriter(outputFilePath))
                    {
                        foreach (var word in input)
                        {
                            int counter = 0;
                            foreach (var check in checkText)
                            {
                                if (word == check)
                                {
                                    counter++;
                                }
                            }
                            if (counter>0)
                            {
                                output.WriteLine($"{word} - {counter}");
                            }
                        }
                    }


                }
            }
        }
    }
}

