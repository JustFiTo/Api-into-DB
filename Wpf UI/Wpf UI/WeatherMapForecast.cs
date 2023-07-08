using System.Collections.Generic;
using System.Windows.Documents;

namespace APItoDB
{
    public class WeatherMapForecast
    {
        public City city { get; set; }

        public List<List> list { get; set; }
    }

}