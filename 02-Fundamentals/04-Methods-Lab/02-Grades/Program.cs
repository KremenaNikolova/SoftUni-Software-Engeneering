using System;

namespace _02_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            PrintInWords(grade);
        }

        static void PrintInWords(double grade)
        {
            if (grade>=2 && grade<3)
            {
                Console.WriteLine("Fail");
            }
            else if (grade>=3 && grade < 3.50)
            {
                Console.WriteLine("Poor");
            }
            else if (grade>=3.5 && grade <4.50)
            {
                Console.WriteLine("Good");
            }
            else if (grade>=4.5 && grade<5.50)
            {
                Console.WriteLine("Very good");
            }
            else if (grade>=5.50 && grade<=6)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
