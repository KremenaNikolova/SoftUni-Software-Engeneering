using _02_Villain_Names;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _05_Change_Town_Names_Casing
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            string countryName = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            await Transaction(connection, countryName, sb);

            string output = sb.ToString().TrimEnd();
            Console.WriteLine(output);

        }

        private static async Task Transaction(SqlConnection connection, string countryName, StringBuilder sb)
        {
            SqlTransaction sqlTransaction = connection.BeginTransaction();
            try
            {
                SqlCommand updateTowns = new SqlCommand(Queries.updateTownsNameByCountryCode, connection, sqlTransaction);
                updateTowns.Parameters.AddWithValue("@countryName", countryName);

                int numberOfRowsAffected = await updateTowns.ExecuteNonQueryAsync();
                if (numberOfRowsAffected == 0)
                {
                    sb.AppendLine("No town names were affected.");
                }
                else
                {
                    sb.AppendLine($"{numberOfRowsAffected} town names were affected.");
                    string towns = await Towns(connection, countryName, sb, sqlTransaction);
                }

                await sqlTransaction.CommitAsync();

            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
            }
        }

        private static async Task<string> Towns(SqlConnection connection, string countryName, StringBuilder sb, SqlTransaction sqlTransaction)
        {
            SqlCommand selectTowns = new SqlCommand(Queries.findTownByCountryName, connection, sqlTransaction);
            selectTowns.Parameters.AddWithValue("@countryName", countryName);

            await using SqlDataReader sqlReader = await selectTowns.ExecuteReaderAsync();
            List<string> townNames = new List<string>();
            while (sqlReader.Read())
            {
                string townName = (string)sqlReader["Name"];
                townNames.Add(townName);
            }

            sb.AppendLine($"[{string.Join(", ", townNames).ToUpper()}]");
            return sb.ToString().TrimEnd();
        }
    }
}