using System;
using System.Collections.Generic;

namespace _02_Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int counter = 10;
            int currBiggestNumber = 1;
            for (int i = 0 ; i != counter;)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (currBiggestNumber >= input || input>99)
                    {
                        throw new ArgumentException($"Your number is not in range {input} - 100!");
                    }
                    currBiggestNumber=input;
                    numbers.Add(input);
                    counter--;
                    
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch(Exception) 
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
