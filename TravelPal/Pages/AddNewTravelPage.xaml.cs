using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    private bool? _isAllInclusive;
    public bool? IsAllInclusive
    {
        get => IsAllInclusive;
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
            if (_travellerCount != value)
            {
                _travellerCount = value;
                OnPropertyChanged(nameof(TravellerCount));
            }
        }
    }

    private int? _itemCount;
    public int? ItemCount
    {
        get => _itemCount;
        set
        {
            if (_itemCount != value)
            {
                _itemCount = value;
                OnPropertyChanged(nameof(ItemCount));
            }
        }
    }
    //---------- TwoWay Bound variables END ----------



    //---------- Constructor----------


    public AddNewTravelPage()
    {
        InitializeComponent();
        ChkBxEuCountry_OnUnchecked(null, null);
        ChkBxEuCountryArrival_OnUnchecked(null, null);
        _itemCount = 1;
        _travellerCount = 1;
        StartDay = DateTime.Now;
        EndDay = DateTime.Now;
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
            IsAllInclusive = null;

            LblWorkTrip.Visibility = Visibility.Visible;
            TxtBxWorkTrip.Visibility = Visibility.Visible;
        }
    }

    private void BtnCreateNewTravel_OnClick(object sender, RoutedEventArgs e)
    {
        TravelName = "testr";
        Manager.TravelManager.NewTravel.TravelName = TravelName;
        Manager.TravelManager.NewTravel.FromCountry = FromCountry;
        Manager.TravelManager.NewTravel.ToCountry = ToCountry;
        Manager.TravelManager.NewTravel.StartDate = StartDay;
        Manager.TravelManager.NewTravel.EndDate = EndDay;
        Manager.TravelManager.NewTravel.IsWorkTrip = IsWorkTrip;
        Manager.TravelManager.NewTravel.WorkTripDetails = WorkDetails;
        Manager.TravelManager.NewTravel.IsVacation = IsVacation;
        Manager.TravelManager.NewTravel.IsAllInclusive = IsAllInclusive;

        MessageBox.Show(TripType);
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

    private void ComboBxCountriesDepart_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AddDefaultItemsToPackingList();

    }


    //---------- Code-Behind methods, and various event handlers END----------



    //---------- Methods ----------
    private void UpdatePackingList()
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
    /*private string ValidateFields()
    {

    }*/
    private void AddDefaultItemsToPackingList()
    {
        Country? selectedDepartingCountry = (ComboBxCountriesArrival.SelectedItem as ComboBoxItem)?.Tag as Country;
        Country? selectedArrivalCountry = (ComboBxCountriesDepart.SelectedItem as ComboBoxItem)?.Tag as Country;

        //null checking
        if (selectedDepartingCountry == null) return;
        if (selectedArrivalCountry == null) return;

        if (selectedDepartingCountry.IsNonEUCountry())
        {
            PackingList.Add(new TravelDocument("Passport", true));
            UpdatePackingList();
        }


    }
    //---------- Methods END ----------
}
