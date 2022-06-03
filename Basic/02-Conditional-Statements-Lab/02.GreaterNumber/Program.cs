using System;

namespace _02.GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            if(numberOne > numberTwo)
            {
                Console.WriteLine($"{numberOne}");
            }
            else
            {
                Console.WriteLine($"{numberTwo}");
            }
        }
    }
}
//Да се напише програма, която чете две цели числа въведени от
//потребителя и отпечатва по-голямото от двете