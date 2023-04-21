using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        string playerName = "Gosho";
        int playerNumber = 3;
        string position = "Goalkeeper";
        FootballPlayer player;

        string teamName = "Starts";
        int capacity = 15;
        FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer(playerName, playerNumber,position);
            team = new FootballTeam(teamName, capacity);
        }

        [Test]
        public void Test_Plater_Constructor()
        {
            Assert.AreEqual(playerName, player.Name);
            Assert.AreEqual(playerNumber, player.PlayerNumber);
            Assert.AreEqual(position, player.Position);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_Player_NamaCannotBeNullOrEmty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(name, playerNumber, position);
            });
        }

        [TestCase(0)]
        [TestCase(22)]
        public void Test_Player_PlayerNumberCannotBeBelow1OrAbove21(int number)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(playerName, number, position);
            });
        }

        [Test]
        public void Test_Player_PositionCannotBeDifferentOfGivenTypes()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(teamName, playerNumber, "Error");
            });
        }

        [Test]
        public void Test_Player_ScoredGoals()
        {
            int expectedGoals = 0;
            Assert.AreEqual(expectedGoals, player.ScoredGoals);
        }

        [Test]
        public void Test_Player_Score()
        {
            int expectedScore = 1;
            player.Score();
            Assert.AreEqual(expectedScore, player.ScoredGoals);
        }

        [Test]
        public void Test_Team_Constructor()
        {
            Assert.AreEqual(teamName, team.Name);
            Assert.AreEqual(capacity, team.Capacity);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_Team_NameCannotBeNullOrEmty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(name, capacity);
            });
        }

        [Test]
        public void Test_Team_CapacityCannotBeBelow15()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(teamName, 5);
            });
        }

        [Test]
        public void Test_Team_Players()
        {
            team.AddNewPlayer(player);
            int expectedPlayers = 1;

            Assert.AreEqual(expectedPlayers, team.Players.Count);
        }

        [Test]
        public void Test_Team_AddNewPlayer()
        {
            string expectedOutput = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";

            Assert.AreEqual(expectedOutput, team.AddNewPlayer(player));
        }

        [Test]
        public void Test_Team_AddNewPlayer_ShouldThrowExceptionIfCapacityIsFull()
        {
            for (int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer("Gosho" + i, i+1, position));
            }

            string expectedOutput = "No more positions available!";

            Assert.AreEqual(expectedOutput, team.AddNewPlayer(player));
        }

        [Test]
        public void Test_Team_PickUpPlayer()
        {
            team.AddNewPlayer(player);

            Assert.AreEqual(player, team.PickPlayer(playerName));
        }

        [Test]
        public void Test_Team_PlayerScore()
        {
            team.AddNewPlayer(player);
            string expectedOutpiut = $"{player.Name} scored and now has {player.ScoredGoals+1} for this season!";

            Assert.AreEqual(expectedOutpiut, team.PlayerScore(playerNumber));
        }

        
    }
}