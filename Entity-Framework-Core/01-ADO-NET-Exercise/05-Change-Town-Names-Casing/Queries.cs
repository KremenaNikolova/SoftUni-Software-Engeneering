using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Change_Town_Names_Casing
{
    public static class Queries
    {
        public const string updateTownsNameByCountryCode =
            @"UPDATE Towns
                 SET Name = UPPER(Name)
               WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string findTownByCountryName =
            @" SELECT t.Name 
                 FROM Towns as t
                 JOIN Countries AS c ON c.Id = t.CountryCode
                WHERE c.Name = @countryName";
    }
}
