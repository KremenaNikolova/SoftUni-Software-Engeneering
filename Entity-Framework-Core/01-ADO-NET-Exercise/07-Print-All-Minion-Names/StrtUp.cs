using Microsoft.Data.SqlClient;

namespace _07_Print_All_Minion_Names
{
    internal class StrtUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();



        }
    }
}