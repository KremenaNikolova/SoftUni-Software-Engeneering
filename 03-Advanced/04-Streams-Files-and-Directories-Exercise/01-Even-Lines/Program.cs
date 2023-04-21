//Write a program that reads a text file (e. g. text.txt) and prints on the console its even lines. Line numbers start from 0. Use StreamReader. Before you print the result, replace {'-', ', ', '. ', '! ', '? '} with '@' and reverse the order of the words

namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder text = new StringBuilder();
            int counter = 0;
            char[] replacer = new char[] { '-', ',', '.', '!', '?' };
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = String.Empty;
                
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 == 0)
                    {
                        foreach (var symbol in replacer)
                        {
                            line = line.Replace(symbol, '@');
                        }
                        string[] evenLine = line.Split().Reverse().ToArray();
                        text.AppendLine(string.Join(" ", evenLine));
                        
                    }
                    counter++;
                }
            }
            return text.ToString();
        }
    }
}
