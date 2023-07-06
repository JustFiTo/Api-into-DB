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
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = txtBox_Stadt.Text;
            //string date = txtBox_Von.Text;

            WeatherMap weatherMap = API.ResponseCurrent(city);

            DateTime date = new DateTime(1970, 01, 01).AddSeconds(weatherMap.timezone);

            txtBox_TextLand.Text = weatherMap.sys.country.ToString();
            txtBox_Temperatur.Text = weatherMap.main.temp.ToString();
            //txtBox_Bedingungen.Text = weatherMap.weather.description.ToString();
            txtBox_Sichtweite.Text = weatherMap.visibility.ToString();
            txtBox_Windstärke.Text = weatherMap.wind.speed.ToString();
            txtBox_Gefühlt.Text = weatherMap.main.feels_like.ToString();
            //txtBox_Aufgang.Text = weatherMap.sys.sunrise.ToString();
            //txtBox_Untergang.Text = weatherMap.sys.sunset.ToString();
            txtBox_Windrichtung.Text = weatherMap.wind.deg.ToString();



            //DateTime date = txtBox_Von.Text();


            
        }

    }
}
