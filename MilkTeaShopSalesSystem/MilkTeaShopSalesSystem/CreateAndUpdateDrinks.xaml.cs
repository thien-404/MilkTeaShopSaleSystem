using MilkTeaShopSaleSystem.BLL.Services;
using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for CreateAndUpdateDrinks.xaml
    /// </summary>
    /// 

    public partial class CreateAndUpdateDrinks : Window
    {
        private DrinksService _service = new DrinksService();

        public Drink chosenOne { get; set; }

        public CreateAndUpdateDrinks()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chosenOne == null)
            {
                IdLable.Opacity = 0;
                DrinkIdTextBox.Opacity = 0;
                DetailWindowModeLable.Content = "Create Drinks";
                return;
            }
            DetailWindowModeLable.Content = "Update Drinks";
            DrinkIdTextBox.IsEnabled = false;
            DrinkIdTextBox.Text = chosenOne.DrinkId.ToString();
            DrinkNameTextBox.Text = chosenOne.DrinkName;
            DescripTextBox.Text = chosenOne.Description;
            foreach (ComboBoxItem item in StatusComboBox.Items)
            {
                if (item.Tag.ToString() == chosenOne.DrinkStatus.ToString())
                {
                    StatusComboBox.SelectedItem = item;
                    break;
                }
            }


        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            Drink obj = new();



            if (!CheckVar()) return;
            obj.DrinkName = DrinkNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(DescripTextBox.Text)) obj.Description = "";
            obj.Description = DescripTextBox.Text;
            if (StatusComboBox.SelectedItem is ComboBoxItem selectedItem)
                obj.DrinkStatus = int.Parse(selectedItem.Tag.ToString());

            if (chosenOne == null)
            {
                _service.CreateDrinks(obj);
            }
            else
            {

                obj.DrinkId = chosenOne.DrinkId;
                _service.UpdateDrinks(obj);
            }
            this.Close();

        }
        private bool CheckVar()
        {
            if (string.IsNullOrWhiteSpace(DrinkNameTextBox.Text))
            {
                MessageBox.Show("Drink name is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string drinkName = DrinkNameTextBox.Text.Trim();
            drinkName = textInfo.ToTitleCase(drinkName.ToLower());
            DrinkNameTextBox.Text = drinkName;


            if (StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a status!", "Selection required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
