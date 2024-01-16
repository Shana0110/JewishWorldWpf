using model;
using MyService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SynagogePage.xaml
    /// </summary>
    public partial class SynagogePage : Page
    {
       
        public SynagogePage()
        {
            InitializeComponent();
        }
        public SynagogePage(City city)
        {
            InitializeComponent();
            Synagogue1(city);


        }
        public async Task Synagogue1(City ct)
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
            
            this.cityName.Text = ct.CityName;
            this.synagogueList.ItemsSource = stl;
            
        }

    }
}
