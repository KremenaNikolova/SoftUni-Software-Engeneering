using Microsoft.Data.SqlClient;
using Microsoft.Win32.SafeHandles;
using System.Data.SqlTypes;
using System.Text;

namespace _02_Villain_Names
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
           await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
           await connection.OpenAsync();

            string result = await GetAllVilliansWithTheirMinions(connection);
            Console.WriteLine(result); ;
        }

        static async Task<string>GetAllVilliansWithTheirMinions(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCmd = new SqlCommand(Queries.GetAllVillainsAndTheirNumberOfMinions, connection);
            SqlDataReader reader = await sqlCmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                string villianName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villianName} – {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}