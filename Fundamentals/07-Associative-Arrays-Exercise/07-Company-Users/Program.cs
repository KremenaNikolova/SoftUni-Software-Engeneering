using System;
using System.Collections.Generic;

namespace _07_Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyInfo = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" -> ");

            while (input[0] !="End")
            {
                string companyName = input[0];
                string employeeId = input[1];

                if (!companyInfo.ContainsKey(companyName))
                {
                    companyInfo.Add(companyName, new List<string>());
                    companyInfo[companyName].Add(employeeId);    
                }
                else
                {
                    if (!companyInfo[companyName].Contains(employeeId))
                    {
                        companyInfo[companyName].Add(employeeId);
                    }
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var info in companyInfo)
            {
                foreach (var company in companyInfo)
                {
                    if (info.Key==company.Key)
                    {
                        Console.WriteLine($"{company.Key}");
                        for (int i = 0; i < company.Value.Count; i++)
                        {
                            Console.WriteLine($"-- {company.Value[i]}");
                        }
                    }
                }
            }
        }
    }
}
