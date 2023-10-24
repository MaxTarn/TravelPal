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
using TravelPal.Managers;


namespace TravelPal.Pages
{
    /// <summary>
    /// Interaction logic for SplashScreenPage.xaml
    /// </summary>
    public partial class SplashScreenPage : Page
    {
        public SplashScreenPage()
        {
            InitializeComponent();
        }

        //TODO Combine TxtBlckLogoLogIn_OnMouseLeftButtonDown and ButtonBase_OnClick to same method
        private void TxtBlckLogoLogIn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Manager.Window.FrameMain.Content = Manager.LogInPage;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.Window.FrameMain.Content = Manager.LogInPage;


        }
    }
}
