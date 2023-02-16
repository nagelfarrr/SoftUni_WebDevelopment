namespace ADO_.NET
{
    using System.Text;
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
          await using SqlConnection connection = 
               new SqlConnection(Config.ConnectionString);
          await connection.OpenAsync();

          string result = await GetAllVillians(connection);

           Console.WriteLine(result);
        }

        static async Task<string> GetAllVillians(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand query = new SqlCommand(SqlQueries.GetAllVillians, sqlConnection);

            SqlDataReader reader = await query.ExecuteReaderAsync();

            while (reader.Read())
            {
                string villianName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villianName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}