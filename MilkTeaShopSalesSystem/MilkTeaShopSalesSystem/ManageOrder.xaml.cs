using MilkTeaShopSaleSystem.BLL.Services;
using MilkTeaShopSaleSystem.DAL.Models;
using MilkTeaShopSaleSystem.DAL.Repositories;
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
    /// Interaction logic for ManageOrder.xaml
    /// </summary>
    public partial class ManageOrder : Window
    {
        private OrderService _service = new();
        public ManageOrder()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.ItemsSource = _service.getOrderToStaff(2);
        }

        private void ViewDetailButton_Click(object sender, RoutedEventArgs e)
        {
            Order? Choosed = OrdersDataGrid.SelectedItem as Order;
            if (Choosed == null)
            {
                MessageBox.Show("Need To Choose One Order", "View Detail Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            OrderDetailWindow detail = new();
            detail._choosedOrder = Choosed;
            detail.ShowDialog();
            ReloadData(_service.getOrderToStaff(2));
        }

        private void ReloadData(List<Order> orders)
        {
            OrdersDataGrid.ItemsSource = orders;
        }
        
    }
}
