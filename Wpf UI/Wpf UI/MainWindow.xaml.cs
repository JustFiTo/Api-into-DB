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
//using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text.Json;
using MySql.Data.MySqlClient;

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
            CreateDataGridColumns();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = txtBox_Stadt.Text;
            //string date = txtBox_Von.Text;

            WeatherMap weatherMap = API.ResponseCurrent(city);
            WeatherMapForecast weatherMapForecast = API.ResponseForecast(city);

            DateTime date = new DateTime(1970, 01, 01).AddSeconds(weatherMap.timezone);

            txtBox_Von.Text = date.AddSeconds(weatherMap.dt).ToString("dd.MM.yy");

            txtBox_TextLand.Text = weatherMap.sys.country.ToString();
            txtBox_Temperatur.Text = weatherMap.main.temp.ToString();
            //txtBox_Bedingungen.Text = weatherMap.weather.description...
            txtBox_Sichtweite.Text = weatherMap.visibility.ToString();
            txtBox_Windstärke.Text = weatherMap.wind.speed.ToString();
            txtBox_Gefühlt.Text = weatherMap.main.feels_like.ToString();
            txtBox_Aufgang.Text = date.AddSeconds(weatherMap.sys.sunrise).ToString();
            txtBox_Untergang.Text = date.AddSeconds(weatherMap.sys.sunset).ToString();
            txtBox_Windrichtung.Text = weatherMap.wind.deg.ToString();



            //DateTime date = txtBox_Von.Text();



            for (int i = 0; i < weatherMapForecast.list.Count; i++) //0 first forecast, 1 later forecast ...
            {
                dtGrid_Forecast.ItemsSource = weatherMapForecast.list;          //date.AddSeconds(weatherMapForecast.list[i].dt).ToString("dd.MM.yyyy");

                /*Console.WriteLine($"Die Temperaturen am {date.AddSeconds(weatherMapForecast.list[i].dt).ToString("dd.MM.yyyy")} um {date.AddSeconds(weatherMapForecast.list[i].dt).ToString("HH:mm:ss")}Uhr in {weatherMapForecast.city.name} liegen gefühlt bei {weatherMapForecast.list[i].main.feels_like}°C, " +
                $"aber in wirklichkeit ist es {weatherMapForecast.list[i].main.temp}°C warm\n");*/
            }

            //DB.AddSQL(weatherMap);
            //Console.ReadKey();
        }

        private void CreateDataGridColumns()
        {
            DataGridTextColumn tagColumn = new DataGridTextColumn();
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
        }



        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            SecendWindow objSecondWindow = new SecendWindow();
            this.Visibility = Visibility.Hidden;
            objSecondWindow.Show();
        }

        private void OpenWindow2(object sender, RoutedEventArgs e)
        {
            ThirdWindow objThirdWindow = new ThirdWindow();
            this.Visibility = Visibility.Hidden;
            objThirdWindow.Show();
        }
    }
}
