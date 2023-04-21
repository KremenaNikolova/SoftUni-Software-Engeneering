using System;

namespace _02_Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowEvaluation = int.Parse(Console.ReadLine());
            string lastName = "";
            string end = "";
            int counter = 0;
            int counterEvaluation=0;
            double sum = 0;

            while (end!="Enough")
            {
                string nameExam = Console.ReadLine();

                if (nameExam == "Enough")
                {
                    Console.WriteLine($"Average score: {sum / counterEvaluation:f2}");
                    Console.WriteLine($"Number of problems: {counterEvaluation}");
                    Console.WriteLine($"Last problem: {lastName}");
                    break;
                }
                lastName = nameExam;
                double evaluation = double.Parse(Console.ReadLine());
                sum += evaluation;
                counterEvaluation++;
                if (evaluation <= 4)
                {
                    counter++;
                    if (counter == lowEvaluation)
                    {
                        Console.WriteLine($"You need a break, {counter} poor grades.");
                        break;
                    }
                }
                
            }
        }
    }
}
