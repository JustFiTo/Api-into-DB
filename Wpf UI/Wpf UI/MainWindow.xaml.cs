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

            WeatherMap weatherMap = API.ResponseCurrent(city);

            txtBox_TextLand.Text = weatherMap.sys.ToString();
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

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void txtBox_BtnPrognose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextLand_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBox_Temperatur_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBox_Sichtweite_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBox_Windstärke_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Gefühlt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBox_Aufgang_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBox_Untergang_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBox_Windrichtung_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
