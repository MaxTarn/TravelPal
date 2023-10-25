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

    public RegisterPage()
    {
        InitializeComponent();
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
        ComboBoxItem selectedItem = ComboBxCountries.SelectedItem as ComboBoxItem;
        MessageBox.Show(((Country)selectedItem.Tag).ToString());
    }
}

