using System;

namespace _08_Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
          
            int examFailed = 0;
            double sum = 0;

            while (grade <= 12)
            {
                double evaluation = double.Parse(Console.ReadLine());
                if (evaluation < 4)
                {
                    examFailed++;
                    if (examFailed == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                    continue;
                }
                grade++;
                sum += evaluation;

            }

            if (grade == 13)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sum / 12:f2}");
            }

        }
    }
}
