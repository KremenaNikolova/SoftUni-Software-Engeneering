using System;
using System.Linq;

namespace _07_Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] justRandomNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;
            int maxCounting = 0;
            int start = 0;

            for (int searching = 0; searching < justRandomNumbers.Length-1; searching++)
            {
                if (justRandomNumbers[searching] == justRandomNumbers[searching+1])
                {
                    counter++;
                    if (counter>maxCounting)
                    {
                        maxCounting = counter;
                        start = searching - counter;
                    } 
                }
                else
                {
                    counter = 0;
                }
            }
            for (int i = start+1; i <= start+maxCounting+1; i++)
            {
                Console.Write(justRandomNumbers[i] + " ");
            }
        }
    }
}
