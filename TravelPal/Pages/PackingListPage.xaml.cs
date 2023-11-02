using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using TravelPal.Classes;
using TravelPal.Interfaces;

namespace TravelPal.Pages;

/// <summary>
/// Interaction logic for PackingListPage.xaml
/// </summary>
public partial class PackingListPage : Page, INotifyPropertyChanged
{
    //---------- Method and property for making databinding TwoWay----------


    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    //---------- Method and property for making databinding TwoWay END----------

    private ObservableCollection<ListViewItem> _packingList = new();
    public ObservableCollection<ListViewItem> PackingList
    {
        get => _packingList;
        set
        {
            if (_packingList == value) return;
            _packingList = value;
        }
    }



    private string? _itemName;
    public string? ItemName
    {
        get => _itemName;
        set
        {
            if (_itemName == value) return;
            _itemName = value;
            OnPropertyChanged(nameof(ItemName));
        }
    }


    private string? _itemInfo;
    public string? ItemInfo
    {
        get => _itemInfo;
        set
        {
            if (_itemInfo == value) return;
            _itemInfo = value;
            OnPropertyChanged(nameof(ItemInfo));
        }
    }


    private bool _itemIsTravelDocument;
    public bool ItemIsTravelDocument
    {
        get => _itemIsTravelDocument;
        set
        {
            if (_itemIsTravelDocument == value) return;
            _itemIsTravelDocument = value;
            OnPropertyChanged(nameof(ItemIsTravelDocument));
        }
    }


    private int _itemCount;
    public int ItemCount
    {
        get => _itemCount;
        set
        {
            if (_itemCount == value) return;
            _itemCount = value;
            OnPropertyChanged(nameof(ItemCount));

        }
    }


    private bool _itemIsRequired;
    public bool ItemIsRequired
    {
        get => _itemIsRequired;
        set
        {
            if (_itemIsRequired == value) return;
            _itemIsRequired = value;
            OnPropertyChanged(nameof(ItemIsRequired));
        }
    }





    public PackingListPage()
    {
        InitializeComponent();
        ItemIsRequired = false;
        ItemIsTravelDocument = false;
        ItemCount = 1;
    }


    private void ChkBxItemIsTravelDocument_OnChecked(object sender, RoutedEventArgs e)
    {
        LblItemCount.Visibility = Visibility.Hidden;
        StkPanlItemCount.Visibility = Visibility.Hidden;
        ItemCount = 1;

        LblItemIsRequired.Visibility = Visibility.Visible;
        ChkBxItemIsRequired.Visibility = Visibility.Visible;
        ItemIsRequired = false;


    }

    private void ChkBxItemIsTravelDocument_OnUnchecked(object sender, RoutedEventArgs e)
    {
        LblItemIsRequired.Visibility = Visibility.Hidden;
        ChkBxItemIsRequired.Visibility = Visibility.Hidden;
        ItemIsRequired = false;

        LblItemCount.Visibility = Visibility.Visible;
        StkPanlItemCount.Visibility = Visibility.Visible;

    }

    private void BtnAddItemToList_OnClick(object sender, RoutedEventArgs e)
    {
        string errorMessege = ValidInputs();
        if (errorMessege != null)
        {
            MessageBox.Show(errorMessege);
            return;
        }

        ListViewItem container = new();
        IPackingListItem newItem = new OtherItem(ItemName, ItemCount);

        if (ItemIsTravelDocument) newItem = new OtherItem(ItemName, ItemCount);
        newItem.Info = ItemInfo;
        container.Tag = newItem;
        container.Content = Utility.TruncateOrPadStringTo(newItem.Name, (int)(int?)FindResource("PackingListFirstItemLength"));


        if (newItem.Info != null || !string.IsNullOrEmpty(newItem.Info))
        {
            container.Content += $" | {Utility.TruncateOrPadStringTo(newItem.Info, (int)(int?)FindResource("PackingListSecondItemLength"))}";
        }
        else
        {
            container.Content += " | " + Utility.TruncateOrPadStringTo(null, (int)(int?)FindResource("PackingListSecondItemLength"));
        }

        PackingList.Add(container);
    }



    private void BtnItemIncrementUp_OnClick(object sender, RoutedEventArgs e)
    {
        ItemCount++;
    }

    private void BtnItemIncrementDown_OnClick(object sender, RoutedEventArgs e)
    {
        if (ItemCount <= 1)
        {
            MessageBox.Show("Cant have less than one item", "ERROR");
            return;
        }
        ItemCount--;
    }

    private string? ValidInputs()
    {
        if (ItemName == null) return "Item name is empty!";
        if (ItemCount == 0) return "You cant have less than one item of somerhing!";

        if (ItemName == string.Empty) return "Item name is empty!";
        if (ItemName.Length <= 3) return "item Name is too short";
        return null;
    }

    private void TxtBxItemCount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!char.IsDigit(e.Text, e.Text.Length - 1))
        {
            e.Handled = true;

        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(PackingList.Count.ToString());
    }
}

