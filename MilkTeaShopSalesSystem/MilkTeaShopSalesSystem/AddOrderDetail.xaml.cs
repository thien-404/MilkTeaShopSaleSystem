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
    /// Interaction logic for AddOrderDetail.xaml
    /// </summary>
    public partial class AddOrderDetail : Window
    {
        private DrinksService _drinkSer = new();
        private PriceService _priceSer = new();
        public OrderDetail? OrderDetail { get; private set; }
        public AddOrderDetail()
        {
            InitializeComponent();
            LoadDrinks();
        }
        public void LoadDrinks()
        {
            DrinkComboBox.ItemsSource = _drinkSer.getDrinkByStatus(2); // Status = 2 (Active)
            DrinkComboBox.DisplayMemberPath = "DrinkName";
        }
        private void DrinkComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Drink? choseDrink = DrinkComboBox.SelectedItem as Drink;
            if (choseDrink != null)
            {
                // Load sizes for the selected drink
                choseDrink.Prices = _priceSer.getListPrice(choseDrink);
                SizeComboBox.ItemsSource = choseDrink.Prices;
                SizeComboBox.DisplayMemberPath = "Size";
            } 
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Drink? selectedDrink = DrinkComboBox.SelectedItem as Drink; 
            Price? selectSize = SizeComboBox.SelectedItem as Price;
            if (selectedDrink != null&&
                selectSize != null &&
                int.TryParse(QuantityTextBox.Text, out int quantity) && quantity > 0)
            {
                

                OrderDetail = new OrderDetail
                {
                    DrinkId = selectedDrink.DrinkId,
                    Size = selectSize.Size,
                    Quantity = quantity,
                    Price = selectSize,
                };

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly. Quantity must be greater than 0.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
