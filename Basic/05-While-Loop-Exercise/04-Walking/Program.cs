using System;

namespace _04_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyGoal = 10000;
            int stepsEveryDay = 0;
            int endSteps = 0;
            string command = string.Empty;

            while (dailyGoal>=stepsEveryDay)
            {

                command = Console.ReadLine();
                if (command == "Going home")
                {
                    endSteps = int.Parse(Console.ReadLine());
                    stepsEveryDay += endSteps;
                    if (stepsEveryDay < dailyGoal)
                    {
                        Console.WriteLine($"{dailyGoal - stepsEveryDay} more steps to reach goal.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{stepsEveryDay - dailyGoal} steps over the goal!");
                        break;
                    }
                }
                stepsEveryDay += int.Parse(command);
                if (dailyGoal < stepsEveryDay)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepsEveryDay - dailyGoal} steps over the goal!");
                }
            }
            
            
        }
    }
}
