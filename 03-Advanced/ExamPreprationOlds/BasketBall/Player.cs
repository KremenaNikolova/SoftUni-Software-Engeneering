using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private int games;

        public int Games
        {
            get { return games; }
            set { games = value; }
        }

        private bool retired;

        public bool Retired
        {
            get { return retired; }
            set { retired = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Player: {name}");
            sb.AppendLine($"--Position: {position}");
            sb.AppendLine($"--Rating: {rating}");
            sb.AppendLine($"--Games played: {games}");

            return sb.ToString().Trim();
        }




    }
}
