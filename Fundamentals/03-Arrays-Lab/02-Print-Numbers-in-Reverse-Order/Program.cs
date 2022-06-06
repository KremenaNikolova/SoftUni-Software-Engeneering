using System;

namespace _02_Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            int[] numberOfArray = new int[numberOfNumbers];
            //int nextNumber;

            for (int i = 0; i < numberOfNumbers; i++)
            {
                numberOfArray[i] = int.Parse(Console.ReadLine());
            }
            for (int i = numberOfArray.Length-1; i >= 0; i--)
            {
                Console.Write($"{numberOfArray[i]} ");
            }
            //Array.Reverse(numberOfArray);
            //Console.WriteLine(numberOfArray);

        }
    }
}
