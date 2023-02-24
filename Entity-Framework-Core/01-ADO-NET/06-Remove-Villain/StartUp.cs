using Microsoft.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace _06_Remove_Villain
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            int villainID = int.Parse(Console.ReadLine()); 

            StringBuilder sb = new StringBuilder();

            SqlCommand getVillainName = new SqlCommand(Queries.VillainNameById, connection);
            getVillainName.Parameters.AddWithValue("@villainId", villainID);

            object? villainNameObj = await getVillainName.ExecuteScalarAsync();
            if (villainNameObj == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            string villainName = (string)villainNameObj;
            int countReleasedMinions = 0;

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                countReleasedMinions = await ReleaseMinions(connection, transaction, villainID);
                await DeleteVillain(connection, transaction, villainID);

                transaction.Commit();
            }
            catch (Exception e)
            {
               transaction.Rollback();
            }

            sb.AppendLine($"{villainName} was deleted.");
            sb.AppendLine($"{countReleasedMinions} minions were released.");

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static async Task<int> ReleaseMinions(SqlConnection connection, SqlTransaction transaction,int villainID)
        {
            SqlCommand releaseMinions = new SqlCommand(Queries.DeleteFromMinionsVillainsByVillainId, connection, transaction);
            releaseMinions.Parameters.AddWithValue("@villainId", villainID);
            int releasedMinions = await releaseMinions.ExecuteNonQueryAsync();

            return releasedMinions;
        }

        private static async Task DeleteVillain(SqlConnection connection, SqlTransaction transaction,int villainID)
        {
            SqlCommand deleteVillain = new SqlCommand(Queries.DeleteFromvillainsByVillainId, connection, transaction);
            deleteVillain.Parameters.AddWithValue("@villainId", villainID);

            await deleteVillain.ExecuteNonQueryAsync();
        }

        
    }
}