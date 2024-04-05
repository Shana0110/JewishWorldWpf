using model;
using MyService;
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
using System.Diagnostics;

namespace JewishWorldWpf
{
    /// <summary>
    /// Interaction logic for KosherChangesPage.xaml
    /// </summary>
    public partial class KosherChangesPage : Page
    {
        MyApiService myapi = new MyApiService();
        List<KosherRestaurant> kosher_list = new List<KosherRestaurant>();
        KosherRestaurant k =new KosherRestaurant() ;
        public KosherChangesPage()
        {
            InitializeComponent();
            
        }
        public KosherChangesPage(City city)
        {
            InitializeComponent();
            Kosher2(city);

        }
        public async Task Kosher2(City ct)
        {
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
            this.kosherList.ItemsSource = ktl;
        }

        
    

        private async void UpdateName_Click(object sender, RoutedEventArgs e)
        {
            kosherList.ItemsSource = null;
            k.Name = this.n.Text.ToString();
            k.Adress = this.a.Text.ToString();
            k.Telephone = this.t.Text.ToString();
            k.TypeOfFood = this.f.Text.ToString();
            this.n.Text = "";
            this.a.Text = "";
            this.t.Text = "";
            this.f.Text = "";
            this.dn.Text = "";
            await myapi.UpdateAsKosherRestaurant(k);
            Kosher2(SearcherPage.city123);
            kosherList.SelectedItem = null;
        }

        
        private async void DeleteRestaurant_Click(object sender, RoutedEventArgs e)
        {
            MyApiService myApiService = new MyApiService();
            KosherRestaurantList kl = await myApiService.SelectAllKosherRestaurant();
            int y = int.Parse(dn.Text.ToString());
            try
            {
                k = (KosherRestaurant)(kl.Find(x => x.Id == y));
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.Message);
            }
            n.Text = "";
            a.Text = "";
            dn.Text = "";
            t.Text = "";
            f.Text = "";
            MessageBox.Show(k.ToString());
            await myApiService.DeleteAsKosherRestaurant(k);
            Kosher2(SearcherPage.city123);
            kosherList.SelectedItem = null;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            k = new KosherRestaurant();
            k.Adress = this.newAdress.Text;
            k.CityCode = SearcherPage.city123;

            k.Name = this.newName.Text;
            k.Adress = this.newAdress.Text;
            k.Telephone = this.newtel.Text;
            k.TypeOfFood = this.newFt.Text;
            await myapi.InsertAsKosherRestaurant(k);
            Kosher2(SearcherPage.city123);
           


        }

        private void lstView3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (kosherList.SelectedItem != null)
            {
                k = kosherList.SelectedItem as KosherRestaurant;
                this.UpdateName.Visibility = Visibility.Visible;
                n.Text = k.Name;
                a.Text = k.Adress;
                t.Text = k.Telephone;
                f.Text = k.TypeOfFood;
                dn.Text = k.Id.ToString();

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
       

        

       
        
    }
}
