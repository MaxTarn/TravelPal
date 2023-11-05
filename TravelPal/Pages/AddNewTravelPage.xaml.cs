using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;
using TravelPal.Classes;
using TravelPal.Interfaces;

namespace TravelPal.Pages;

/// <summary>
/// Interaction logic for AddNewTravelPage.xaml
/// </summary>
public partial class AddNewTravelPage : Page, INotifyPropertyChanged
{



    //---------- Method and property for making databinding TwoWay----------


    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    //---------- Method and property for making databinding TwoWay END----------



    //---------- TwoWay Bound variables ----------

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

    private string? _tripType;
    public string? TripType
    {
        get => _tripType;
        set
        {
            if (_tripType == value) return;
            _tripType = value;
            OnPropertyChanged(nameof(TripType));
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










    private string? _errorMessegeText;
    public string? ErrorMessegeText
    {
        get => _errorMessegeText;
        set
        {
            if (_errorMessegeText == value) return;

            _errorMessegeText = value;
            OnPropertyChanged(nameof(ErrorMessegeText));

        }
    }

    //---------- TwoWay Bound variables END ----------



    //---------- Packing List ----------


    public ObservableCollection<IPackingListItem> PackingList { get; set; } = new();


    //---------- Packing List  END----------



    //---------- Constructor----------


    public AddNewTravelPage()
    {
        InitializeComponent();
        ChkBxEuCountry_OnUnchecked(null, null);
        ChkBxEuCountryArrival_OnUnchecked(null, null);

        FromCountry = (ComboBxCountriesDepart.Items.GetItemAt(1) as ComboBoxItem)?.Tag as Country;

        TravellerCount = 1;
        StartDay = DateTime.Now;
        EndDay = DateTime.Now;
        IsAllInclusive = false;
    }


    //---------- Constructor END----------



    //---------- Code-Behind methods, and various event handlers----------
    private void ChkBxEuCountryDepart_Checked(object sender, RoutedEventArgs e)
    {
        ComboBxCountriesDepart.Items.Clear();
        foreach (Country country in Country.EUCountries)
        {
            ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
            ComboBxCountriesDepart.Items.Add(listEntry);
        }
    }

    private void ChkBxEuCountry_OnUnchecked(object? sender, RoutedEventArgs? e)
    {
        ComboBxCountriesDepart.Items.Clear();
        foreach (Country country in Country.NonEUCountries)
        {

            ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
            ComboBxCountriesDepart.Items.Add(listEntry);
        }
    }

    private void ChkBxEuCountryArrival_OnUnchecked(object? sender, RoutedEventArgs? e)
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
            IsVacation = true;
            IsWorkTrip = false;

            TxtBxWorkTrip.Text = null;
            WorkDetails = null;

            LblAllInclusive.Visibility = Visibility.Visible;
            ChkBxIsAllInclusive.Visibility = Visibility.Visible;
        }

        if (TripType.Equals("Work Trip"))
        {
            IsVacation = false;
            IsWorkTrip = true;

            ChkBxIsAllInclusive.IsChecked = null;
            IsAllInclusive = false;

            LblWorkTrip.Visibility = Visibility.Visible;
            TxtBxWorkTrip.Visibility = Visibility.Visible;
        }
    }



    //so that if user somehow manages to work around the IsReadOnly=true this prevents all input into txtbx
    private void TxtBxTravellerCount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = true;
    }

    private void BtnIncrementTravellersUp_Click(object sender, RoutedEventArgs e)
    {
        if (TravellerCount < 1) return;
        if (TravellerCount >= 853) return; //biggest passenger plane can carry that many passengers
        TravellerCount++;
    }

    private void BtnIncrementTravellersDown_Click(object sender, RoutedEventArgs e)
    {
        if (TravellerCount <= 1) return;
        if (TravellerCount > 853) return; //biggest passenger plane can carry that many passengers
        TravellerCount--;
    }


    private void ComboBxToAndFromCountry_onSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AddDefaultItemsToPackingList();

    }

    //---------- Code-Behind methods, and various event handlers END----------



    //---------- Methods ----------

    /// <summary>
    /// Returns null when all fields are not null and the things entered are acceptable
    /// Returns a non empty string with the error messege if a field is not accepted
    /// </summary>
    /// <returns></returns>
    public string? ValidateFields()
    {
        // null checking
        if (TravelName == null) return "Trip Name:  is empty!";
        if (FromCountry == null) return "Choose a departing country";
        if (ToCountry == null) return "Choose a Arrival country!";
        if (ArrivalCity == null) return "Arriving to City:  is empty!";
        if (StartDay == null) return "Choose a Starting Date: !";
        if (EndDay == null) return "Choose an Ending Date:  !";
        if (TravellerCount == null) return "Travellers:  is empty!";
        if (TripType == null) return "Choose what Type Of Trip: it is!";


        //checkign ifg input is acceptable
        if (TravelName.Length <= 3) return "Write a longer Trip Name:   !";
        if (FromCountry.Equals(ToCountry)) return "You are departing from and arriving to the same country";
        if (ArrivalCity.Length <= 1) return "City name too short!";
        if (StartDay > EndDay) return "You cant depart after you arrive!";
        if (EndDay <= DateTime.Now) return "Ending date is either the same day as or earlier than today!";
        //if (StartDay.Equals(EndDay)) return "You cant depart and arrive on the same day!";


        return null;
    }
    private void AddDefaultItemsToPackingList()
    {
        //null checking
        if (FromCountrySelectedItem == null) return;
        if (ToCountrySelectedItem == null) return;

        // gets the passport if it already exists
        ListViewItem? itemToRemove = Manager.PackingListPage.PackingList.FirstOrDefault(item =>
        {
            var tag = item.Tag as TravelDocument;
            return tag?.Name == "Passport";
        });
        //removes the pasport
        if (itemToRemove != null)
        {
            Manager.PackingListPage.PackingList.Remove(itemToRemove);
        }

        IPackingListItem passport = new TravelDocument("Passport", true);
        ListViewItem container = new();

        if (FromCountry.IsEUCountry() && ToCountry.IsEUCountry()) (passport as TravelDocument).Required = false;

        Manager.PackingListPage.PackingList.Add(container);
        container.Tag = passport;
        string? containerContent = Utility.TruncateOrPadStringTo((container.Tag as TravelDocument)?.Name, (int)(int?)FindResource("PackingListFirstItemLength"));

        string req = "Required";
        string notReq = "Not Required";

        if ((bool)(container.Tag as TravelDocument)?.Required)
        {
            containerContent += " | " + Utility.TruncateOrPadStringTo(req, (int)(int?)FindResource("PackingListSecondItemLength"));

        }
        else
        {
            containerContent += " | " + Utility.TruncateOrPadStringTo(notReq, (int)(int?)FindResource("PackingListSecondItemLength"));
        }

        container.Content = containerContent;

    }

    public void ClearFields()
    {
        TravelName = "";
        ArrivalCity = "";
        StartDay = DateTime.Now;
        EndDay = DateTime.Now;
        TravellerCount = 1;

        ComboBxCountriesArrival.SelectedIndex = -1;
        ComboBxCountriesDepart.SelectedIndex = -1;
        DatePickrStarting.SelectedDate = DateTime.Now;
        DatePickrEnding.SelectedDate = DateTime.Now;
    }



    //---------- Methods END ----------

}
