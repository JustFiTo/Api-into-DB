using System.Collections.Generic;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace APItoDB
{
    public class WeatherMap
    {
        public string name { get; set; }
        public int timezone { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public List<Elements> date { get; set; }
        public Wind wind { get; set; }
        public float visibility { get; set; }

    }

}

