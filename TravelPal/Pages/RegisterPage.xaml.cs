using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
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
/// Interaction logic for RegisterPage.xaml
/// </summary>
public partial class RegisterPage : Page
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public Country? ChosenCountry { get; set; }

    private SolidColorBrush? _btnLogInForeground;
    private SolidColorBrush? _btnLogInBorderColor;

    public RegisterPage()
    {
        InitializeComponent();
        ChkBxEuCountry_OnUnchecked(null, null); //so that the Combobox is not empty when page is first showed
        _btnLogInBorderColor = BtnLogIn.BorderBrush as SolidColorBrush;
        _btnLogInForeground = BtnLogIn.Foreground as SolidColorBrush;
    }

    private void ChkBxEuCountry_Checked(object sender, RoutedEventArgs e)
    {
        ComboBxCountries.Items.Clear();
        foreach (Country country in Country.EUCountries)
        {
            ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
            ComboBxCountries.Items.Add(listEntry);
        }
    }

    private void ChkBxEuCountry_OnUnchecked(object sender, RoutedEventArgs e)
    {
        ComboBxCountries.Items.Clear();
        foreach (Country country in Country.NonEUCountries)
        {

            ComboBoxItem listEntry = new ComboBoxItem { Content = country.ToString(), Tag = country };
            ComboBxCountries.Items.Add(listEntry);
        }
    }

    private void BtnRegister_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidUserInput()) return;

        LblErrorMessege.Content = Manager.UserManager.AddUser(new User(UserName, Password, ChosenCountry));
        if (LblErrorMessege.Content == "User with that username already exists") return;
        Manager.UserManager.LogIn(new User(UserName, Password, ChosenCountry));
        Manager.HeaderPage.UpdateGUI();

    }

    private bool ValidUserInput()
    {
        //TODO add more if statements that describe why the user can not create a new account
        //TODO add if statement that says that the length of the username is too short or too long
        //TODO add if statement that says that the length of the password is too short or too long
        if (UserName?.Trim().Length <= 3 || UserName.Equals(null))
        {
            LblErrorMessege.Content = "Write User Name!";
            return false;
        }

        if (Password?.Trim().Length <= 3 || Password.Equals(null))
        {
            LblErrorMessege.Content = "Write Password!";
            return false;
        }

        if (ComboBxCountries.SelectedItem == null)
        {
            LblErrorMessege.Content = "Chose your country of origin!";
            return false;
        }

        return true;
    }

    private void ComboBxCountries_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ChosenCountry = ((ComboBxCountries.SelectedItem as ComboBoxItem)?.Tag) as Country;
    }

    private void BtnLogIn_OnClick(object sender, RoutedEventArgs e)
    {

        Manager.Window.FrameMain.Content = Manager.LogInPage;
    }

    private void BtnLogIn_OnMouseEnter(object sender, MouseEventArgs e)
    {
        BtnLogIn.Foreground = new SolidColorBrush(Colors.Blue);
        BtnLogIn.BorderBrush = new SolidColorBrush(Colors.Blue);

    }

    private void BtnLogIn_OnMouseLeave(object sender, MouseEventArgs e)
    {
        BtnLogIn.Foreground = _btnLogInForeground;
        BtnLogIn.BorderBrush = _btnLogInBorderColor;
    }
}

