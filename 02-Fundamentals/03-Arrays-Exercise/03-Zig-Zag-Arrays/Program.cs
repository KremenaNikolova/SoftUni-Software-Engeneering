using System;
using System.Linq;

namespace _03_Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsBelow = int.Parse(Console.ReadLine());

            int[] zigZagNumberOne = new int[rowsBelow];
            int[] zigZagNumberTwo = new int[rowsBelow];

            for (int i = 0; i < rowsBelow; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i%2==0)
                {
                    zigZagNumberOne[i] = numbers[0];
                    zigZagNumberTwo[i] = numbers[1];
                }
                else
                {
                    zigZagNumberTwo[i] = numbers[0];
                    zigZagNumberOne[i] = numbers[1];
                }
            }

            Console.Write(String.Join(" ",zigZagNumberOne));
            Console.WriteLine();
            Console.Write(String.Join(" ",zigZagNumberTwo));
            
        }
    }
}
