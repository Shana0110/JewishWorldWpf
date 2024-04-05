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
    /// Interaction logic for SearcherPage.xaml
    /// </summary>
    public partial class SearcherPage : Page
    {
        public static City city123;
        private CityList cities2= new CityList();
        private CountryList countries2 = new CountryList();
        public SearcherPage()
        {
            InitializeComponent();
            Cont();
           
        }
        public async void  Cit()
        {
            List<string> stl=new List<string>();
            this.cities2 = await Cities1();
            string countryName = this.countryCombo.SelectedItem.ToString();
            Country cf= countries2.Find(x=>x.CountryName== countryName);
            int y = cf.Id;
            foreach(City city in this.cities2)
            {
                if(city.CountryCode.Id == y)
                {
                    stl.Add(city.CityName);
                }    
            }
            cityCombo.ItemsSource = stl;

        }
        public async Task<CityList> Cities1()
        {
            MyApiService myApiService = new MyApiService();
            CityList cl = await myApiService.SelectAllCity();
            return cl;     
        }
        public async void Cont()
        {
            this.countries2 = await Countries1();
            List<string> stl = countries2.Select(x => x.CountryName).ToList();
            countryCombo.ItemsSource = stl;
        }
        public async Task<CountryList> Countries1()
        {
            MyApiService myApiService = new MyApiService();
            CountryList col = await myApiService.SelectAllCountry();
            return col;
        }
       

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string countryName= this.countryCombo.SelectedItem.ToString();
            string cityName = this.cityCombo.SelectedItem.ToString();
            CityList cityList = await Cities1();
            city123 = cityList.Find(x => x.CityName == cityName);
            MainWindow.mFrame.Content =new CityUserControlPage(cityName, countryName);

            
        }

        private void countryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cit();
        }
    }
}
