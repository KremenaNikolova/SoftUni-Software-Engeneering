using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Add_Minion
{
    public static class Queries
    {
        public const string VillainID = @"SELECT Id FROM Villains WHERE Name = @Name";

        public const string MinionID = @"SELECT Id FROM Minions WHERE Name = @Name";

        public const string InsertIntoMinionsVillains = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public const string InsertIntoVillains = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string InsertIntoMinions = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public const string InsertIntoTowns = @"INSERT INTO Towns (Name) VALUES (@townName)";

        public const string TownID = @"SELECT Id FROM Towns WHERE Name = @townName";

    }
}
