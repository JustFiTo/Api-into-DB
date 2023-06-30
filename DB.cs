using System;
using MySql.Data.MySqlClient;
namespace APItoDB
{
    public class DB
    {
        private WeatherMap weathermap;

        public DB(WeatherMap weathermap)
        {
            this.weathermap = weathermap;
        }

        public static void AddSQL(WeatherMap weathermap)
        {
            DateTime date = new DateTime(1970, 01, 01).AddSeconds(weathermap.timezone); //weathermap.dt returns Unix time (seconds since 01.01.1970)
            string dateString = date.AddSeconds(weathermap.dt).ToString("dd.MM.yyyy HH:mm:ss");
            string sunsetString = date.AddSeconds(weathermap.sys.sunset).ToString("HH:mm:ss");
            string sunriseString = date.AddSeconds(weathermap.sys.sunrise).ToString("HH:mm:ss");

            MySqlConnection conn = connectToDb();
            conn.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Weatherdata (dates, name, country, temp, feelslike, decription, visibility, windSpeed, windDeg, sunset, sunrise) VALUES ('" + dateString + "', '" + weathermap.name + "', '" + weathermap.sys.country + "'," + weathermap.main.temp + ", " +weathermap.main.feels_like + ", '" + weathermap.weather[0].description + "', " + weathermap.visibility + ", " + weathermap.wind.speed + ", " + weathermap.wind.deg + ", '" + sunsetString + "', '" + sunriseString + "');";
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

