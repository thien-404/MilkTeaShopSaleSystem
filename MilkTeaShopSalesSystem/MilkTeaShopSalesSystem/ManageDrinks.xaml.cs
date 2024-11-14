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
    /// Interaction logic for ManageDrinks.xaml
    /// </summary>
    public partial class ManageDrinks : Window
    {
        private DrinksService _service = new DrinksService();
        
        public ManageDrinks()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrinksDataGrid.ItemsSource = _service.getAllDrinks();
           
        }

        private void Create_Button(object sender, RoutedEventArgs e)
        {

            CreateAndUpdateDrinks createAndUpdateDrinks = new CreateAndUpdateDrinks();
            createAndUpdateDrinks.ShowDialog();
            FillDataGrid(_service.getAllDrinks());  
            
        }
        private void FillDataGrid(List<Drink> arr)
        {
            if (DrinksDataGrid != null)
            {
                DrinksDataGrid.ItemsSource = null;
                DrinksDataGrid.ItemsSource = arr;
            }
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            Drink? selected = DrinksDataGrid.SelectedItem as Drink;

            if (selected == null)
            {
                MessageBox.Show("Please select a drink before editing", "Select on", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;

            }
            CreateAndUpdateDrinks createAndUpdateDrinks = new CreateAndUpdateDrinks();
            createAndUpdateDrinks.chosenOne = selected;
            createAndUpdateDrinks.ShowDialog();
            FillDataGrid(_service.getAllDrinks());
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            List<Drink> selectedDrinks = DrinksDataGrid.SelectedItems.Cast<Drink>().ToList();
            if (!selectedDrinks.Any())
            {
                MessageBox.Show("Please select one or more drinks before editing", "Select Drinks", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            foreach (var drink in selectedDrinks)
            {
                _service.ChangeStatusDrinks(drink);
            }
            FillDataGrid(_service.getAllDrinks()); 

        }

        private void EditPrice_Button(object sender, RoutedEventArgs e)
        {
            Drink? selected = DrinksDataGrid.SelectedItem as Drink;

            if (selected == null)
            {
                MessageBox.Show("Please select a drink before editing", "Select on", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;

            }
            PriceDrinks price= new PriceDrinks();
            price.chosenOneDrink = selected;
            price.ShowDialog(); 

        }
        private void DrinkNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            List<Drink> result = _service.getDrinksByName(DrinkNameTextBox.Text);
            FillDataGrid(result);
        }
        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StatusComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                int? status = selectedItem.Tag != null ? int.Parse(selectedItem.Tag.ToString()) : (int?)null;
                List<Drink> result = _service.getDrinkByStatus(status);
                FillDataGrid(result);
            }
        }
    }
}
