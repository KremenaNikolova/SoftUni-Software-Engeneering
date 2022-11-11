using System;

namespace _04_Sum_of_Integers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string currElement = input[i];
                int number;
                try
                {
                    number = int.Parse(currElement);
                    sum += number;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{currElement}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{currElement}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{currElement}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");

        }

    }
}
