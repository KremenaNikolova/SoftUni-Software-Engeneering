using System;

namespace FirstLab08012022
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfArchitect = (Console.ReadLine());
            int project = int.Parse(Console.ReadLine());
            int hours = project * 3;

            Console.WriteLine($"The architect {nameOfArchitect} will need {hours} hours" +
                $" to complete {project} project/s.");

        }
    }
}