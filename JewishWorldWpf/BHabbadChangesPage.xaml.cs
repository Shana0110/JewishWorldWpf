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
    /// Interaction logic for HabbadChangesPage.xaml
    /// </summary>
    public partial class HabbadChangesPage : Page
    {
        MyApiService myapi = new MyApiService();
        List<BeitHabbad> habbad_list = new List<BeitHabbad>();
        BeitHabbad b = new BeitHabbad();
        public HabbadChangesPage()
        {
            InitializeComponent();
        }
        public HabbadChangesPage(City city)
        {
            InitializeComponent();
            BeitHabbad2(city);
        }
        public async Task BeitHabbad2(City ct)
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
            this.bHabbadList.ItemsSource = btl;

        }

        private void HabbadList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bHabbadList.SelectedItem != null)
            {
                b = bHabbadList.SelectedItem as BeitHabbad;
                this.UpdateHabbad.Visibility = Visibility.Visible;
                em.Text = b.Email;
                a.Text = b.Adress;
                t.Text = b.Telephone;
                dh.Text = b.Id.ToString();

            }
        }

        private async void UpdateHabba_Click(object sender, RoutedEventArgs e)
         {
            bHabbadList.ItemsSource = null;
            b.Email = this.em.Text.ToString();
            b.Adress = this.a.Text.ToString();
            b.Telephone = this.t.Text.ToString();
            this.em.Text = "";
            this.a.Text = "";
            this.t.Text = "";
            this.dh.Text = "";
            await myapi.UpdateAsBeitHabbad(b);
            BeitHabbad2(SearcherPage.city123);
            bHabbadList.SelectedItem = null;
        }

        private async void DeleteHabbad_Click(object sender, RoutedEventArgs e)
        {
            MyApiService myApiService = new MyApiService();
            BeitHabbadList bl = await myApiService.SelectAllBeitHabbad();
            int y = int.Parse(dh.Text.ToString());
            try
            {
                b = (BeitHabbad)(bl.Find(x => x.Id == y));
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.Message);
            }
            a.Text = "";
            dh.Text = "";
            t.Text = "";
            em.Text = "";
            MessageBox.Show(b.ToString());
            await myApiService.DeleteAsBeitHabbad(b);
            BeitHabbad2(SearcherPage.city123);
            bHabbadList.SelectedItem = null;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {

            b = new BeitHabbad();
            b.Adress = this.newAdress.Text;
            b.CityCode = SearcherPage.city123;

            b.Email = this.newEmail.Text;
            b.Adress = this.newAdress.Text;
            b.Telephone = this.newtel.Text;
           
            await myapi.InsertAsBeitHabbad(b);
            BeitHabbad2(SearcherPage.city123);
        }
    }
}
