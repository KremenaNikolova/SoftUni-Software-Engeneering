using System;

namespace _06_Number_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            //Да се напише програма, която проверява дали въведеното от потребителя число е в интервала [-100, 100] и е различно от 0 и извежда "Yes", ако отговаря на условията, или "No" ако е извън тях.

            double num = double.Parse(Console.ReadLine());

            if(num<=100 && num >= -100 && num!=0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
