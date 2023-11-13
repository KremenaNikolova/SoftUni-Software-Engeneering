using System;

namespace _06_Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double result = 0;

            if (symbol == "+" || symbol == "-" || symbol == "*")
            {
                switch (symbol)
                {
                    case "+":
                        result = n1 + n2;
                        break;
                    case "-":
                        result = n1 - n2;
                        break;
                    case "*":
                        result = n1 * n2;
                        break;
                }
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - odd");
                }
            }
            else if (symbol == "/" || symbol == "%")
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else if (symbol == "/")
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} {symbol} {n2} = {result:f2}");
                }
                else if (symbol == "%")
                {
                    result = n1 % n2;
                    Console.WriteLine($"{n1} {symbol} {n2} = {result}");
                }
            }
        }
    }
}