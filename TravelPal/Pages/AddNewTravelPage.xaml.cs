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
using TravelPal.Interfaces;

namespace TravelPal.Pages
{
    /// <summary>
    /// Interaction logic for AddNewTravelPage.xaml
    /// </summary>
    public partial class AddNewTravelPage : Page
    {
        public string? TravelName { get; set; }
        public Country? FromCountry { get; set; }
        public Country? ToCountry { get; set; }
        public DateTime? StartDay { get; set; } = DateTime.Now;
        public DateTime? EndDay { get; set; } = DateTime.Now;
        public List<IPackingListItem> PackingList { get; set; } = new();
        public string? TripType { get; set; }
        public bool? IsAllInclusive { get; set; }
        public string? WorkDetails { get; set; }



        public AddNewTravelPage()
        {
            InitializeComponent();
        }


        private void ChkBxEuCountryDepart_Checked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesDepart.Items.Clear();
            foreach (Country country in Country.EUCountries)
            {
                ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
                ComboBxCountriesDepart.Items.Add(listEntry);
            }
        }

        private void ChkBxEuCountry_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesDepart.Items.Clear();
            foreach (Country country in Country.NonEUCountries)
            {

                ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
                ComboBxCountriesDepart.Items.Add(listEntry);
            }
        }

        private void ChkBxEuCountryArrival_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesArrival.Items.Clear();
            foreach (Country country in Country.NonEUCountries)
            {

                ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
                ComboBxCountriesArrival.Items.Add(listEntry);
            }
        }

        private void ChkBxEuCountryArrival_OnChecked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesArrival.Items.Clear();
            foreach (Country country in Country.EUCountries)
            {
                ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
                ComboBxCountriesArrival.Items.Add(listEntry);
            }
        }


        private void ComboBxTripType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LblAllInclusive.Visibility = Visibility.Hidden;
            ChkBxIsAllInclusive.Visibility = Visibility.Hidden;
            LblWorkTrip.Visibility = Visibility.Hidden;
            TxtBxWorkTrip.Visibility = Visibility.Hidden;

            TripType = (ComboBxTripType.SelectedItem as ComboBoxItem)?.Tag.ToString();

            if (TripType.Equals("Vacation"))
            {
                LblAllInclusive.Visibility = Visibility.Visible;
                ChkBxIsAllInclusive.Visibility = Visibility.Visible;
            }
            if (TripType.Equals("Work Trip"))
            {
                LblWorkTrip.Visibility = Visibility.Visible;
                TxtBxWorkTrip.Visibility = Visibility.Visible;
            }
        }

        private void BtnCreateNewTravel_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TripType);
        }
    }
}
