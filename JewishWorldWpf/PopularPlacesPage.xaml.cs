using Microsoft.Win32;
using model;
using MyService;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PopularPlacesPage.xaml
    /// </summary>
    public partial class PopularPlacesPage : Page
    {
        private PopularPlacesList pps;
        private City currentCity = new();
        public PopularPlacesPage()
        {
            InitializeComponent();
        }
        public PopularPlacesPage(City c)
        {
            InitializeComponent();
            currentCity = c;
            if (LoginPage.isManager == true)
            {
                this.stk.Visibility= Visibility.Visible;
            }
            PpCityName.Text = "Popular Places in "+ c.CityName;
            AllPopular(c.Id);

        }
        public async Task<PopularPlacesList> Popular()
        {
            MyApiService apiService = new MyApiService();
            pps = await apiService.SelectAllPopularPlaces();
            return pps;
        }
        public async void AllPopular(int id)
        {
            PopularPlacesList x = await Popular();
            x = new PopularPlacesList(x.Where(x => x.CityCode.Id == id));
            foreach (PopularPlace p in x)
            {
                myWrapPanel.Children.Add(new PopulaPlacesControl(p));
            }

        }


      

    }

}

