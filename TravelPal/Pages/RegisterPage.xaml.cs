using System;
using System.Collections.Generic;
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

namespace TravelPal.Pages;

/// <summary>
/// Interaction logic for RegisterPage.xaml
/// </summary>
public partial class RegisterPage : Page
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public AllCountries ChosenCountry { get; set; }

    public RegisterPage()
    {
        InitializeComponent();
        var collectionOfAllEntries = Enum.GetValues(typeof(AllCountries));
    }
}

