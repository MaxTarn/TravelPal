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
    public event PropertyChangedEventHandler PropertyChanged;


    public string? TravelName { get; set; }
    public Country? FromCountry { get; set; }
    public Country? ToCountry { get; set; }
    public DateTime? StartDay { get; set; } = DateTime.Now;
    public DateTime? EndDay { get; set; } = DateTime.Now;
    public List<IPackingListItem> PackingList { get; set; } = new();
    public string? TripType { get; set; }
    public bool? IsWorkTrip { get; set; }
    public bool? IsVacation { get; set; }
    public bool? IsAllInclusive { get; set; } = false;
    public string? WorkDetails { get; set; }



    private int? _itemCount = 1;
    private int? _travellerCount = 1;

    public int? TravellerCount
    {
        get { return _travellerCount; }
        set
        {
            if (_travellerCount != value)
            {
                _travellerCount = value;
                OnPropertyChanged(nameof(TravellerCount));
            }
        }
    }

    public int? ItemCount
    {
        get { return _itemCount; }
        set
        {
            if (_itemCount != value)
            {
                _itemCount = value;
                OnPropertyChanged(nameof(ItemCount));
            }
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }











    public AddNewTravelPage()
    {
        InitializeComponent();
        ChkBxEuCountry_OnUnchecked(null, null);
        ChkBxEuCountryArrival_OnUnchecked(null, null);
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

    private void AddDefaultItemsToPackingList()
    {
        Country? selectedDepartingCountry = (ComboBxCountriesArrival.SelectedItem as ComboBoxItem)?.Tag as Country;
        Country? selectedArrivalCountry = (ComboBxCountriesArrival.SelectedItem as ComboBoxItem)?.Tag as Country;

        //null checking
        if (selectedDepartingCountry == null) return;
        if (selectedArrivalCountry == null) return;

        if (selectedDepartingCountry.IsNonEUCountry())
        {
            PackingList.Add(new TravelDocument("Passport", true));
        }

    }
}
