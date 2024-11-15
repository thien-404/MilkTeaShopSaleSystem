using MilkTeaShopSaleSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public User User { get; set; }
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void ManageDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            ManageDrinks drinks = new ManageDrinks();
            drinks.ShowDialog();
        }

        private void ManageStaffButton_Click(object sender, RoutedEventArgs e)
        {
            StaffManager staff = new();
            staff.AuthenticatedUser = User;
            staff.ShowDialog();
        }

        private void ManageOrderDetailButton_Click(object sender, RoutedEventArgs e)
        {
            ManageOrder order = new();
            order.User = User;
            order.ShowDialog();
        }
    }
}
