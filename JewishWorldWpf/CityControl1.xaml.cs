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
using model;
using MyService;

namespace JewishWorldWpf
{
    /// <summary>
    /// Interaction logic for CityControl1.xaml
    /// </summary>
    public partial class CityControl1 : UserControl
    {
        string currenntCity = "";
        MyApiService apiService=new MyApiService();
        City cityCurrent = null;

        public CityControl1()
        {
            InitializeComponent();
            
        }
        public CityControl1(string cityName)
        {
            InitializeComponent();
            CTName1.Text = SearcherPage.city123.CityName.ToString();
            currenntCity = cityName;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mFrame.Navigate(new KosherRestaurantPage(SearcherPage.city123));
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.mFrame.Navigate(new SynagogePage( SearcherPage.city123));
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow.mFrame.Navigate(new PopularPlacesPage(SearcherPage.city123));
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow.mFrame.Navigate(new BeithHabbadPage(SearcherPage.city123));
        }
    }
}
