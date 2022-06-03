using System;

namespace _05_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine()); //1 do 6000

            //да се провери всяко число в диапазона 1111 до 8888 дали се дели с num%==0;

            for (int i = 1; i <=9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            if (num % i == 0 && num % j == 0 && num % k == 0 && num % l == 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }

        }
    }
}
