using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int openPositions;

        public int OpenPositions
        {
            get { return openPositions; }
            set { openPositions = value; }
        }

        private char group;

        public char Group
        {
            get { return group; }
            set { group = value; }
        }

        public int Count { get { return players.Count; } }

        public string AddPlayer(Player player)
        {
            //If the name or position is null or empty, return "Invalid player's information.".
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            //If there are no more open positions, return "There are no more open positions.".
            else if (openPositions == 0)
            {
                return "There are no more open positions.";
            }

            //If the rating is under 80, return "Invalid player's rating.".
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            //Otherwise, return: "Successfully added {playerName} to the team. Remaining open positions: {openPositions}." and decrease the OpenPositions/ property of the team
            players.Add(player);
            OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {openPositions}.";

        }

        public bool RemovePlayer(string name) //removes player by a given name
        {
            //If such exists, returns true;
            //Otherwise, returns false.

            if (players.Any(p => p.Name == name))
            {
                this.OpenPositions++;
                players.Remove(players.First(p => p.Name == name));
                return true;
            }
            else
                return false;

        }

        public int RemovePlayerByPosition(string position) //– removes all players by the given position.
        {
            //If such exist(s), returns the count of the removed players;
            //Otherwise, returns 0.

            int removedPositions = players.RemoveAll(p => p.Position == position);
            OpenPositions += removedPositions;
            return removedPositions;
        }
        public Player RetirePlayer(string name)
        {
            //method – retire (set his Retired property to true, without removing him from the collection) the player with the given name, if he exists.
            //As a result, return the player, or null, if he don't exist.

            if (players.Any(p=>p.Name==name))
            {
                Player player = players.Find(p => p.Name == name);
                player.Retired = true;
                return player;
            }
            return null;
        }

        public List<Player> AwardPlayers(int games) //method – return a list with all players that have participated in games games or more.
        {
            return players.Where(p => p.Games >= games).ToList();
        }

        public string Report() //– returns a string with information about the team and players who are not retired in the following format:
        {
            return $"Active players competing for Team {name} from Group {group}:" + Environment.NewLine + string.Join(Environment.NewLine, this.players.Where(p => !p.Retired));
        }
    }
}
