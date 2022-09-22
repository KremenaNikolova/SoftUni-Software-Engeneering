//Create a program that keeps the information about vloggers and their followers. The input will come as a sequence of strings, where each string will represent a valid command. The commands will be presented in the following format:
//•	"{vloggername}" joined The V-Logger – keep the vlogger in your records.
//o	Vloggernames consist of only one word.
//o	If the given vloggername already exists, ignore that command.
//
//•	"{vloggername} followed {vloggername}" – The first vlogger followed the second vlogger.
//o	If any of the given vlogernames does not exist in your collection, ignore that command.
//o	Vlogger cannot follow himself.
//o	Vloggers cannot follow someone he is already a follower of.
//•	"Statistics" - Upon receiving this command, you have to print a statistic about the vloggers.
//Each vlogger has a unique vloggername. Vloggers can follow other vloggers and a vlogger can follow as many other vloggers as he wants, but he cannot follow himself or follow someone he is already a follower of. You need to print the total count of vloggers in your collection. Then you have to print the most famous vlogger – the one with the most followers, with his followers. If more than one vloggers have the same number of followers, print the one following fewer people, and his followers should be printed in lexicographical order (in case the vlogger has no followers, print just the first line, which is described below). Lastly, print the rest of the vloggers, ordered by the count of followers in descending order, then by the number of vloggers he follows in ascending order. The whole output must be in the following format:
//"The V-Logger has a total of {registered vloggers} vloggers in its logs.
//1. { mostFamousVlogger} : { followers}
//followers, { followings}
//following
//*  {follower1}
//*  {follower2} … 
//{ No}. {vlogger} : {followers} followers, {followings} following
//{ No}. {vlogger} : {followers} followers, {followings} following…"


using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, int> followingCounter = new Dictionary<string, int>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] information = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string nickname = information[0];
                string action = information[1];
                if (action == "joined")
                {
                    if (!vloggers.ContainsKey(nickname))
                    {
                        vloggers.Add(nickname, new List<string>());
                        followingCounter.Add(nickname, 0);
                    }
                }
                else //followed
                {
                    string follower = information[2];
                    //JennaMarbles followed Zoella //nickname followed follower
                    if (nickname != follower && vloggers.ContainsKey(follower) && vloggers.ContainsKey(nickname) && !vloggers[follower].Contains(nickname))
                    {
                        vloggers[follower].Add(nickname);
                        followingCounter[nickname]++;
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count} vloggers in its logs.");

            followingCounter = followingCounter.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key, x=> x.Value);

            int counter = 1;
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value.Count).ThenBy(x => followingCounter[x.Key])) //vloggerKey - string, vlogger.Value - List<string>
            {
                Console.WriteLine($"{counter++}. {vlogger.Key} : {vlogger.Value.Count} followers, {followingCounter[vlogger.Key]} following");
                if (counter==2)
                {
                    foreach (var person in vlogger.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {person}");
                    }
                }

            }


        }
    }
}
