﻿using System;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyService;
using static System.Net.Mime.MediaTypeNames;

namespace JewishWorldWpf
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            var x = new Uri("/Pic/MagenDavidPhoto.jpg", UriKind.Relative);
            //WelcomePic.Source = new BitmapImage(new Uri("/Pic/MagenDavidPhoto.jpg", UriKind.Relative));
    

        }

        private void Log(object sender, RoutedEventArgs e)
        {
           MainWindow.mFrame.Content=new LoginPage();
            
        }

        private void Sign(object sender, RoutedEventArgs e)
        {
            MainWindow.mFrame.Content=new SignInPage();
            
        }
    }
}
