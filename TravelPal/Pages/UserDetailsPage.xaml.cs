using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
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



    private string? _userName;

    public string UserName
    {
        get => _userName;
        set
        {
            if (value == _userName) return;
            _userName = value;
            OnPropertyChanged();
        }
    }

    private ComboBoxItem? _selectedCountryOfOrigin;
    public ComboBoxItem? SelectedCountryOfOrigin
    {
        get => _selectedCountryOfOrigin;
        set
        {
            if (_selectedCountryOfOrigin == value) return;
            _selectedCountryOfOrigin = value;
            OnPropertyChanged();
        }
    }


    private ObservableCollection<ComboBoxItem>? _countries;
    public ObservableCollection<ComboBoxItem>? Countries
    {
        get => _countries;
        set
        {
            if (_countries == value) return;
            _countries = value;
            OnPropertyChanged();
        }
    }


    private bool _isEUCountry;
    public bool IsEUCountry
    {
        get => _isEUCountry;
        set
        {
            if (value == _isEUCountry) return;
            _isEUCountry = value;
            OnPropertyChanged();
            ChangeCountriesInComboBox(value);
        }
    }



    private string? _password;
    public string? Password
    {
        get => _password;
        set
        {
            if (_password == value) return;
            _password = value;
            OnPropertyChanged();
        }
    }



    private string? _repeatPassword;
    public string? ReapeatPassword
    {
        get => _repeatPassword;
        set
        {
            if (_repeatPassword == value) return;
            _repeatPassword = value;
            OnPropertyChanged();

        }
    }



    private bool _inputIsEnabled;

    public bool InputIsEnabled
    {
        get => _inputIsEnabled;
        set
        {
            _inputIsEnabled = value;
            OnPropertyChanged();
            if (value) EnableInputFromUser();
            if (!value) DisableInputFromUser();

        }
    }






    public UserDetailsPage()
    {
        InitializeComponent();
        IsEUCountry = false;
        Countries = new();
        ChangeCountriesInComboBox(IsEUCountry);
        InputIsEnabled = false;

    }

    private void EnableInputFromUser()
    {
        TxtBxUserName.IsEnabled = true;
        ComboBxCountries.IsEnabled = true;
        TxtBxPassword.IsEnabled = true;
        TxtBxRepeatPassword.IsEnabled = true;
    }

    private void DisableInputFromUser()
    {
        TxtBxUserName.IsEnabled = false;
        ComboBxCountries.IsEnabled = false;
        TxtBxPassword.IsEnabled = false;
        TxtBxRepeatPassword.IsEnabled = false;
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
        Countries.Clear();

        Country.EUCountries.ForEach(country =>
        {
            ComboBoxItem container = new();
            container.Tag = country;
            container.Content = country.ToString();
            Countries.Add(container);
        });

    }

    public void AddNonEUCountriesToComboBox()
    {
        Countries.Clear();

        Country.NonEUCountries.ForEach(country =>
        {
            ComboBoxItem container = new();
            container.Tag = country;
            container.Content = country.ToString();
            Countries.Add(container);
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

        UserName = Manager.UserManager.SignedInUser.UserName;
        Password = Manager.UserManager.SignedInUser.Password;
    }

    private void BtnEditDetails_Click(object sender, RoutedEventArgs e)
    {
        InputIsEnabled = !InputIsEnabled;
    }

    private void BtnSaveDetails_Click(object sender, RoutedEventArgs e)
    {
        string? errorMessege = ValidateInputs();
        if (errorMessege != null)
        {
            MessageBox.Show(errorMessege);
            return;
        }

        if (Manager.UserManager.SignedInUser == null)
        {
            MessageBox.Show("ERROR: Not logged in");
            Manager.Window.FrameMain.Content = Manager.LogInPage;
            return;
        }

        Manager.UserManager.SignedInUser.UserName = UserName;
        Manager.UserManager.SignedInUser.CountryOfOrigin = SelectedCountryOfOrigin.Tag as Country;
        Manager.UserManager.SignedInUser.Password = Password;

        MessageBox.Show("Succses");
        Manager.HeaderPage.UpdateGUI();

    }

    public string? ValidateInputs()
    {
        if (string.IsNullOrEmpty(UserName)) return "User name is too short!";
        if (SelectedCountryOfOrigin == null) return "Choose a country of origin";
        if (Password != ReapeatPassword) return "The passwords are not the same!";
        if (string.IsNullOrEmpty(Password)) return "Password is empty";

        if (UserName.Length <= 3) return "User name is too short";
        if (Password.Length <= 3) return "Password is too short";


        return null;
    }

    private void ClearFields()
    {
        UserName = "";
        SelectedCountryOfOrigin = null;
        Password = "";
        ReapeatPassword = "";
    }
}

