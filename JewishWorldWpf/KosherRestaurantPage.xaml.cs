using model;
using MyService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace JewishWorldWpf
{
    /// <summary>
    /// Interaction logic for KosherRestaurantPage.xaml
    /// </summary>
    public partial class KosherRestaurantPage : Page
    {
        City c = SearcherPage.city123;
        public KosherRestaurantPage()
        {
            InitializeComponent();
        }
        public KosherRestaurantPage(City city)
        {
            InitializeComponent();
            Kosher1(city);
            if (LoginPage.isManager == true)
            {
                this.Menahel.Visibility = Visibility.Visible;
            }

        }
    
        public async Task Kosher1(City ct)
        {
            this.kosherList.ItemsSource = null;
            MyApiService myApiService = new MyApiService();
            KosherRestaurantList kl = await myApiService.SelectAllKosherRestaurant();
            KosherRestaurantList ktl = new KosherRestaurantList();
            int y = ct.Id;
            try
            {
                ktl = new KosherRestaurantList(kl.FindAll(x => x.CityCode.Id == y));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            this.cityName.Text = "Kosher restaurants in "+ct.CityName;
            this.kosherList.ItemsSource = ktl;

        }

        private void Menahel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mFrame.Content = new KosherChangesPage(SearcherPage.city123);

        }

    }
}
