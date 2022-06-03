using System;

namespace _05_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double recieve = 100*double.Parse(Console.ReadLine());
            int counter = 0;


            while (recieve>0)
            {
                if (recieve >= 200)
                {
                    counter++;
                    recieve -= 200;
                }
                else if (recieve >= 100)
                {
                    counter++;
                    recieve -= 100;
                }
                else if (recieve >= 50)
                {
                    counter++;
                    recieve -= 50;
                }
                else if (recieve >= 20)
                {
                    counter++;
                    recieve -= 20;
                }
                else if (recieve >= 10)
                {
                    counter++;
                    recieve -= 10;
                }
                else if (recieve >= 5)
                {
                    counter++;
                    recieve -= 5;
                }
                else if (recieve >= 2)
                {
                    counter++;
                    recieve -= 2;
                }
                else if (recieve >= 1)
                {
                    counter++;
                    recieve -= 1;
                }
                else
                {
                    recieve = 0;
                }
            }
            Console.WriteLine(counter);


        }
    }
}
