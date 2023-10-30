using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TravelPal.Interfaces;

namespace TravelPal.Pages;

/// <summary>
/// Interaction logic for AddNewTravelPage.xaml
/// </summary>
public partial class AddNewTravelPage : Page, INotifyPropertyChanged
{



    //---------- Method and property for making databinding TwoWay----------


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    //---------- Method and property for making databinding TwoWay END----------



    //---------- Packing List ----------

    public List<IPackingListItem> PackingList { get; set; } = new();


    //---------- Packing List  END----------



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
            AddDefaultItemsToPackingList();
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
            FromCountry = FromCountrySelectedItem?.Tag as Country;
            AddDefaultItemsToPackingList();
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
        get => IsWorkTrip;
        set
        {
            if (IsWorkTrip == value) return;
            IsWorkTrip = value;
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

    private string? _nameOfItem;
    public string? NameOfItem
    {
        get => _nameOfItem;
        set
        {
            if (_nameOfItem == value) return;
            _nameOfItem = value;
            OnPropertyChanged(nameof(NameOfItem));

        }
    }

    private string? _infoAboutItem;
    public string? InfoAboutItem
    {
        get => _infoAboutItem;
        set
        {
            if (_infoAboutItem == value) return;
            _infoAboutItem = value;
            OnPropertyChanged(nameof(InfoAboutItem));

        }
    }

    private bool _itemIsRequired;
    public bool ItemIsRequired
    {
        get => _itemIsRequired;
        set
        {
            if (_itemIsRequired == value) return;
            _itemIsRequired = value;
            OnPropertyChanged(nameof(ItemIsRequired));

        }
    }

    private bool _itemIsTravelDocument;
    public bool ItemIsTravelDocument
    {
        get => _itemIsTravelDocument;
        set
        {
            if (_itemIsTravelDocument == value) return;
            _itemIsTravelDocument = value;
            OnPropertyChanged(nameof(ItemIsTravelDocument));

        }
    }

    private int? _itemCount;
    public int? ItemCount
    {
        get => _itemCount;
        set
        {
            if (_itemCount == value) return;

            _itemCount = value;
            OnPropertyChanged(nameof(ItemCount));

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



    //---------- Constructor----------


    public AddNewTravelPage()
    {
        InitializeComponent();
        ChkBxEuCountry_OnUnchecked(null, null);
        ChkBxEuCountryArrival_OnUnchecked(null, null);

        FromCountry = (ComboBxCountriesDepart.Items.GetItemAt(1) as ComboBoxItem).Tag as Country;

        ItemCount = 1;
        TravellerCount = 1;
        StartDay = DateTime.Now;
        EndDay = DateTime.Now;
        ItemIsRequired = false;
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
            TxtBxWorkTrip.Text = null;
            WorkDetails = null;

            LblAllInclusive.Visibility = Visibility.Visible;
            ChkBxIsAllInclusive.Visibility = Visibility.Visible;
        }

        if (TripType.Equals("Work Trip"))
        {
            ChkBxIsAllInclusive.IsChecked = null;
            IsAllInclusive = false;

            LblWorkTrip.Visibility = Visibility.Visible;
            TxtBxWorkTrip.Visibility = Visibility.Visible;
        }
    }

    private void BtnCreateNewTravel_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(Manager.UserManager.SignedInUser?.Travels.Count.ToString());
        ErrorMessegeText = ValidateFields();
        if (ErrorMessegeText != null) return;

        Travel newTravel = new Travel();
        newTravel.TravelName = TravelName;
        newTravel.Destination = ArrivalCity;
        newTravel.FromCountry = FromCountry;
        newTravel.ToCountry = ToCountry;
        newTravel.Travellers = TravellerCount;
        newTravel.PackingList = PackingList;
        newTravel.StartDate = StartDay;
        newTravel.EndDate = EndDay;
        newTravel.IsWorkTrip = IsWorkTrip;
        newTravel.WorkTripDetails = WorkDetails;
        newTravel.IsVacation = IsVacation;
        newTravel.IsAllInclusive = IsAllInclusive;

        Manager.UserManager.SignedInUser.AddTravel(newTravel);

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

    private void BtnItemIncrementDown_OnClick(object sender, RoutedEventArgs e)
    {
        ItemCount--;
    }

    private void BtnItemIncrementUp_OnClick(object sender, RoutedEventArgs e)
    {
        ItemCount++;
    }

    private void TxtBxItemCount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!char.IsDigit(e.Text, e.Text.Length - 1))
        {
            e.Handled = true;

        }
    }

    private void ChkBxItemIsTravelDocument_Checked(object sender, RoutedEventArgs e)
    {
        LblRequired.Visibility = Visibility.Visible;
        ChkBxItemIsRequired.Visibility = Visibility.Visible;

        LblItemCount.Visibility = Visibility.Hidden;
        StkPanlItemCount.Visibility = Visibility.Hidden;
        TxtBxItemCount.Text = "1";
        ItemCount = 1;
    }

    private void ChkBxItemIsTravelDocument_OnUnchecked(object sender, RoutedEventArgs e)
    {
        LblItemCount.Visibility = Visibility.Visible;
        StkPanlItemCount.Visibility = Visibility.Visible;

        LblRequired.Visibility = Visibility.Hidden;
        ChkBxItemIsRequired.Visibility = Visibility.Hidden;
    }

    private void ComboBxToAndFromCountry_onSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AddDefaultItemsToPackingList();

    }
    private void BtnAddItemToList_Click(object sender, RoutedEventArgs e)
    {
        //WHILE DEVELOPING 
        MessageBox.Show(StartDay.ToString());
        //WHILE DEVELOPING  END

        string? errorMessege = ValidItemFields();
        if (errorMessege != null)
        {
            TxtBlckError.Text = errorMessege;
            return;
        }

        if (ItemIsTravelDocument)
        {
            TravelDocument newTravelDocument = new(NameOfItem, ItemIsRequired);
            PackingList.Add(newTravelDocument);
            UpdatePackingListGUI();
        }
    }
    private void BtnDeveloperButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(Manager.UserManager.SignedInUser?.Travels.Count.ToString());
    }

    //---------- Code-Behind methods, and various event handlers END----------



    //---------- Methods ----------
    private void UpdatePackingListGUI()
    {
        ComboBxPackingList.Items.Clear();

        foreach (IPackingListItem packItem in PackingList)
        {
            ComboBoxItem packItemContainer = new ComboBoxItem();
            packItemContainer.Tag = packItem;
            packItemContainer.Content = packItem.Name;
            ComboBxPackingList.Items.Add(packItemContainer);
        }
    }
    /// <summary>
    /// Returns null when all fields are not null and the things entered are acceptable
    /// Returns a non empty string with the error messege if a field is not accepted
    /// </summary>
    /// <returns></returns>
    private string? ValidateFields()
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
        //if (StartDay.Equals(EndDay)) return "You cant depart and arrive on the same day!";


        return ValidItemFields();
    }
    private void AddDefaultItemsToPackingList()
    {
        //null checking
        if (FromCountrySelectedItem == null) return;
        if (ToCountrySelectedItem == null) return;

        foreach (IPackingListItem item in PackingList)
        {
            if (item.Name.Equals("Passport")) return;
        }

        if (FromCountry.IsEUCountry() && ToCountry.IsEUCountry())
        {
            PackingList.Add(new TravelDocument("Passport", false));
            UpdatePackingListGUI();
            return;
        }


        PackingList.Add(new TravelDocument("Passport", true));
        UpdatePackingListGUI();
    }

    private string? ValidItemFields()
    {
        if (NameOfItem == null) return "Write the name of the item!";
        if (ItemCount <= 0) return "You need more than 1 of your item!";
        return null;
    }




    //---------- Methods END ----------
}
