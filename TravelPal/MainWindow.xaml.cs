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
using TravelPal.Managers;
using TravelPal.Pages;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool ShowSplashScreen { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            UpdateGUI();
        }

        public void UpdateGUI()
        {
            FrameHeader.Content = Manager.HeaderPage;
            if (ShowSplashScreen) FrameMain.Content = Manager.SplashScreenPage;
        }
    }
}
