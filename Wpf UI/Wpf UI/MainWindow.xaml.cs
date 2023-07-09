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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = txtBox_Stadt.Text;

            WeatherMap weatherMap = API.ResponseCurrent(city);
            WeatherMapForecast weatherMapForecast = API.ResponseForecast(city);

            DateTime date = new DateTime(1970, 01, 01).AddSeconds(weatherMap.timezone);

            txtBlock_Date.Text = date.AddSeconds(weatherMap.dt).ToString("dd.MM.yy");

            txtBlock_TextLand.Text = weatherMap.sys.country.ToString();
            txtBox_Temperatur.Text = weatherMap.main.temp.ToString();
            txtBox_Bedingungen.Text = weatherMap.weather[0].description.ToString();
            txtBox_Sichtweite.Text = weatherMap.visibility.ToString();
            txtBox_Windstärke.Text = weatherMap.wind.speed.ToString();
            txtBox_Gefühlt.Text = weatherMap.main.feels_like.ToString();
            txtBox_Aufgang.Text = date.AddSeconds(weatherMap.sys.sunrise).ToString();
            txtBox_Untergang.Text = date.AddSeconds(weatherMap.sys.sunset).ToString();
            txtBox_Windrichtung.Text = weatherMap.wind.deg.ToString();

            this.CreateDataGridColumns(weatherMapForecast, date);
            DB.AddSQL(weatherMap);
        }

        private void CreateDataGridColumns(WeatherMapForecast weatherMapForecast, DateTime date)
        {
            /* DataGridTextColumn tagColumn = new DataGridTextColumn();
             tagColumn.Header = "Tag";
             tagColumn.Binding = new System.Windows.Data.Binding("Tag");

             DataGridTextColumn stadtColumn = new DataGridTextColumn();
             stadtColumn.Header = "Stadt";
             stadtColumn.Binding = new System.Windows.Data.Binding("Stadt");

             DataGridTextColumn landColumn = new DataGridTextColumn();
             landColumn.Header = "Land";
             landColumn.Binding = new System.Windows.Data.Binding("Land");

             DataGridTextColumn temperaturColumn = new DataGridTextColumn();
             temperaturColumn.Header = "Temperatur";
             temperaturColumn.Binding = new System.Windows.Data.Binding("Temperatur");

             DataGridTextColumn gefuehltColumn = new DataGridTextColumn();
             gefuehltColumn.Header = "Gefühlt";
             gefuehltColumn.Binding = new System.Windows.Data.Binding("Gefuehlt");

             DataGridTextColumn sichtweiteColumn = new DataGridTextColumn();
             sichtweiteColumn.Header = "Sichtweite";
             sichtweiteColumn.Binding = new System.Windows.Data.Binding("Sichtweite");

             DataGridTextColumn windstaerkeColumn = new DataGridTextColumn();
             windstaerkeColumn.Header = "Windstärke";
             windstaerkeColumn.Binding = new System.Windows.Data.Binding("Windstaerke");

             DataGridTextColumn windrichtungColumn = new DataGridTextColumn();
             windrichtungColumn.Header = "Windrichtung";
             windrichtungColumn.Binding = new System.Windows.Data.Binding("Windrichtung");

             DataGridTextColumn sonnenaufgangColumn = new DataGridTextColumn();
             sonnenaufgangColumn.Header = "Sonnenaufgang";
             sonnenaufgangColumn.Binding = new System.Windows.Data.Binding("Sonnenaufgang");

             DataGridTextColumn sonnenuntergangColumn = new DataGridTextColumn();
             sonnenuntergangColumn.Header = "Sonnenuntergang";
             sonnenuntergangColumn.Binding = new System.Windows.Data.Binding("Sonnenuntergang");

             // Füge die Spalten zum DataGrid hinzu
             dtGrid_Forecast.Columns.Add(tagColumn);
             dtGrid_Forecast.Columns.Add(stadtColumn);
             dtGrid_Forecast.Columns.Add(landColumn);
             dtGrid_Forecast.Columns.Add(temperaturColumn);
             dtGrid_Forecast.Columns.Add(gefuehltColumn);
             dtGrid_Forecast.Columns.Add(sichtweiteColumn);
             dtGrid_Forecast.Columns.Add(windstaerkeColumn);
             dtGrid_Forecast.Columns.Add(windrichtungColumn);
             dtGrid_Forecast.Columns.Add(sonnenaufgangColumn);
             dtGrid_Forecast.Columns.Add(sonnenuntergangColumn);

             string city = txtBox_Stadt.Text;*/



            List<ForecastData> forecastDataList = new List<ForecastData>();
            for (int i = 0; i < weatherMapForecast.list.Count; i++)
            {
                ForecastData forecastData = new ForecastData { Uhrzeit = date.AddSeconds(weatherMapForecast.list[i].dt).ToString("HH:mm:ss"), Temperatur = weatherMapForecast.list[i].main.temp, Feelslike = weatherMapForecast.list[i].main.feels_like, Sichtweite = 10000, Windstärke = weatherMapForecast.list[i].wind.speed, Windrichtung = weatherMapForecast.list[i].wind.deg, Sonnenaufgang = date.AddSeconds(weatherMapForecast.city.sunrise).ToString("HH:mm:ss"), Sonnenuntergang = date.AddSeconds(weatherMapForecast.city.sunset).ToString("HH:mm:ss") };
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

    internal class ForecastData
    {
        public  string Uhrzeit { get; set; }
        public float Temperatur { get; set; }
        public float Feelslike { get; set; }
        public int Sichtweite { get; set; }
        public float Windstärke { get; set; }
        public float Windrichtung { get; set; }
        public string Sonnenaufgang { get; set; }
        public string Sonnenuntergang { get; set; }
    }
}
