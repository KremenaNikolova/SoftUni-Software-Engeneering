//Write a program that reads a text file (e. g. text.txt) and inserts line numbers in front of each of its lines and count all the letters and punctuation marks. The result should be written to another text file (e. g. output.txt). Use the static class File to read and write all the lines of the input and output files.

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                int letterCount = lines[i].Count(ch => char.IsLetter(ch));
                int punctuatuionCount = lines[i].Count(ch => char.IsPunctuation(ch));

                sb.AppendLine($"Line {i + 1}: -{lines[i]} ({letterCount})({punctuatuionCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }

    }
}
