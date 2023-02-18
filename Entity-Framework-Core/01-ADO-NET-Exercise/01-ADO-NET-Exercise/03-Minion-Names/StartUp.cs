using _02_Villain_Names;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _03_Minion_Names
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            int input = int.Parse(Console.ReadLine());
            string output = await MinionsNameAndAgeByGivenId(connection, input);
            Console.WriteLine(output);
        }

        static async Task<string>MinionsNameAndAgeByGivenId(SqlConnection connection, int villainID)
        {

            SqlCommand getVillainName = new SqlCommand(Queries.VilliansNameByID, connection);
            getVillainName.Parameters.AddWithValue("@Id", villainID);

            object? villianNameObj = await getVillainName.ExecuteScalarAsync();
            if (villianNameObj == null)
            {
                return $"No villain with ID {villainID} exists in the database.";
            }

            string villianName = (string)villianNameObj;

            SqlCommand getVillainMinions = new SqlCommand(Queries.VillianInfoByName, connection);
            getVillainMinions.Parameters.AddWithValue(@"Id", villainID);

            SqlDataReader minionsReader = await getVillainMinions.ExecuteReaderAsync();

            return MinionsInfo(villianName, minionsReader);

        }

        private static string MinionsInfo(string villianName, SqlDataReader minionsReader)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {villianName.ToString()}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine($"(no minions)");
                return sb.ToString().TrimEnd();
            }
            while (minionsReader.Read())
            {
                long rank = (long)minionsReader["RowNum"];
                string minionName = (string)minionsReader["Name"];
                int age = (int)minionsReader["Age"];

                sb.AppendLine($"{rank}. {minionName} {age}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}