using System;

namespace _06_Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTriples = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTriples; i++)
            {
                char firstChar = (char)('a' + i);
               
                for (int j = 0; j < numberOfTriples; j++)
                {
                    char secondChar = (char)('a' + j);
                    for (int k = 0; k < numberOfTriples ; k++)
                    {
                        char thirdChar = (char)('a' + k);
                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
