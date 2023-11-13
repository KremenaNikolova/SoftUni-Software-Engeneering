using System;

namespace _08_On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minutesExam = int.Parse(Console.ReadLine());
            int incomHour = int.Parse(Console.ReadLine());
            int incomMin = int.Parse(Console.ReadLine());
            int hours = 0;
            int minutes = 0;
            int end = 0;

            int hourInMinExam = hourExam * 60;
            int allMinExam = minutesExam + hourInMinExam;

            int incomHourInMin = incomHour * 60;
            int allMinIncom = incomHourInMin + incomMin;

            if (allMinIncom > allMinExam)
            {
                Console.WriteLine("Late");
                end = allMinIncom - allMinExam;
                if (end <60)
                {
                    Console.WriteLine($"{end} minutes after the start");
                }
                else
                {
                    hours = (allMinIncom - allMinExam) / 60;
                    minutes = (allMinIncom - allMinExam) % 60;
                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hours}:0{minutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hours}:{minutes} hours after the start");
                    }
                   
                }
            }
            end = allMinExam - allMinIncom;
            if(allMinIncom == allMinExam || end<=30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{end} minutes before the start");
            }
            else if (end > 30)
            {
                Console.WriteLine("Early");
                if(end>30 && end < 60)
                {
                    Console.WriteLine($"{end} minutes before the start");
                }
                else
                {
                    hours = end / 60;
                    minutes = end % 60;
                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hours}:0{minutes} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hours}:{minutes} hours before the start");
                    }
                    
                }
                
            }

        }
    }
}
