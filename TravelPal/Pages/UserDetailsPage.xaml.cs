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

namespace TravelPal.Pages;

/// <summary>
/// Interaction logic for UserDetailsPage.xaml
/// </summary>
public partial class UserDetailsPage : Page, INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



    private ComboBoxItem? _selectedCountryOfOrigin;
    public ComboBoxItem? SelectedCountryOfOrigin
    {
        get => _selectedCountryOfOrigin;
        set
        {
            if (_selectedCountryOfOrigin != value) return;
            _selectedCountryOfOrigin = value;
            OnPropertyChanged();
        }
    }


    public ObservableCollection<ComboBoxItem> Countries;

    private bool _isEUCountry;
    public bool IsEUCountry
    {
        get => _isEUCountry;
        set
        {
            if (value != _isEUCountry) return;
            _isEUCountry = value;
            OnPropertyChanged();
        }
    }




    public UserDetailsPage()
    {
        InitializeComponent();
        IsEUCountry = false;
        ChangeCountriesInComboBox(IsEUCountry);

    }



    private void ChangeCountriesInComboBox(bool isEuCountry)
    {
        if (isEuCountry)
        {
            AddEUCountriesToComboBox();
            return;
        }

        AddNonEUCountriesToComboBox();
    }
    public void AddEUCountriesToComboBox()
    {
        ComboBxCountries.Items.Clear();

        Country.EUCountries.ForEach(country =>
        {
            ComboBoxItem container = new();
            container.Tag = country;
            container.Content = country.ToString();
            ComboBxCountries.Items.Add(container);
        });

    }

    public void AddNonEUCountriesToComboBox()
    {
        ComboBxCountries.Items.Clear();

        Country.NonEUCountries.ForEach(country =>
        {
            ComboBoxItem container = new();
            container.Tag = country;
            container.Content = country.ToString();
            ComboBxCountries.Items.Add(container);
        });
    }

    public void UpdateGUI()
    {
        if (Manager.UserManager.SignedInUser == null) return;
        if ((bool)Manager.UserManager.SignedInUser?.CountryOfOrigin.IsEUCountry()) IsEUCountry = true;
        if ((bool)Manager.UserManager.SignedInUser?.CountryOfOrigin.IsNonEUCountry()) IsEUCountry = false;

        ChangeCountriesInComboBox(IsEUCountry);

        foreach (ComboBoxItem container in Countries)
        {
            if ((container.Tag as Country).ToString() == Manager.UserManager.SignedInUser.CountryOfOrigin.ToString())
            {
                SelectedCountryOfOrigin = container;
            }
        }
    }
}

