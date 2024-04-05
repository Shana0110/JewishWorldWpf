
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
using static System.Net.Mime.MediaTypeNames;

namespace JewishWorldWpf
{
    /// <summary>
    /// Interaction logic for PopulaPlacesControl.xaml
    /// </summary>
    public partial class PopulaPlacesControl : UserControl
    {
        public PopulaPlacesControl()
        {
            InitializeComponent();
        }
        public PopulaPlacesControl(PopularPlace pp)
        {
            InitializeComponent();
          
            DoJob(pp);
            PpAdress.Text = pp.Adress;

        }
        private async void DoJob(PopularPlace pp)
        {//להביא ולהציג תמונה מבסיס נתונים
            string st = pp.Photo;
            byte[] imgStr = Convert.FromBase64String(st);
            PpPhoto.Source = ByteImageConverter.ByteToImage(imgStr);
        }

       
    }
}
