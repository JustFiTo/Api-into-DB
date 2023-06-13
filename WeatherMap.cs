using System.Collections.Generic;

namespace APItoDB
{
    public class WeatherMap
    {
        public string name { get; set; }
        public Sys sys { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public City city { get; set; }
        public List<Elements> date { get; set; }

    }

}

