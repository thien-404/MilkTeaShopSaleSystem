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
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private OrderDetailService _service = new();
        public Order? _choosedOrder;
        public OrderDetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if( _choosedOrder != null )
            {
                OrderDetailDataGrid.ItemsSource = _service.getOrderDetail(_choosedOrder.OrderId);
            }
            
            
                OrderIdTextBox.Text = _choosedOrder.OrderId.ToString();
                TotalPriceTextBox.Text = _choosedOrder.TotalPrice.ToString();



        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
