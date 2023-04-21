using _02_Villain_Names;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _04_Add_Minion
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            string[] minionInformation = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string minion = minionInformation[1];

            string[] villainInformation = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string villainName = villainInformation[1];

            string output = await BulkOperation(connection, minion, villainName);
            Console.WriteLine(output);


        }

        static async Task<string> BulkOperation(SqlConnection connection, string minion, string villainName)
        {
            string[] minionArgs = minion.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string name = minionArgs[0];
            int age = int.Parse(minionArgs[1]);
            string town = minionArgs[2];


            StringBuilder sb = new StringBuilder();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                int townId = await GetTownId(connection, town, sb, transaction);
                int villainId = await GetVillainId(connection, villainName, sb, transaction);
                int minnionId = await GetMinionId(connection, name, age, townId, transaction);
                await AddMinionToVillain(connection, minnionId, villainId, transaction);

                sb.AppendLine($"Successfully added {name} to be minion of {villainName}.");

                await transaction.CommitAsync();

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
            }

            return sb.ToString().TrimEnd();

        }

        private static async Task<int> GetTownId(SqlConnection connection, string town, StringBuilder sb, SqlTransaction transaction)
        {
            SqlCommand getTownId = new SqlCommand(Queries.TownID, connection, transaction);
            getTownId.Parameters.AddWithValue(@"townName", town);

            int? townId = (int?)await getTownId.ExecuteScalarAsync();
            if (!townId.HasValue)
            {
                SqlCommand insertTown = new SqlCommand(Queries.InsertIntoTowns, connection, transaction);
                insertTown.Parameters.AddWithValue(@"townName", town);

                await insertTown.ExecuteNonQueryAsync();
                townId = (int?)await getTownId.ExecuteScalarAsync();
                
                sb.AppendLine($"Town {town} was added to the database.");
            }

            return townId.Value;
        }

        private static async Task<int> GetVillainId(SqlConnection connection, string villainName, StringBuilder sb, SqlTransaction transaction)
        {
            SqlCommand getVillainId = new SqlCommand(Queries.VillainID, connection, transaction);
            getVillainId.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await getVillainId.ExecuteScalarAsync();
            if (!villainId.HasValue)
            {
                SqlCommand insertVillain = new SqlCommand(Queries.InsertIntoVillains, connection, transaction);
                insertVillain.Parameters.AddWithValue("@villainName", villainName);

                await insertVillain.ExecuteNonQueryAsync();
                villainId = (int?)await getVillainId.ExecuteScalarAsync();

                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId.Value;
        }

        private static async Task AddMinnion(SqlConnection connection, string name, int age, int townID, SqlTransaction transaction)
        {
            SqlCommand addMinnion = new SqlCommand(Queries.InsertIntoMinions, connection, transaction);
            addMinnion.Parameters.AddWithValue("@name", name);
            addMinnion.Parameters.AddWithValue("@age", age);
            addMinnion.Parameters.AddWithValue("@townId", townID);

            await addMinnion.ExecuteNonQueryAsync();
        }

        private static async Task<int> GetMinionId(SqlConnection connection, string name, int age, int townID, SqlTransaction transaction)
        {
            await AddMinnion(connection, name, age, townID, transaction);

            SqlCommand getMinionId = new SqlCommand(Queries.MinionID, connection, transaction);
            getMinionId.Parameters.AddWithValue("@name", name);

            int? minionId = (int?)await getMinionId.ExecuteScalarAsync();
            return minionId.Value;

        }

        private static async Task AddMinionToVillain(SqlConnection connection, int minionId, int villainId, SqlTransaction transaction)
        {
            SqlCommand addMinionToVillain = new SqlCommand(Queries.InsertIntoMinionsVillains, connection, transaction);
            addMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillain.Parameters.AddWithValue("@villainId", villainId);

            await addMinionToVillain.ExecuteNonQueryAsync();
        }
    }
}