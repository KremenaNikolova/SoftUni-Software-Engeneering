using System;
using System.Text;

namespace _04_Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var word in input)
            {
                string replacableWord = new string('*', word.Length);

                text = text.Replace(word, replacableWord);
            }

            Console.WriteLine(text);
        }
    }
}
