using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
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
    /// Interaction logic for ViewTheTravelPage.xaml
    /// </summary>
    public partial class ViewTheTravelPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private Travel? OldTravel = null;







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
                OnPropertyChanged();
            }
        }

        private bool _fromCountryIsEu;
        public bool FromCountryIsEu
        {
            get => _fromCountryIsEu;
            set
            {
                if (_fromCountryIsEu == value) return;
                _fromCountryIsEu = value;
                OnPropertyChanged();
            }
        }


        private bool _toCountryIsEu;
        public bool ToCountryIsEu
        {
            get => _toCountryIsEu;
            set
            {
                if (_toCountryIsEu == value) return;
                _toCountryIsEu = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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


        private ObservableCollection<ListViewItem>? _packingListItemses = new();
        public ObservableCollection<ListViewItem>? PackingListItems
        {
            get => _packingListItemses;
            set
            {
                if (_packingListItemses == value) return;
                _packingListItemses = value;
                OnPropertyChanged(nameof(PackingListItems));
            }
        }









        public ViewTheTravelPage()
        {
            InitializeComponent();
            IsAllInclusive = false;
            IsUserEditable = false;
            FromCountryIsEu = false;
            ToCountryIsEu = false;
        }

        public void UpdateGUI(Travel showThisTravel)
        {
            IsAllInclusive = false;
            IsUserEditable = false;
            FromCountryIsEu = false;
            ToCountryIsEu = false;
            TravellerCount = 1;


            if (showThisTravel == null)
            {
                Manager.Window.FrameMain.Content = Manager.ChooseTravelPagee;
                return;
            }
            ComboBxCountriesArrival.Items.Clear();
            ComboBxCountriesDepart.Items.Clear();
            OldTravel = showThisTravel;


            IsUserEditable = false;
            //if (Manager.UserManager.SignedInUser == null) return;
            TravelName = showThisTravel.TravelName;
            ArrivalCity = showThisTravel.Destination;
            StartDay = showThisTravel.StartDate;
            EndDay = showThisTravel.EndDate;
            TravellerCount = showThisTravel.Travellers;
            FromCountry = showThisTravel.FromCountry;
            ToCountry = showThisTravel.ToCountry;

            if (showThisTravel.FromCountry.IsEUCountry()) AddEuCountriesToFromCountry();
            if (showThisTravel.FromCountry.IsNonEUCountry()) AddNonEuCountriesToFromCountry();

            if (showThisTravel.ToCountry.IsEUCountry()) AddEuCountriesToArrivialCountry();
            if (showThisTravel.ToCountry.IsNonEUCountry()) AddNonEuCountriesToArrivalCountry();

            SetFromCountry(FromCountry);
            SetToCountry(ToCountry);




            PackingListItems = new();
            showThisTravel.PackingList.ForEach(packingItem =>
            {
                ListViewItem container = new();
                container.Tag = packingItem;
                container.Content = packingItem.Name;
                PackingListItems.Add(container);
            });

            if (showThisTravel.IsVacation == true)
            {
                ComboBxTripType.SelectedIndex = 0;  // if indexing starts at 0 this is the Vacation comboboxitem
                LblAllInclusive.Visibility = Visibility.Visible;
                ChkBxIsAllInclusive.Visibility = Visibility.Visible;

                LblWorkTrip.Visibility = Visibility.Hidden;
                TxtBxWorkTrip.Visibility = Visibility.Hidden;
            }

            if (showThisTravel.IsWorkTrip == true)
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

        private void SetFromCountry(Country country)
        {
            foreach (ComboBoxItem container in ComboBxCountriesDepart.Items)
            {
                if ((container.Tag as Country).ToString() == country.ToString()) FromCountrySelectedItem = container;
            }
        }

        private void SetToCountry(Country country)
        {
            foreach (ComboBoxItem container in ComboBxCountriesArrival.Items)
            {
                if ((container.Tag as Country).ToString() == country.ToString()) ToCountrySelectedItem = container;
            }
        }
        private void AddEuCountriesToFromCountry()
        {
            ComboBxCountriesDepart.Items.Clear();
            ChkBxEuCountryDepart.IsChecked = true;
            foreach (Country country in Country.EUCountries)
            {
                AddComboBoxItem(country, ComboBxCountriesDepart);
            }
        }

        private void AddNonEuCountriesToFromCountry()
        {
            ComboBxCountriesDepart.Items.Clear();
            ChkBxEuCountryDepart.IsChecked = false;
            foreach (Country country in Country.NonEUCountries)
            {
                AddComboBoxItem(country, ComboBxCountriesDepart);
            }
        }

        private void AddEuCountriesToArrivialCountry()
        {
            ComboBxCountriesArrival.Items.Clear();
            ChkBxEuCountryArrival.IsChecked = true;
            foreach (Country country in Country.EUCountries)
            {
                AddComboBoxItem(country, ComboBxCountriesArrival);
            }
        }

        private void AddNonEuCountriesToArrivalCountry()
        {
            ComboBxCountriesArrival.Items.Clear();
            ChkBxEuCountryArrival.IsChecked = false;
            foreach (Country country in Country.NonEUCountries)
            {
                AddComboBoxItem(country, ComboBxCountriesArrival);
            }
        }

        private void AddComboBoxItem(Country addThisCountry, ComboBox inThisComboBox)
        {
            ComboBoxItem container = new();
            container.Tag = addThisCountry;
            container.Content = addThisCountry.ToString();
            inThisComboBox.Items.Add(container);
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

        private void BtnEnableDisableEdit_Click(object sender, RoutedEventArgs e)
        {
            IsUserEditable = !IsUserEditable;
            MessageBox.Show("fg vds<");
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string? errorMessege = ValidateFields();
            if (errorMessege != null)
            {
                MessageBox.Show(errorMessege);
                return;
            }
            Travel newTravel = new Travel();

            newTravel.TravelName = TravelName;
            newTravel.Destination = ArrivalCity;
            newTravel.FromCountry = FromCountry;
            newTravel.ToCountry = ToCountry;
            newTravel.Travellers = TravellerCount;
            foreach (var packingListItem in PackingListItems)
            {
                newTravel.PackingList.Add(packingListItem.Tag as IPackingListItem);
            }

            newTravel.StartDate = StartDay;
            newTravel.EndDate = EndDay;
            newTravel.IsWorkTrip = IsWorkTrip;
            newTravel.WorkTripDetails = WorkDetails;
            newTravel.IsVacation = IsVacation;
            newTravel.IsAllInclusive = IsAllInclusive;

            foreach (IUser user in Manager.UserManager.Users)
            {
                if (user.GetType() == typeof(Admin)) continue;

                Travel? travel = user.Travels.Find(trvl => trvl == OldTravel);
                if (travel != null)
                {
                    Manager.UserManager.Users.Find(usr => usr == user).Travels.Remove(travel);
                    Manager.UserManager.Users.Find(usr => usr == user).AddTravel(newTravel);
                }
            }
        }

        private string? ValidateFields()
        {
            if (string.IsNullOrEmpty(TravelName)) return "Travel name is empty";
            if (FromCountrySelectedItem == null) return "choose a deparing country";
            if (ToCountrySelectedItem == null) return "choose a arrivial country";
            if (string.IsNullOrEmpty(ArrivalCity)) return "Write a arrivial city";
            if (StartDay == null || StartDay.Equals(null)) return "Choose a start dat";
            if (EndDay == null || EndDay.Equals(null)) return "Choose a end date";
            if (TravellerCount == null) return "enter the number of travellers";
            if (TypeOfTrip == null) return "choose a trip type";

            if (TravelName.Length <= 3) return "Trip anem is too short";
            if (FromCountry == ToCountry) return "cannt leave from and arrive to the same country";
            if (ArrivalCity.Length <= 1) return "arrivial city name is too short";
            if (StartDay > EndDay) return "Start day cannot be after end day";
            if (EndDay == StartDay) return "cannot leave and arrive on the same day";
            if (EndDay < DateTime.Now) return "Arrivial date muste be in the future";
            if (TravellerCount <= 0) return "thre must be atleast 1 traveller";
            return null;
        }




    }
}
