using System;

namespace _01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] numberOfPeoleOnEachWagon = new int[numberOfWagons];

            int sumNumberOfPeople = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                numberOfPeoleOnEachWagon[i] = int.Parse(Console.ReadLine());

                sumNumberOfPeople += numberOfPeoleOnEachWagon[i];
            }
            for (int j = 0; j < numberOfPeoleOnEachWagon.Length; j++)
            {
                Console.Write(numberOfPeoleOnEachWagon[j] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sumNumberOfPeople);
        }
    }
}
