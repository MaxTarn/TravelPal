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



    public void UpdateGUI()
    {

        ComboBxTravels.Items.Clear();
        if (Manager.UserManager.SignedInUser?.Travels.Count <= 0)
        {
            ComboBoxItem defaultEntry = new ComboBoxItem();
            defaultEntry.Content = "No Travels found.";
            defaultEntry.Tag = null;
            ComboBxTravels.Items.Add(defaultEntry);
            return;
        }
        foreach (Travel travl in Manager.UserManager.SignedInUser.Travels)
        {
            ComboBoxItem containerForTravel = new();
            containerForTravel.Tag = travl;
            containerForTravel.Content = travl.TravelName;

            ComboBxTravels.Items.Add(containerForTravel);
        }
    }

    private void BtnCreateNewTravel_Click(object sender, RoutedEventArgs e)
    {
        FrameMain.Content = Manager.AddNewTravelPage;
    }


}

