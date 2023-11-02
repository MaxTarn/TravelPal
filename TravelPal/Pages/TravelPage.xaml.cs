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

namespace TravelPal.Pages;

/// <summary>
/// Interaction logic for TravelPage.xaml
/// </summary>
public partial class TravelPage : Page, INotifyPropertyChanged
{
    //---------- Method and property for making databinding TwoWay and update in GUI----------


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    //---------- Method and property for making databinding TwoWay and update in GUI END----------




    public bool Testr { get; set; } = false;
    public TravelPage()
    {
        InitializeComponent();
    }


    private void BtnCreateNewTravel_Click(object sender, RoutedEventArgs e)
    {
        FrameMain.Content = Manager.AddNewTravelPage;
    }

    private void BtnPackingList_Click(object sender, RoutedEventArgs e)
    {
        Manager.TravelPage.FrameMain.Content = Manager.PackingListPage;
    }

    private void BtnCreateTravel_Click(object sender, RoutedEventArgs e)
    {
        string? errorMessege = Manager.AddNewTravelPage.ValidateFields();
        if (errorMessege != null)
        {
            MessageBox.Show(errorMessege);
            return;
        }
        Travel newTravel = new Travel();
        newTravel.TravelName = Manager.AddNewTravelPage.TravelName;

        newTravel.Destination = Manager.AddNewTravelPage.ArrivalCity;
        newTravel.FromCountry = Manager.AddNewTravelPage.FromCountry;
        newTravel.ToCountry = Manager.AddNewTravelPage.ToCountry;
        newTravel.Travellers = Manager.AddNewTravelPage.TravellerCount;
        newTravel.PackingList = Manager.AddNewTravelPage.PackingList;
        newTravel.StartDate = Manager.AddNewTravelPage.StartDay;
        newTravel.EndDate = Manager.AddNewTravelPage.EndDay;
        newTravel.IsWorkTrip = Manager.AddNewTravelPage.IsWorkTrip;
        newTravel.WorkTripDetails = Manager.AddNewTravelPage.WorkDetails;
        newTravel.IsVacation = Manager.AddNewTravelPage.IsVacation;
        newTravel.IsAllInclusive = Manager.AddNewTravelPage.IsAllInclusive;

        Manager.UserManager.SignedInUser.AddTravel(newTravel);
        MessageBox.Show("Travel added to logged in user");
        Manager.AddNewTravelPage.ClearFields();
        Manager.ChooseTravelPage.UpdateGUI();

    }
}

