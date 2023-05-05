using System;
using System.Net.Http;

namespace APItoDB
{
    class ApiAnbindung
    { 
        public String GetOutputAsString()
        {           
        HttpClient client = new HttpClient();
        var response = client.GetStringAsync("https://api.openweathermap.org/data/3.0/onecall/timemachine?lat={lat}&lon={lon}&dt={time}&appid={9e617812433d2b1f4c01730556b05b73}").Result;
               
           return response;
        }
    }
}
