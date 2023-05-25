using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using ClientShop.ViewModels;
using System.Collections.ObjectModel;
using Server.Models;

namespace ClientShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductsViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ProductsViewModel();
            shopList.ItemsSource = _viewModel.Products;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            stockList.ItemsSource = await _viewModel.GetAllProducts();
        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Product product = (Product)stockList.SelectedItem;
            
            _viewModel.BuyProduct(product);
                     
        }
    }
}
