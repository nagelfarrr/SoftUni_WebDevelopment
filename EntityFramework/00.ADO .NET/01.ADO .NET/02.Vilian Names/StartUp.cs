namespace ADO_.NET
{
    using System.Text;
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-KQ1NJBD\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;Integrated Security = true;TrustServerCertificate = true");

            connection.Open();
            await using (connection)
            {
                string queryString = @"
                                SELECT v.Name,
	                                   COUNT(*) AS NumberOfMinions
                                  FROM Villains AS v
                                  JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                  JOIN Minions AS m ON mv.MinionId = m.Id
                              GROUP BY v.Name
                                HAVING COUNT(*) > 3
                              ORDER BY NumberOfMinions DESC";

                string queryResult = GetQueryResult(queryString, connection);

                Console.WriteLine(queryResult);
            }
            connection.Close();
        }

        private static string GetQueryResult(string queryString, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(queryString, connection);

            using SqlDataReader sqlReader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();

            while (sqlReader.Read())
            {
                sb.AppendLine(sqlReader["Name"] + " - " + sqlReader["NumberOfMinions"]);
            }

            return sb.ToString().TrimEnd();
        }
    }
}