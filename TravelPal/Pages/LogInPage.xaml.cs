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
using TravelPal.Classes;

namespace TravelPal.Pages
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LogInPage()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            bool goodLogin = Manager.UserManager.LogIn(UserName, Password);

            if (!goodLogin)
            {
                LblErrorInfo.Content = "Could not log in!";
                return;
            }

            Manager.HeaderPage.TxtBxLogInStatus.Text = "Logged in as";
            Manager.HeaderPage.TxtBxUserName.Text = Manager.UserManager.SignedInUser.UserName;
        }
    }
}
