//Create a program that ranks candidate-interns, depending on the points from the interview tasks and their exam results in SoftUni. You will receive some lines of input in the format "{contest}:{password for contest}" until you receive "end of contests". Save that data because you will need it later. After that you will receive another type of inputs in the format "{contest}=>{password}=>{username}=>{points}" until you receive "end of submissions". Here is what you need to do:
//•	Check if the contest is valid(if you received it in the first type of input).
//•	Check if the password is correct for the given contest.
//•	Save the user with the contest they take part in (a user can take part in many contests) and the points the user has in the given contest. If you receive the same contest and the same user, update the points only if the new ones are more than the older ones.
//At the end you have to print the info for the user with the most points in the format:
//"Best candidate is {user} with total {total points} points.".After that print all students ordered by their names. For each user, print each contest with the points in descending order in the following format:
//"{user1 name}
//#  {contest1} -> {points}
//#  {contest2} -> {points}
//{ user2 name}
//…"


using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> personInfomartion = new Dictionary<string, Dictionary<string, int>>(); //username, contests, points
            Dictionary<string, string> contests = new Dictionary<string, string>(); //contest, paswword

            string interview = string.Empty;
            while ((interview = Console.ReadLine())!= "end of contests")
            {
                string[] token = interview.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = token[0];
                string password = token[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }
            while ((interview = Console.ReadLine()) != "end of submissions")
            {
                string[] token = interview.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = token[0];
                string password = token[1];
                string username = token[2];
                int points = int.Parse(token[3]);

                if (contests.ContainsKey(contest) && contests[contest]==password)
                {
                    if (!personInfomartion.ContainsKey(username))
                    {
                        personInfomartion.Add(username, new Dictionary<string, int>());
                        
                    }
                     else if (personInfomartion.ContainsKey(username) && personInfomartion[username].ContainsKey(contest) && personInfomartion[username][contest]<points)
                    {
                        personInfomartion[username][contest] = points;
                    }
                    else 
                    {
                        personInfomartion[username].Add(contest, points);
                    }
                }
            }
            Console.WriteLine($"Best candidate is {personInfomartion.OrderByDescending(x=>x.Value.Values)} with total 1350 points.");
        }
    }
}
