using System;

namespace _04_Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine()); //1
            int end = int.Parse(Console.ReadLine()); //2
            int magicNum = int.Parse(Console.ReadLine()); //22
            int counter = 0;

            for (int i = start; i <= end; i++) //1; 1; 1+1
            {                
                for (int j = start; j<= end; j++) //1; 1;
                {
                    counter++;
                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNum})");
                        return;
                    }
                    
                }
                
            }
            Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
        }
    }
}
