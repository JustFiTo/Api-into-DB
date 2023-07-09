using System;
using System.Data;
using System.Windows.Controls;
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
            string deg = Program.changeWindDeg(weathermap);

            MySqlConnection conn = connectToDb();
            conn.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            string temp = weathermap.main.temp.ToString().Replace(",",".");
            string feelsLike = weathermap.main.feels_like.ToString().Replace(",", ".");
            string windSpeed = weathermap.wind.speed.ToString().Replace(",", ".");
            cmd.CommandText = "INSERT INTO Weatherdata (dates, name, country, temp, feelslike, decription, visibility, windSpeed, windDeg, sunset, sunrise) VALUES ('" + dateString + "', '" + weathermap.name + "', '" + weathermap.sys.country + "','" + temp + "', '" + feelsLike + "', '" + weathermap.weather[0].description + "', " + weathermap.visibility + ", '" + windSpeed + "', '" + deg + "', '" + sunsetString + "', '" + sunriseString + "');";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static MySqlConnection connectToDb()
        {
            string server = "localhost";
            string database = "API";
            string user = "root";
            string password = "1234";
            string port = "3306";
            string sslM = "Required";

            string connString = String.Format("server={0};port={1};user id={2};password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
