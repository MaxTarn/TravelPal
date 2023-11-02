using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ViewTheTravelPage.xaml
    /// </summary>
    public partial class ViewTheTravelPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





        private bool _isUserEditable;
        public bool IsUserEditable
        {
            get => _isUserEditable;
            set
            {
                if (value == _isUserEditable) return;
                _isUserEditable = value;
                OnPropertyChanged();
            }
        }

        private string? _travelName;
        public string? TravelName
        {
            get => _travelName;
            set
            {
                if (_travelName == value) return;
                _travelName = value;
                OnPropertyChanged(nameof(TravelName));
            }
        }

        private Country? _country;
        public Country? FromCountry
        {
            get => _country;
            set
            {
                if (_country == value) return;
                _country = value;
                OnPropertyChanged(nameof(FromCountry));
            }
        }

        private ComboBoxItem? _fromCountrySelectedItem;
        public ComboBoxItem? FromCountrySelectedItem
        {
            get => _fromCountrySelectedItem;
            set
            {
                if (_fromCountrySelectedItem == value) return;
                _fromCountrySelectedItem = value;
                FromCountry = FromCountrySelectedItem?.Tag as Country;

            }
        }

        private Country? _toCountry;
        public Country? ToCountry
        {
            get => _toCountry;
            set
            {
                if (_toCountry == value) return;
                _toCountry = value;
                OnPropertyChanged(nameof(ToCountry));
            }
        }

        private ComboBoxItem? _toCountrySelectedItem;
        public ComboBoxItem? ToCountrySelectedItem
        {
            get => _toCountrySelectedItem;
            set
            {
                if (_toCountrySelectedItem == value) return;
                _toCountrySelectedItem = value;
                ToCountry = ToCountrySelectedItem?.Tag as Country;
            }
        }

        private string? _arrivalCity;
        public string? ArrivalCity
        {
            get => _arrivalCity;
            set
            {
                if (_arrivalCity == value) return;
                _arrivalCity = value;
                OnPropertyChanged(nameof(ArrivalCity));
            }
        }

        private DateTime? _startDay;
        public DateTime? StartDay
        {
            get => _startDay;
            set
            {
                if (_startDay == value) return;
                _startDay = value;
                OnPropertyChanged(nameof(StartDay));
            }
        }
        private DateTime? _endDay;
        public DateTime? EndDay
        {
            get => _endDay;
            set
            {
                if (_endDay == value) return;
                _endDay = value;
                OnPropertyChanged(nameof(EndDay));
            }
        }

        private bool? _isWorkTrip;
        public bool? IsWorkTrip
        {
            get => _isWorkTrip;
            set
            {
                if (IsWorkTrip == value) return;
                _isWorkTrip = value;
                OnPropertyChanged(nameof(IsWorkTrip));
            }
        }

        private bool? _isVacation;
        public bool? IsVacation
        {
            get => _isVacation;
            set
            {
                if (_isVacation == value) return;
                _isVacation = value;
                OnPropertyChanged(nameof(IsVacation));
            }
        }

        private bool _isAllInclusive;
        public bool IsAllInclusive
        {
            get => _isAllInclusive;
            set
            {
                if (_isAllInclusive == value) return;
                _isAllInclusive = value;
                OnPropertyChanged(nameof(IsAllInclusive));
            }
        }

        private string? _workDetails;
        public string? WorkDetails
        {
            get => _workDetails;
            set
            {
                if (_workDetails == value) return;
                _workDetails = value;
                OnPropertyChanged(nameof(WorkDetails));
            }
        }

        private int? _travellerCount;
        public int? TravellerCount
        {
            get => _travellerCount;
            set
            {
                if (_travellerCount == value) return;

                _travellerCount = value;
                OnPropertyChanged(nameof(TravellerCount));

            }
        }

        private ComboBoxItem? _typeOfTrip;

        public ComboBoxItem? TypeOfTrip
        {
            get => _typeOfTrip;
            set
            {
                if (_typeOfTrip == value) return;
                _typeOfTrip = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ListViewItem>? _travels = new();

        public ObservableCollection<ListViewItem>? Travels
        {
            get => _travels;
            set
            {
                if (_travels == value) return;
                _travels = value;
                OnPropertyChanged(nameof(Travels));
            }
        }

        private ListViewItem? _selectedItem;

        public ListViewItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value) return;
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


















        public ViewTheTravelPage()
        {
            InitializeComponent();
        }

        public void UpdateGUI(Travel showThisTravel)
        {
            IsUserEditable = false;
            if (Manager.UserManager.SignedInUser == null) return;
            TravelName = showThisTravel.TravelName;
            FromCountry = showThisTravel.FromCountry;
            ToCountry = showThisTravel.ToCountry;
            ArrivalCity = showThisTravel.Destination;
            StartDay = showThisTravel.StartDate;
            EndDay = showThisTravel.EndDate;
            TravellerCount = showThisTravel.Travellers;
            showThisTravel.PackingList.ForEach(packingItem =>
            {
                ListViewItem container = new();
                container.Tag = packingItem;
                container.Content = packingItem.Name;
                Travels.Add(container);
            });

            if ((bool)showThisTravel.IsVacation)
            {
                ComboBxTripType.SelectedIndex = 0;  // if indexing starts at 0 this is the Vacation comboboxitem
                LblAllInclusive.Visibility = Visibility.Visible;
                ChkBxIsAllInclusive.Visibility = Visibility.Visible;

                LblWorkTrip.Visibility = Visibility.Hidden;
                TxtBxWorkTrip.Visibility = Visibility.Hidden;
            }

            if ((bool)showThisTravel.IsWorkTrip)
            {
                ComboBxTripType.SelectedIndex = 1;  // if indexing starts at 0 this is the Work Trip comboboxitem
                LblAllInclusive.Visibility = Visibility.Hidden;
                ChkBxIsAllInclusive.Visibility = Visibility.Hidden;

                LblWorkTrip.Visibility = Visibility.Visible;
                TxtBxWorkTrip.Visibility = Visibility.Visible;
            }

        }


        public void ChkBxEuCountryDepart_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesDepart.Items.Clear();
            Country.NonEUCountries.ForEach(country =>
            {
                ComboBoxItem container = new();
                container.Tag = country;
                container.Content = country.ToString();
                ComboBxCountriesDepart.Items.Add(container);
            });
        }

        public void ChkBxEuCountryDepart_OnChecked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesDepart.Items.Clear();
            Country.EUCountries.ForEach(country =>
            {
                ComboBoxItem container = new();
                container.Tag = country;
                container.Content = country.ToString();
                ComboBxCountriesDepart.Items.Add(container);
            });
        }

        public void ChkBxEuCountryArrival_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesArrival.Items.Clear();
            Country.NonEUCountries.ForEach(country =>
            {
                ComboBoxItem container = new();
                container.Tag = country;
                container.Content = country.ToString();
                ComboBxCountriesArrival.Items.Add(container);
            });
        }

        private void ChkBxEuCountryArrival_OnChecked(object sender, RoutedEventArgs e)
        {
            ComboBxCountriesArrival.Items.Clear();
            Country.EUCountries.ForEach(country =>
            {
                ComboBoxItem container = new();
                container.Tag = country;
                container.Content = country.ToString();
                ComboBxCountriesArrival.Items.Add(container);
            });
        }

        private void BtnIncrementTravellersUp_OnClick(object sender, RoutedEventArgs e)
        {
            TravellerCount++;
        }

        private void BtnIncrementTravellersDown_OnClick(object sender, RoutedEventArgs e)
        {
            if (TravellerCount <= 1) return;
            TravellerCount--;
        }
    }
}
