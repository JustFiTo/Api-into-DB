using APItoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Text.Json;
using MySql.Data.MySqlClient;
using System.Data;

namespace WPF_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = txtBox_Stadt.Text;

            WeatherMap weatherMap = API.ResponseCurrent(city);
            WeatherMapForecast weatherMapForecast = API.ResponseForecast(city);

            DateTime date = new DateTime(1970, 01, 01).AddSeconds(weatherMap.timezone);
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

            txtBlock_Date.Text = date.AddSeconds(weatherMap.dt).ToString("dd.MM.yy");

            txtBlock_TextLand.Text = weatherMap.sys.country.ToString();
            txtBox_Temperatur.Text = weatherMap.main.temp.ToString();
            txtBox_Bedingungen.Text = weatherMap.weather[0].description.ToString();
            txtBox_Sichtweite.Text = weatherMap.visibility.ToString();
            txtBox_Windstärke.Text = weatherMap.wind.speed.ToString();
            txtBox_Gefühlt.Text = weatherMap.main.feels_like.ToString();
            txtBox_Aufgang.Text = date.AddSeconds(weatherMap.sys.sunrise).ToString("HH:mm:ss");
            txtBox_Untergang.Text = date.AddSeconds(weatherMap.sys.sunset).ToString("HH:mm:ss");
            txtBox_Windrichtung.Text = deg;

            this.CreateDataGridColumns(weatherMapForecast, date);
            DB.AddSQL(weatherMap);
        }

        private void CreateDataGridColumns(WeatherMapForecast weatherMapForecast, DateTime date)
        {
           
            List<ForecastData> forecastDataList = new List<ForecastData>();
            for (int i = 0; i < weatherMapForecast.list.Count; i++)
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
                ForecastData forecastData = new ForecastData { Uhrzeit = date.AddSeconds(weatherMapForecast.list[i].dt).ToString("HH:mm:ss"), Temperatur = weatherMapForecast.list[i].main.temp, Feelslike = weatherMapForecast.list[i].main.feels_like, Sichtweite = 10000, Windstärke = weatherMapForecast.list[i].wind.speed, Windrichtung = deg, Sonnenaufgang = date.AddSeconds(weatherMapForecast.city.sunrise).ToString("HH:mm:ss"), Sonnenuntergang = date.AddSeconds(weatherMapForecast.city.sunset).ToString("HH:mm:ss") };
               forecastDataList.Add(forecastData);
            }
                
            // Setze die Datenquelle des DataGrids
            dtGrid_Forecast.ItemsSource = forecastDataList;
        }
                    
        private void ShowOldDates(object sender, RoutedEventArgs e) //Button Old Dates
        {
            string query = "SELECT * FROM weatherdata";

            DataSet ds = new DataSet();
            this.SelectRows(ds, query);

            dtGrid_OldDates.ItemsSource = ds.Tables[0].DefaultView;
        }

        public DataSet SelectRows(DataSet dataset, string query)
        {
            MySqlConnection conn = DB.connectToDb();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(query, conn);
            adapter.Fill(dataset);
            return dataset;
        }
    }
}
