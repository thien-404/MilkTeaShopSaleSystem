using Microsoft.EntityFrameworkCore.Metadata;
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
    /// Interaction logic for CreateAndUpdatePrice.xaml
    /// </summary>
    public partial class CreateAndUpdatePrice : Window
    {
        private PriceService _priceService =new PriceService();
     
        public Drink chosenOneDrink { get; set; }
        
        public CreateAndUpdatePrice()
        {
            InitializeComponent();
        }
        public Price chosenOne { get; set; }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (chosenOne == null)
            {
               
                DetailWindowModeLable.Content = "Create Price";
                return;
            }
            DetailWindowModeLable.Content = "Update Price";
           
            PriceTextBox.Text = chosenOne.Price1.ToString();
            SizeTextBox.Text = chosenOne.Size;
            foreach (ComboBoxItem item in StatusComboBox.Items)
            {
                if (item.Tag.ToString() == chosenOne.PriceStatus.ToString())
                {
                    StatusComboBox.SelectedItem = item;
                    break;
                }
            }


        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            Price obj = new();



            if (!CheckVar()) return;
            obj.Size = SizeTextBox.Text;
            obj.DrinkId = (int)chosenOneDrink.DrinkId;
          
            obj.Price1 = decimal.Parse(PriceTextBox.Text);
            if (StatusComboBox.SelectedItem is ComboBoxItem selectedItem)
                obj.PriceStatus = int.Parse(selectedItem.Tag.ToString());

            if (chosenOne == null)
            {
                _priceService.CreatePrice(obj);
            }
            
            else _priceService.UpdatePrice(obj);
            this.Close();



        }
        private bool CheckVar()
        {
            if (string.IsNullOrWhiteSpace(SizeTextBox.Text))
            {
                MessageBox.Show("Size is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string drinkName = SizeTextBox.Text.Trim();
            drinkName = textInfo.ToTitleCase(drinkName.ToLower());
            SizeTextBox.Text = drinkName;

            if (StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a status!", "Selection required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            bool checkPrice = double.TryParse(PriceTextBox.Text, out double price);
            if (!checkPrice)
            {
                MessageBox.Show("Price must be number!", "Number required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (price <=0)
            {
                MessageBox.Show("Price must be >0", "Number required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            return true;
        }


    }
}
