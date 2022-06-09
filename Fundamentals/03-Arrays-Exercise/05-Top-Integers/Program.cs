using System;
using System.Linq;

namespace _05_Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] justNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < justNumbers.Length; i++)
            {
                bool isTheBiggest = true;
                for (int j = i+1; j < justNumbers.Length; j++)
                {
                    if (justNumbers[i] <= justNumbers[j])
                    {
                        isTheBiggest = false;
                        break;
                    }
                   
                }
                if (isTheBiggest)
                {
                    Console.Write(justNumbers[i] + " ");
                }
            }
        }
    }
}
