using System;
using System.Collections.Generic;
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

        }
    }
    public class WeatherMap
    {
        public string name { get; set; }
        public Sys sys { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public City city { get; set; }
        public List<Elements> date { get; set; }

    }
    public class Sys
    {
        public string country { get; set; }
    }
    public class Weather
    {
        public string description { get; set; }
    }
    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
    }

    public class City
    {
        public string name { get; set; }
    }
    public class Elements
    {
        public string visibility { get; set; }
    }

}

