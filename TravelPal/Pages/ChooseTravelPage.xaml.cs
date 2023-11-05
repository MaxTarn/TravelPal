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
using TravelPal.Interfaces;

namespace TravelPal.Pages;

/// <summary>
/// Interaction logic for ChooseTravelPagee.xaml
/// </summary>
public partial class ChooseTravelPage : Page, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<ListViewItem>? _travels;

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

    private ListViewItem? _selectedItem;

    public ListViewItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (_selectedItem == value) return;
            _selectedItem = value;
            OnPropertyChanged();
        }
    }


    public ChooseTravelPage()
    {
        InitializeComponent();
        Travels = new();
    }

    public void UpdateGUI()
    {
        if (Manager.UserManager.SignedInUser.GetType() == typeof(Admin))
        {
            UpdateAsAdmin();
            return;
        }

        Travels.Clear();
        foreach (Travel travl in Manager.UserManager.SignedInUser.Travels)
        {
            ListViewItem container = new();
            container.Tag = travl;
            container.Content = $"{Utility.TruncateOrPadStringTo(travl.TravelName, 20)} | " +
                                $"from:{Utility.TruncateOrPadStringTo(travl.FromCountry.ToString(), 20)} | " +
                                $"To:{Utility.TruncateOrPadStringTo(travl.ToCountry.ToString(), 20)}";
            Travels.Add(container);
        }
    }

    private void UpdateAsAdmin()
    {

        Travels.Clear();
        foreach (IUser user in Manager.UserManager.Users)
        {
            if (user.GetType() == typeof(Admin)) continue;
            user.Travels.ForEach(travel =>
            {
                ListViewItem container = new();
                container.Tag = travel;
                container.Content = $"{Utility.TruncateOrPadStringTo($"User: {user.UserName}", 20)} | ";
                container.Content += $"from:{Utility.TruncateOrPadStringTo(travel.FromCountry.ToString(), 20)} | " +
                                     $"To:{Utility.TruncateOrPadStringTo(travel.ToCountry.ToString(), 20)}";
                Travels.Add(container);
            });
        }
    }

    private void BtnViewTravel_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedItem == null)
        {
            MessageBox.Show("Choose a Travel");
            return;
        }
        Manager.Window.FrameMain.Content = Manager.ViewTheTravelPage;
        Manager.ViewTheTravelPage.UpdateGUI(SelectedItem.Tag as Travel);

    }


    private void BtnDeleteTravel_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedItem == null)
        {
            MessageBox.Show("Choose a Travel");
            return;
        }

        foreach (IUser user in Manager.UserManager.Users)
        {
            if (user.GetType() == typeof(Admin)) continue;

            Travel? travel = user.Travels.Find(trvl => trvl == SelectedItem.Tag as Travel);
            if (travel != null)
            {
                user.Travels.Remove(travel);
            }
        }
        UpdateGUI();
    }
}

