using System;
using System.Collections.Generic;

namespace _02_Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int start = 1;
            int end = 100;
            int counter = 0;
            int currBiggestNumber = start;

            while (counter<10)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number>currBiggestNumber && number<end)
                    {
                        currBiggestNumber = number;
                        numbers.Add(number);
                        counter++;
                    }
                    else
                    {
                        throw new ArgumentException($"Your number is not in range {currBiggestNumber} - 100!");
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Number!");
                }
                
                

            }
            

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
