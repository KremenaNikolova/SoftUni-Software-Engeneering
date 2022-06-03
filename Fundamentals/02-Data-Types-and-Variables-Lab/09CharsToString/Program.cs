using System;

namespace _09CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());


            Console.WriteLine($"{one.ToString()}{two.ToString()}{three.ToString()}");
        }
    }
}
