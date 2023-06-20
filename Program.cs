using MySql.Data.MySqlClient;
using System;
using System.Net.Http;
using System.Text.Json;



namespace APItoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hier Stadt eingeben:\n>");
            string city = Console.ReadLine();
            HttpClient httpClient = new HttpClient();
            string requestURL = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=08c3a93b591ca03e5816875e07b4381f&units=metric";
            HttpResponseMessage HttpResponse = httpClient.GetAsync(requestURL).Result;
            string response = HttpResponse.Content.ReadAsStringAsync().Result;
            Console.Write(response);

            WeatherMap weathermap = JsonSerializer.Deserialize<WeatherMap>(response);
            Console.WriteLine($"\nLand: {weathermap.sys.country}");
            Console.WriteLine($"Beschreibung: {weathermap.weather[0].description}");
            Console.WriteLine($"\n");
            Console.WriteLine($"Die Temperaturen in " + city + $" liegen aktuel gefühlt bei {weathermap.main.feels_like}°C, " +
                $"aber in wirklichkeit ist es {weathermap.main.temp}°C warm");

            Console.ReadKey();

            MySqlConnection conn = connectToDb();
            conn.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "";
            cmd.ExecuteNonQuery();
            conn.Close();



        }

        public static MySqlConnection connectToDb()
        {
            string server = "localhost";
            string database = "mysqldb1";
            string user = "root";
            string password = "u1s2e3r4";
            string port = "3306";
            string sslM = "none";

            string connString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}