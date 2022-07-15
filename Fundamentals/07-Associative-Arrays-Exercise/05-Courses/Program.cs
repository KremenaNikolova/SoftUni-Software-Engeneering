using System;
using System.Collections.Generic;

namespace _05_Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentInfo = new Dictionary<string, List<string>>();
            //List<string> students = new List<string>();

            string[] information = Console.ReadLine().Split(" : ");
            

            while (information[0] != "end")
            {
                string courseName = information[0];
                string studentName = information[1];
                if (!studentInfo.ContainsKey(courseName))
                {
                    studentInfo.Add(courseName, new List<string>());
                    studentInfo[courseName].Add(studentName);
                }
                else
                {
                    studentInfo[courseName].Add(studentName);
                }
                information = Console.ReadLine().Split(" : ");

            }

            foreach (var course in studentInfo)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var students in studentInfo)
                {
                    if (course.Key==students.Key)
                    {
                        for (int i = 0; i < course.Value.Count; i++)
                        {
                            Console.WriteLine($"-- {students.Value[i]}");
                        }
                    }
                }
            }
        }
    }
}
