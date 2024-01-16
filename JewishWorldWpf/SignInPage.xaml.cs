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
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private UserList user = new UserList();
        public SignInPage()
        {
            InitializeComponent();
        }

        private async void  Button_Click(object sender, RoutedEventArgs e)
        {

            this.user = await User1();
            User uss = new User() { Name = UserName.Text, Code = Code.Text };
                if (user.Find(x => x.Name == UserName.Text)!=null)
                {
                this.tkinout.Text = "You already have a count, you need to log in";
                }
                else if (uss.Name.Length < 2)
                {
                this.tkinout.Text = "Your name have to be more than 2 laters";
                }
                else if (uss.Name.Length > 7)
                {
                this.tkinout.Text = "Your name have to be less than 7 laters";
                }
    
                else 
                {
                    UserInsert(uss);
                    MainWindow.mFrame.Content = new SearcherPage();
                }
                

             
        }
        public async Task UserInsert(User us)
        {
            MyApiService myApiService = new MyApiService();
            await myApiService.InsertAsUser(us);
          
        }
        public async Task<UserList> User1()
        {
            MyApiService myApiService = new MyApiService();
            UserList u = await myApiService.SelectAllUser();
            return u;
        }
       
    }
}
