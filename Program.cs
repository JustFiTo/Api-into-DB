using MySql.Data.MySqlClient;
using System;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text.Json;



namespace APItoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Hier Stadt eingeben:\n>");
            //string city = Console.ReadLine();
            string city = "Toronto";
            HttpClient httpClient = new HttpClient();

            /// current Weather Api response:
            string requestURL = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=08c3a93b591ca03e5816875e07b4381f&units=metric";
            HttpResponseMessage HttpResponse = httpClient.GetAsync(requestURL).Result;
            string response = HttpResponse.Content.ReadAsStringAsync().Result;
            WeatherMap weathermap = JsonSerializer.Deserialize<WeatherMap>(response);

            /// Forecast Api response:
            string requestForecastURL = "https://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=08c3a93b591ca03e5816875e07b4381f&units=metric";
            HttpResponseMessage HttpResponse2 = httpClient.GetAsync(requestForecastURL).Result;
            string response2 = HttpResponse2.Content.ReadAsStringAsync().Result;
            WeatherMapForecast weatherMapForecast = JsonSerializer.Deserialize<WeatherMapForecast>(response2);

            //Console.Write(response + "\n");
            //Console.Write(response2);

            Console.WriteLine($"\nLand: {weathermap.sys.country}");
            Console.WriteLine($"Beschreibung: {weathermap.weather[0].description}");
            Console.WriteLine($"\n");

            DateTime date = new DateTime(1970, 01, 01).AddHours(2).AddSeconds(weathermap.dt); //weathermap.dt returns Unix time (seconds since 01.01.1970) + german time zone (+2h)

            Console.WriteLine($"Die Temperaturen am {date.ToString("dd.MM.yyyy")} um {date.ToString("HH:mm:ss")}Uhr in {weathermap.name} liegen aktuel gefühlt bei {weathermap.main.feels_like}°C, " +
                $"aber in wirklichkeit ist es {weathermap.main.temp}°C warm\n");

            Console.WriteLine("Forecast: " + weatherMapForecast.city.name);

            MySqlConnection conn = connectToDb();
            conn.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO City (city_id) VALUES (3);";
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