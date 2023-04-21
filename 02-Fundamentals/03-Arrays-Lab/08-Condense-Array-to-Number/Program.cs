using System;
using System.Linq;

namespace _08_Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] randomDigits = Console.ReadLine().Split().Select(int.Parse).ToArray(); //10 15 20 25
            int[] sumOfEveryTwoDigits = new int[randomDigits.Length-1];   

            while (randomDigits.Length>1)
            {
                for (int i = 0; i < randomDigits.Length - 1; i++)
                {
                    sumOfEveryTwoDigits[i] = randomDigits[i] + randomDigits[i + 1]; //10+15 15+20 20+25

                    if (i == randomDigits.Length-2)
                    {
                        randomDigits= sumOfEveryTwoDigits;
                        sumOfEveryTwoDigits = new int[randomDigits.Length - 1];
                    }
                }
                
            }

            Console.WriteLine(randomDigits[0]);
            
        }
    }
}
