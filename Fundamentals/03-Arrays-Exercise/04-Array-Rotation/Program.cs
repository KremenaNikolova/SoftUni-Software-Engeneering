using System;
using System.Linq;

namespace _04_Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersInArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                int firstNumber = numbersInArray[0];
                for (int j = 0; j < numbersInArray.Length-1; j++)
                {
                    numbersInArray[j] = numbersInArray[j + 1];
                }
                numbersInArray[numbersInArray.Length - 1] = firstNumber;
            }
            Console.WriteLine(String.Join(" ", numbersInArray));

        }
    }
}
