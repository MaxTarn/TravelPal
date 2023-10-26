using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
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

        private SolidColorBrush? _btnNoAccountForeground;
        private SolidColorBrush? _btnNoAccountBorderColor;

        public LogInPage()
        {
            InitializeComponent();

            _btnNoAccountForeground = (SolidColorBrush)BtnNoAccount.Foreground;
            _btnNoAccountBorderColor = (SolidColorBrush)BtnNoAccount.BorderBrush;
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string loginMessege = Manager.UserManager.LogIn(UserName, Password);

            if (!loginMessege.Equals(""))
            {
                LblErrorInfo.Content = loginMessege;
                return;
            }

            LblErrorInfo.Content = "";
            Manager.HeaderPage.UpdateGUI();
        }
        private void BtnNoAccount_Click(object sender, RoutedEventArgs e)
        {
            Manager.Window.FrameMain.Content = Manager.RegisterPage;
        }

        private void BtnNoAccount_OnMouseEnter(object sender, MouseEventArgs e)
        {
            BtnNoAccount.Foreground = new SolidColorBrush(Colors.Blue);
            BtnNoAccount.BorderBrush = new SolidColorBrush(Colors.Blue);
        }

        private void BtnNoAccount_OnMouseLeave(object sender, MouseEventArgs e)
        {
            BtnNoAccount.Foreground = _btnNoAccountForeground;
            BtnNoAccount.BorderBrush = _btnNoAccountBorderColor;
        }
    }
}
