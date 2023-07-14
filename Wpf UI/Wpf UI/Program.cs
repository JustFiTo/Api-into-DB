using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace APItoDB
{
    class Program
    {
        public static string changeWindDeg(WeatherMap weatherMap)
        {
            string deg = "";

            if (weatherMap.wind.deg >= 0 && weatherMap.wind.deg < 45)
            {
                deg = "N";
            }
            else if (weatherMap.wind.deg >= 45 && weatherMap.wind.deg < 90)
            {
                deg = "NO";
            }
            else if (weatherMap.wind.deg >= 90 && weatherMap.wind.deg < 135)
            {
                deg = "O";
            }
            else if (weatherMap.wind.deg >= 135 && weatherMap.wind.deg < 180)
            {
                deg = "SO";
            }
            else if (weatherMap.wind.deg >= 180 && weatherMap.wind.deg < 225)
            {
                deg = "S";
            }
            else if (weatherMap.wind.deg >= 225 && weatherMap.wind.deg < 270)
            {
                deg = "SW";
            }
            else if (weatherMap.wind.deg >= 270 && weatherMap.wind.deg < 315)
            {
                deg = "W";
            }
            else if (weatherMap.wind.deg >= 315 && weatherMap.wind.deg < 360)
            {
                deg = "NW";
            }

            return deg;

        }
        public static string changeWindDegForecast(WeatherMapForecast weatherMapForecast, int i)
        {
            string deg = "";

            if (weatherMapForecast.list[i].wind.deg >= 0 && weatherMapForecast.list[i].wind.deg < 45)
            {
                deg = "N";
            }
            else if (weatherMapForecast.list[i].wind.deg >= 45 && weatherMapForecast.list[i].wind.deg < 90)
            {
                deg = "NO";
            }
            else if (weatherMapForecast.list[i].wind.deg >= 90 && weatherMapForecast.list[i].wind.deg < 135)
            {
                deg = "O";
            }
            else if (weatherMapForecast.list[i].wind.deg >= 135 && weatherMapForecast.list[i].wind.deg < 180)
            {
                deg = "SO";
            }
            else if (weatherMapForecast.list[i].wind.deg >= 180 && weatherMapForecast.list[i].wind.deg < 225)
            {
                deg = "S";
            }
            else if (weatherMapForecast.list[i].wind.deg >= 225 && weatherMapForecast.list[i].wind.deg < 270)
            {
                deg = "SW";
            }
            else if (weatherMapForecast.list[i].wind.deg >= 270 && weatherMapForecast.list[i].wind.deg < 315)
            {
                deg = "W";
            }
            else if (weatherMapForecast.list[i].wind.deg >= 315 && weatherMapForecast.list[i].wind.deg < 360)
            {
                deg = "NW";
            }

            return deg;
        }
    }

}

