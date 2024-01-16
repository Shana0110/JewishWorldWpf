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
using System.Xml.Linq;

namespace JewishWorldWpf
{
    /// <summary>
    /// Interaction logic for CityUserControlPage.xaml
    /// </summary>
    public partial class CityUserControlPage : Page
    {
        public CityUserControlPage()
        {
            InitializeComponent();
            
        }
        public CityUserControlPage(string cityName ,string countryName)
        {
            InitializeComponent();
            var x= new CityControl1(cityName);
            mainGrid.Children.Add(x);
        }
    }
}
