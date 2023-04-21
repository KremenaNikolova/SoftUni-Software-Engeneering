using System;

namespace _04_Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int stepen = 0; stepen <=n; stepen++)
            {
                if (stepen % 2 == 0)
                {
                    Console.WriteLine(Math.Pow(2, stepen));
                }
            }
        }
    }
}
