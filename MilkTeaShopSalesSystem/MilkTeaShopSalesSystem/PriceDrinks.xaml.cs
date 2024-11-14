using MilkTeaShopSaleSystem.BLL.Services;
using MilkTeaShopSaleSystem.DAL.Models;
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
using System.Windows.Shapes;

namespace MilkTeaShopSalesSystem
{
    /// <summary>
    /// Interaction logic for PriceDrinks.xaml
    /// </summary>
    public partial class PriceDrinks : Window
    {
        private DrinksService _service = new DrinksService();
        private PriceService _priceService = new PriceService();

        public Drink chosenOneDrink { get; set; }
        public PriceDrinks()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PriceDrink.Content = $"Price of Drink: {chosenOneDrink.DrinkName}";
            PriceDataGrid.ItemsSource= _priceService.getListPrice(chosenOneDrink);

        }
        private void FillDataGrid(List<Price> arr)
        {
            PriceDataGrid.ItemsSource = null;
            PriceDataGrid.ItemsSource = arr;
        }

        private void Create_Button(object sender, RoutedEventArgs e)
        {
            CreateAndUpdatePrice createAndUpdatePrice = new CreateAndUpdatePrice();
            createAndUpdatePrice.chosenOneDrink = chosenOneDrink;
            createAndUpdatePrice.ShowDialog();  
            FillDataGrid(_priceService.getListPrice(chosenOneDrink));    
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            Price? selected = PriceDataGrid.SelectedItem as Price;

            if (selected == null)
            {
                MessageBox.Show("Please select a Price before editing", "Select on", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;

            }
            CreateAndUpdatePrice createAndUpdatePrice = new CreateAndUpdatePrice();
            createAndUpdatePrice.chosenOneDrink= chosenOneDrink;
            createAndUpdatePrice.chosenOne = selected;
            createAndUpdatePrice.ShowDialog();
            FillDataGrid(_priceService.getListPrice(chosenOneDrink));
        }
        private void ChangeStatus_Button(object sender, RoutedEventArgs e)
        {
            Price? selected = PriceDataGrid.SelectedItem as Price;
            if (selected == null)
            {
                MessageBox.Show("Please select a Price before editing", "Select on", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;

            }
            _priceService.changStatusPrice(selected);
            FillDataGrid(_priceService.getListPrice(chosenOneDrink));

        }
    }
}
