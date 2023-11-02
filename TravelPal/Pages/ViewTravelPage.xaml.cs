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
/// Interaction logic for ViewTravelPage.xaml
/// </summary>
public partial class ViewTravelPage : Page, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<ListViewItem>? _travels
    {
        get
        {
            if (Manager.UserManager.SignedInUser == null) return null;
            Manager.UserManager.SignedInUser.Travels.ForEach(item =>
            {
                ListViewItem container = new();
                container.Tag = item;
                container.Content = $"{item.TravelName} | from:{item.FromCountry} | to:{item.ToCountry}";

            });
            return _travels;
        }
        set
        {
            _travels = value;
        }
    }

    public ObservableCollection<ListViewItem>? Travels
    {
        get => _travels;
        set
        {
            if (_travels == value) return;
            _travels = value;
            OnPropertyChanged(nameof(Travels));
        }
    }




    public ViewTravelPage()
    {
        InitializeComponent();
    }


}

