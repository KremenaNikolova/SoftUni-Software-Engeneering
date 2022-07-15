using System;
using System.Collections.Generic;

namespace _06_Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentInfo = new Dictionary<string, List<double>>();
            Dictionary<string, double> studentsAvarageGrade = new Dictionary<string, double>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!studentInfo.ContainsKey(studentName))
                {
                    studentInfo.Add(studentName, new List<double>());
                    studentsAvarageGrade.Add(studentName, 0);
                    studentInfo[studentName].Add(studentGrade);
                }
                else
                {
                    studentInfo[studentName].Add(studentGrade);
                }
            }


            foreach (var name in studentInfo)
            {
                double avarageGrade = 0;
                foreach (var grade in studentInfo)
                {
                    if (name.Key == grade.Key)
                    {
                        for (int i = 0; i < grade.Value.Count; i++)
                        {
                            avarageGrade += grade.Value[i];
                        }
                        avarageGrade /= grade.Value.Count;
                        studentsAvarageGrade[name.Key] = avarageGrade;
                    }
                }
            }

            foreach (var student in studentsAvarageGrade)
            {
                if (student.Value >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value:f2}");
                }
            }
        }
    }
}
