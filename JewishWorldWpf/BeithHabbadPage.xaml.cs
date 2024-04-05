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
    /// Interaction logic for BeithHabbadPage.xaml
    /// </summary>
    public partial class BeithHabbadPage : Page
    {
        public BeithHabbadPage()
        {
            InitializeComponent();
        }
        public BeithHabbadPage(City city)
        {
            InitializeComponent();
            BeitHabbad1(city);
            if (LoginPage.isManager == true)
            {
                this.Menahel.Visibility = Visibility.Visible;
            }


        }
        public async Task BeitHabbad1(City ct)
        {
            MyApiService myApiService = new MyApiService();
            BeitHabbadList bl = await myApiService.SelectAllBeitHabbad();
            BeitHabbadList btl = new BeitHabbadList();
            int y = ct.Id;
            try
            {
                btl = new BeitHabbadList(bl.FindAll(x => x.CityCode.Id == y));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            this.cityName.Text = "Beith Habbads in "+ct.CityName;
            this.habbadList.ItemsSource = btl;

        }

        private void Menahel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mFrame.Content = new HabbadChangesPage(SearcherPage.city123);
        }
    }
}
