using model;
using MyService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Interaction logic for SynagogueChangesPage.xaml
    /// </summary>
    public partial class SynagogueChangesPage : Page
    {
        MyApiService myapi = new MyApiService();
        List<Synagogue> synagogue_list = new List<Synagogue>();
        Synagogue s = new Synagogue();
        public SynagogueChangesPage()
        {
            InitializeComponent();
        }
        public SynagogueChangesPage(City city)
        {
            InitializeComponent();
            Synagogue2(city);
        }
        public async Task Synagogue2(City ct)
        {
            MyApiService myApiService = new MyApiService();
            SynagogueList sl = await myApiService.SelectAllSynagogue();
            SynagogueList stl = new SynagogueList();
            int y = ct.Id;
            try
            {
                stl = new SynagogueList(sl.FindAll(x => x.CityCode.Id == y));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            this.synagogueList.ItemsSource = stl;

        }

        private void SynagogueList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (synagogueList.SelectedItem != null)
            {
                s = synagogueList.SelectedItem as Synagogue;
                this.UpdateSynagogue.Visibility = Visibility.Visible;
                a.Text = s.Adress;
                MessageBox.Show(s.OpenHour.ToString());
                o.Text = s.OpenHour.ToString();
                c.Text = s.CloseHour.ToString();
                ds.Text = s.Id.ToString();
            }
        }

        private async void UpdateSynagogue_Click(object sender, RoutedEventArgs e)
        {
            synagogueList.ItemsSource = null;
            s.Adress = this.a.Text.ToString();
            s.OpenHour = TimeOnly.Parse(this.o.Text.ToString());
            s.CloseHour = TimeOnly.Parse(this.c.Text.ToString());
            this.a.Text = "";
            this.o.Text = "";
            this.c.Text = "";
            this.ds.Text = "";
            await myapi.UpdateAsSynagogue(s);
            Synagogue2(SearcherPage.city123);
            synagogueList.SelectedItem = null;
        }

        private void DeleteSynagogue_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            s = new Synagogue();
            s.Adress = this.newAdress.Text;
            s.CityCode = SearcherPage.city123;

            s.Adress = this.newAdress.Text;
            s.OpenHour = TimeOnly.Parse(this.o.Text.ToString());
            s.CloseHour = TimeOnly.Parse(this.c.Text.ToString());

            await myapi.InsertAsSynagogue(s);
            Synagogue2(SearcherPage.city123);
        }
    }
}
