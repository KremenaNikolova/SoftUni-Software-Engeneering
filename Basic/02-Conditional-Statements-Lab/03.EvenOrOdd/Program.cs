using System;

namespace _03.EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}

//Да се напише програма, която чете цяло число, въведено от потребителя,
//и печата дали е четно или нечетно. 
//Ако е четно отпечатайте "even", ако е нечетно "odd".
