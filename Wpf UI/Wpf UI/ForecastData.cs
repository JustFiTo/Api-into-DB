using System;
namespace APItoDB
{
    public class ForecastData
    {
        public string Datum { get; set; }
        public float Temperatur { get; set; }
        public float Feelslike { get; set; }
        public int Sichtweite { get; set; }
        public float Windstärke { get; set; }
        public string Windrichtung { get; set; }
        public string Sonnenaufgang { get; set; }
        public string Sonnenuntergang { get; set; }
    }
}
