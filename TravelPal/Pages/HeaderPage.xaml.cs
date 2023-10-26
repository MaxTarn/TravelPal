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

namespace TravelPal.Pages
{
    /// <summary>
    /// Interaction logic for HeaderPage.xaml
    /// </summary>
    public partial class HeaderPage : Page
    {



        public HeaderPage()
        {
            InitializeComponent();
        }

        private void BtnExitApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void UpdateGUI()
        {
            if (Manager.UserManager.SignedInUser != null)
            {
                StckPanelTravel.Visibility = Visibility.Visible;
                TxtBxUserName.Text = Manager.UserManager.SignedInUser.UserName;
                TxtBxLogInStatus.Text = "Logged in as";
                return;
            }

            TxtBxLogInStatus.Text = "";
            TxtBxUserName.Text = "";
            LblTravelHeadline.Visibility = Visibility.Hidden;
            BtnTravel.Visibility = Visibility.Hidden;
        }

        private void BtnTravel_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.Window.FrameMain.Content = Manager.TravelPage;
            Manager.TravelPage.UpdateGUI();
        }
    }
}
