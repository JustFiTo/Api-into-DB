using System;
using System.Net.Http;

namespace APItoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync("https://api.openweathermap.org/data/3.0/onecall?lat=33.44&lon=-94.04&exclude=hourly,daily&appid={08c3a93b591ca03e5816875e07b4381f}").Result;
            Console.WriteLine(response.ToString());
        }
    }
}
