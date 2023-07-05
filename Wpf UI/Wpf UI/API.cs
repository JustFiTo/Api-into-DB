using System;
using System.Net.Http;
using System.Text.Json;

namespace APItoDB
{
    public class API
    {
        private string city;

        public API(string city)
        {
            this.city = city;
        }

        public static WeatherMap ResponseCurrent(string city)
        {

            HttpClient httpClient = new HttpClient();
            string requestURL = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=08c3a93b591ca03e5816875e07b4381f&units=metric";
            HttpResponseMessage HttpResponse = httpClient.GetAsync(requestURL).Result;
            string response = HttpResponse.Content.ReadAsStringAsync().Result;
            WeatherMap weathermap = JsonSerializer.Deserialize<WeatherMap>(response);

            return weathermap;

        }

        /*public static WeatherMapForecast ResponseForecast(string city)
        {

            HttpClient httpClient = new HttpClient();
            string requestForecastURL = "https://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=08c3a93b591ca03e5816875e07b4381f&units=metric";
            HttpResponseMessage HttpResponse2 = httpClient.GetAsync(requestForecastURL).Result;
            string response2 = HttpResponse2.Content.ReadAsStringAsync().Result;
            WeatherMapForecast weatherMapForecast = JsonSerializer.Deserialize<WeatherMapForecast>(response2);

            return weatherMapForecast;
        }*/
    }
}

