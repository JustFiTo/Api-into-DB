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
            Console.Write("Hier Stadt eingeben:\n>");
            string city = Console.ReadLine();

            WeatherMap weathermap = API.ResponseCurrent(city);
            WeatherMapForecast weatherMapForecast = API.ResponseForecast(city);

            DateTime date = new DateTime(1970, 01, 01).AddSeconds(weathermap.timezone); //weathermap.dt returns Unix time (seconds since 01.01.1970)

            Console.WriteLine($"Die Temperaturen am {date.AddSeconds(weathermap.dt).ToString("dd.MM.yyyy")} um {date.AddSeconds(weathermap.dt).ToString("HH:mm:ss")}Uhr in {weathermap.name} liegen gefühlt bei {weathermap.main.feels_like}°C, " +
                $"aber in wirklichkeit ist es {weathermap.main.temp}°C warm\n { weathermap.wind.deg}  {weathermap.wind.speed} {weathermap.visibility} Sunrise: {date.AddSeconds(weathermap.sys.sunrise)} Sunset: {date.AddSeconds(weathermap.sys.sunset)}\"");


            for (int i = 0; i < weatherMapForecast.list.Count; i++) //0 first forecast, 1 later forecast ...
            {
                Console.WriteLine($"Die Temperaturen am {date.AddSeconds(weatherMapForecast.list[i].dt).ToString("dd.MM.yyyy")} um {date.AddSeconds(weatherMapForecast.list[i].dt).ToString("HH:mm:ss")}Uhr in {weatherMapForecast.city.name} liegen gefühlt bei {weatherMapForecast.list[i].main.feels_like}°C, " +
                $"aber in wirklichkeit ist es {weatherMapForecast.list[i].main.temp}°C warm\n");
            }

            DB.AddSQL(weathermap);
            Console.ReadKey();

        }
    }
}