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
/// Interaction logic for ChooseTravelPage.xaml
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
        MessageBox.Show(Manager.UserManager.SignedInUser.Travels.First().TravelName);
        foreach (Travel travl in Manager.UserManager.SignedInUser.Travels)
        {
            ListViewItem container = new();
            container.Tag = travl;
            container.Content = $"{Utility.TruncateOrPadStringTo(travl.TravelName, 10)} | from:{Utility.TruncateOrPadStringTo(travl.FromCountry.ToString(), 10)} ";
            Travels.Add(container);
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(Manager.UserManager.SignedInUser.Travels.Count.ToString());
    }

    private void BtnViewTravel_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedItem == null) MessageBox.Show("Choose a Travel");
        Manager.Window.FrameMain.Content = Manager.ViewTheTravelPage;
        Manager.ViewTheTravelPage.UpdateGUI(SelectedItem.Tag as Travel);

    }
}

