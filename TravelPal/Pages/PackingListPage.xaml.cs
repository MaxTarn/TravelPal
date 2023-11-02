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

namespace TravelPal.Pages
{
    /// <summary>
    /// Interaction logic for PackingListPage.xaml
    /// </summary>
    public partial class PackingListPage : Page
    {
        //---------- Method and property for making databinding TwoWay----------


        public event PropertyChangedEventHandler PropertyChanged;
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

        private bool? _itemIsTravelDocument;
        public bool? ItemIsTravelDocument
        {
            get => _itemIsTravelDocument;
            set
            {
                if (_itemIsTravelDocument == value) return;
                _itemIsTravelDocument = value;
                OnPropertyChanged(nameof(ItemIsTravelDocument));
            }
        }

        private int? _itemCount;

        public int? ItemCount
        {
            get => _itemCount;
            set
            {
                if (_itemCount == value) return;
                _itemCount = value;
                OnPropertyChanged(nameof(ItemCount));

            }
        }

        private bool? _itemIsRequired;

        public bool? ItemIsRequired
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

        }


        private void ChkBxItemIsTravelDocument_OnChecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChkBxItemIsTravelDocument_OnUnchecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnAddItemToList_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(PackingList.Count.ToString());
            PackingList.Add(new ListViewItem() { Content = "dgb" });
        }

        private void TxtBxItemCount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnItemIncrementUp_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnItemIncrementDown_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
