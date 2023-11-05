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
            if (Manager.UserManager.SignedInUser.GetType() == typeof(Admin))
            {
                StckPanelTravel.IsEnabled = false;
            }
            else
            {
                StckPanelTravel.IsEnabled = true;
            }
            if (Manager.UserManager.SignedInUser != null)
            {
                StckPanelTravel.Visibility = Visibility.Visible;
                StckPanelMiddle.Visibility = Visibility.Visible;
                BtnUserDetails.Visibility = Visibility.Visible;
                BtnUserDetails.Content = Manager.UserManager.SignedInUser.UserName;
                TxtBxLogInStatus.Text = "Logged in as";
                return;
            }

            TxtBxLogInStatus.Text = "";
            BtnUserDetails.Content = "";
            StckPanelTravel.Visibility = Visibility.Hidden;
            BtnTravel.Visibility = Visibility.Hidden;
        }

        private void BtnTravel_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.Window.FrameMain.Content = Manager.TravelPage;
        }

        private void BtnViewTravels_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.Window.FrameMain.Content = Manager.ChooseTravelPagee;
            Manager.ChooseTravelPagee.UpdateGUI();
        }

        private void BtnUserDetails_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.UserDetailsPage.UpdateGUI();
            Manager.Window.FrameMain.Content = Manager.UserDetailsPage;
        }

        public void HideIt()
        {
            StckPanelMiddle.Visibility = Visibility.Hidden;
            StckPanelTravel.Visibility = Visibility.Hidden;
            BtnUserDetails.Visibility = Visibility.Hidden;
            TxtBxLogInStatus.Text = "";
        }

        private void BtnAboutTravelPal_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.Window.FrameMain.Content = Manager.AboutTravelPage;
        }
    }
}
