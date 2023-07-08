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
            string deg = "";

            if (weathermap.wind.deg > 0 && weathermap.wind.deg < 45)
            {
                deg = "N";
            }
            else if (weathermap.wind.deg > 45 && weathermap.wind.deg < 90)
            {
                deg = "NO";
            }
            else if (weathermap.wind.deg > 90 && weathermap.wind.deg < 135)
            {
                deg = "O";
            }
            else if (weathermap.wind.deg > 135 && weathermap.wind.deg < 180)
            {
                deg = "SO";
            }
            else if (weathermap.wind.deg > 180 && weathermap.wind.deg < 225)
            {
                deg = "S";
            }
            else if (weathermap.wind.deg > 225 && weathermap.wind.deg < 270)
            {
                deg = "SW";
            }
            else if (weathermap.wind.deg > 270 && weathermap.wind.deg < 315)
            {
                deg = "W";
            }
            else if (weathermap.wind.deg > 315 && weathermap.wind.deg < 360)
            {
                deg = "NW";
            }

            MySqlConnection conn = connectToDb();
            conn.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Weatherdata (dates, name, country, temp, feelslike, decription, visibility, windSpeed, windDeg, sunset, sunrise) VALUES ('" + dateString + "', '" + weathermap.name + "', '" + weathermap.sys.country + "'," + weathermap.main.temp + ", " + weathermap.main.feels_like + ", '" + weathermap.weather[0].description + "', " + weathermap.visibility + ", " + weathermap.wind.speed + ", '" + deg + "', '" + sunsetString + "', '" + sunriseString + "');";
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
