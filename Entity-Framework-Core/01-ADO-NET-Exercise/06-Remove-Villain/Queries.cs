using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Remove_Villain
{
    public static class Queries
    {
        public const string VillainNameById = @"SELECT Name FROM Villains WHERE Id = @villainId";

        public const string DeleteFromMinionsVillainsByVillainId =
            @"DELETE 
                FROM MinionsVillains 
               WHERE VillainId = @villainId";

        public const string DeleteFromvillainsByVillainId =
            @"DELETE 
                FROM Villains
               WHERE Id = @villainId";
    }
}
