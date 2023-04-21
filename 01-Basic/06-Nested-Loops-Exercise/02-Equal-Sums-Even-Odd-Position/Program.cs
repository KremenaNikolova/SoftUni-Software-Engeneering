using System;

namespace _02_Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int oddNum;
            int evenNum;

            for (int i = num1; i <= num2; i++) //въртим от num1 всички възможни числа до num2
            {
                evenNum = 0;
                oddNum = 0;
                string number = i.ToString(); //превръщаме i във стринг
                for (int j = 0; j < number.Length; j++)//четем позициите на цифрите във стринга
                {
                    if (j % 2 == 0)
                    {
                        evenNum += number[j];
                    }
                    else
                    {
                        oddNum += number[j];
                    }
                   
                }
                if (evenNum == oddNum)
                {
                    Console.Write(number+" ");
                }
            }
        }
    }
}
