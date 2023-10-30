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

namespace TravelPal.Pages
{
    /// <summary>
    /// Interaction logic for TravelPage.xaml
    /// </summary>
    public partial class TravelPage : Page
    {
        public bool Testr { get; set; } = false;
        public TravelPage()
        {
            InitializeComponent();
        }

        public void UpdateGUI()
        {
            ComboBxTravels.Items.Clear();
            if (Manager.UserManager.SignedInUser?.Travels.Count <= 0)
            {
                ComboBoxItem defaultEntry = new ComboBoxItem();
                defaultEntry.Content = "No Travels found.";
                ComboBxTravels.Items.Add(defaultEntry);
                ComboBxTravels.SelectedIndex = 0;
                ComboBxTravels.IsEditable = false;
                return;
            }
        }

        private void BtnCreateNewTravel_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Content = Manager.AddNewTravelPage;
        }



    }
}
