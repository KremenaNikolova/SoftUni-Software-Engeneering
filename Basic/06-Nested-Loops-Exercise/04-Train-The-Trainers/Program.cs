using System;

namespace _04_Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            double sumEvaluation=0;
            double allsumEvaluation = 0;
            int counter = 0;
            //int numPresentation = 0;

            while (presentation != "Finish")
            {
                //numPresentation++;
                sumEvaluation = 0;
                for (int i = 1; i <= jury; i++)
                {
                 double evaluation = double.Parse(Console.ReadLine());
                    sumEvaluation += evaluation;
                    counter++;
                }
                allsumEvaluation += sumEvaluation;
                Console.WriteLine($"{presentation} - {sumEvaluation/jury:f2}.");
                presentation = Console.ReadLine();
                if (presentation == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {allsumEvaluation/counter:f2}.");
                }
            }
            
            
        }
    }
}
