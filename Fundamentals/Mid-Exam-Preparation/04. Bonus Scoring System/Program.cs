using System;

namespace _04._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents=int.Parse(Console.ReadLine());
            int numberOfLecture=int.Parse(Console.ReadLine());
            int bonus=int.Parse(Console.ReadLine());

            double totalBonus = 0;
            double maxBonus = 0;
            double maxAttendance = 0;

            for (int i = 0; i < numberOfStudents; i++)
            {
                double attendanceEachStudent = int.Parse(Console.ReadLine());

                totalBonus = attendanceEachStudent / numberOfLecture * (5 + bonus);
                if (totalBonus>maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendance = attendanceEachStudent;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {Math.Ceiling(maxAttendance)} lectures.");

        }
    }
}
