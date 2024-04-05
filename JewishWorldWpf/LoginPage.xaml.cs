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

namespace JewishWorldWpf
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    ///
    public partial class LoginPage : Page
    {
        private UserList user = new UserList();
        public static User menahelUser=new User() { Name = "Shana", Code = "0110" };
        
        public static bool isManager=false;
        public LoginPage()
        {
            InitializeComponent();
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //User1();
            MyApiService myApiService = new MyApiService();
            UserList user1 = await myApiService.SelectAllUser();
            User myUser = user1.Find(u => u.Name == UserName.Text && u.Code == Code.Text);
            if (myUser != null)
            {

               
                if(myUser.Code==menahelUser.Code&& myUser.Name==menahelUser.Name)
                {
                    isManager = true;
                }
                else
                {
                    isManager= false;
                }
                MainWindow.mFrame.Content = new SearcherPage();
            }
            
            else
                    MessageBox.Show("The password or the is incorect,Maybe you need to sign in");  
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.UserName.Text = "Shana";
            this.Code.Text = "0110";
        }
       
    }
}
