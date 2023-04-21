using System;

namespace _08_On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //От конзолата се четат 4 цели числа(по едно на ред), въведени от потребителя:
            //•	Първият ред съдържа час на изпита – цяло число от 0 до 23.
            int hourExam = int.Parse(Console.ReadLine());
            //•	Вторият ред съдържа минута на изпита – цяло число от 0 до 59.
            int minutesExam = int.Parse(Console.ReadLine());
            //•	Третият ред съдържа час на пристигане – цяло число от 0 до 23.
            int incomHour = int.Parse(Console.ReadLine());
            //•	Четвъртият ред съдържа минута на пристигане – цяло число от 0 до 59.
            int incomMin = int.Parse(Console.ReadLine());
            int hours = 0;
            int minutes = 0;
            int end = 0;

            int hourInMinExam = hourExam * 60;
            int allMinExam = minutesExam + hourInMinExam;

            int incomHourInMin = incomHour * 60;
            int allMinIncom = incomHourInMin + incomMin;

            //•	“Late”, ако студентът пристига по-късно от часа на изпита.
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
            //•	“On time”, ако студентът пристига точно в часа на изпита или до 30 минути по-рано.
            end = allMinExam - allMinIncom;
            if(allMinIncom == allMinExam || end<=30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{end} minutes before the start");
            }
            //•	“Early”, ако студентът пристига повече от 30 минути преди часа на изпита.
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

            // Изход
            //На първият ред отпечатайте:                      
            
            //Ако студентът пристига с поне минута разлика от часа на изпита, отпечатайте на следващия ред:
            
            //“mm minutes after the start” за закъснение под час.
            //•	“hh: mm hours after the start” за закъснение от 1 час или повече.Минутите винаги печатайте с 2 цифри, например “1:03”.






        }
    }
}
