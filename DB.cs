using System;
using MySql.Data.MySqlClient;
namespace APItoDB
{
    public class DB
    {
        public DB()
        {
        }
        public static void AddSQL()
        {
            MySqlConnection conn = connectToDb();
            conn.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Weatherdata (dates, name, country, temp, feelslike, decription, visibility, windSpeed, windDeg, sunset, sunrise) VALUES ('dates2', 'name', 'country', 22, 23, 'decription', 100, 10, 38, 'sunset', 'sunrise');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        
        public static MySqlConnection connectToDb()
        {
            string server = "localhost";
            string database = "API";
            string user = "root";
            string port = "3306";
            string sslM = "Required";

            string connString = String.Format("server={0};port={1};user id={2}; database={3}; SslMode={4}", server, port, user, database, sslM);

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}

