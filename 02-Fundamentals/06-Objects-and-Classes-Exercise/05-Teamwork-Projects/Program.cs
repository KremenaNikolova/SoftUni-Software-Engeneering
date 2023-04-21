using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Teams> teams = new List<Teams>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                //the user is crreator of the team

                string creator = input[0];
                string teamName = input[1];

                if (teams.Any(team => team.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Teams team = new Teams();
                    team.TeamName = teamName;
                    team.Creator = creator;
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");

                }


            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("->");

                string user = input[0];

                if (user == "end of assignment")
                {
                    break;
                }

                string teamName = input[1];

                if (!teams.Any(team => team.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(member => member.Members.Contains(user)) || teams.Any(creator => creator.Creator == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    Teams currTeam = teams.Find(team => team.TeamName == teamName);
                    currTeam.Members.Add(user);
                }
            }

            var allTeams = teams.Where(x => x.Members.Count > 0);
            //allTeams
            var disbanedTeams = teams.Where(y => y.Members.Count == 0);

            foreach (var team in allTeams.OrderByDescending(x => x.Members.Count).ThenBy(y => y.TeamName))
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(y => y))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in disbanedTeams.OrderBy(x=>x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
           
        }

        class Teams
        {
            public string TeamName { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }
        }
    }
}
