//Create a program, which reads a name of a student and his/her grades and adds them to the student record, then prints thestudents' names with their grades and their average grade.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);
                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                    students[studentName].Add(grade);
                }
                else
                {
                    students[studentName].Add(grade);
                }
            }
            foreach (var student in students)
            {
                //Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value)} (avg: {student.Value.Average():f2})");
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
