using System.Text;
using Microsoft.Data.SqlClient;

SqlConnection connection =
    new SqlConnection(@"Server=DESKTOP-KQ1NJBD\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;Integrated Security = true;TrustServerCertificate = true");

connection.Open();

string input = "1";    

using (connection)
{
    string queryString = @$"
                            SELECT
	                            v.Name,
	                            m.Name,
	                            m.Age
                            FROM Villains AS v
                            JOIN MinionsVillains AS mv
	                            ON v.Id = mv.VillainId
                            JOIN Minions AS m
	                            ON mv.MinionId = m.Id
                            WHERE v.Id = {input}
                            ORDER BY m.Name";


    string queryResult = GetQueryResult(queryString, connection);
}

string GetQueryResult(string queryString, SqlConnection con)
{
    SqlCommand command = new SqlCommand(queryString, con);

    using SqlDataReader reader = command.ExecuteReader();

    StringBuilder sb = new StringBuilder();

    while (reader.Read())
    {
        
    }
}