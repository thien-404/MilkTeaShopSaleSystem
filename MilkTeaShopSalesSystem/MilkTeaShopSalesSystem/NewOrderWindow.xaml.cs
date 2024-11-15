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
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        private OrderService _orderSer = new();
        private List<OrderDetail> _orderDetailList = new List<OrderDetail>();

        public NewOrderWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrderDetailDataGrid.ItemsSource = _orderDetailList;
        }

        private void UpdateTotalPrice()
        {
            var totalPrice = _orderDetailList.Sum(d => d.SubTotal);
            TotalPriceTextBox.Text = totalPrice.ToString();
        }

        private void Load_Window()
        {
            OrderDetailDataGrid.Items.Refresh();
            UpdateTotalPrice();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddOrderDetail newDetail = new();
            newDetail.ShowDialog();
            var orderDetail = newDetail.OrderDetail;
            if (orderDetail != null)
            {
                var existDetail = _orderDetailList.FirstOrDefault(od => od.DrinkId == orderDetail.DrinkId && od.Size == orderDetail.Size);
                if (existDetail != null) 
                {
                    existDetail.Quantity += orderDetail.Quantity;
                }
                else
                {
                    _orderDetailList.Add(orderDetail);
                }
                Load_Window() ;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            OrderDetail? choseOne = OrderDetailDataGrid.SelectedItem as OrderDetail;
            if (choseOne != null)
            {
                _orderDetailList.Remove(choseOne);
                Load_Window();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_orderDetailList.Any())
                {
                    MessageBox.Show("Order must contain at least one detail.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var order = new Order
                {
                    StaffId = 2, // Replace with dynamic Staff ID logic
                    TotalPrice = _orderDetailList.Sum(d => d.SubTotal),
                    OrderStatus = 2 // Example: Pending
                };

                foreach (var detail in _orderDetailList)
                {
                    if (detail.Price == null)
                    {
                        MessageBox.Show($"Price is missing for drink ID {detail.DrinkId}.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                _orderSer.PlaceOrder(order, _orderDetailList);
                MessageBox.Show("Order submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit order: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
