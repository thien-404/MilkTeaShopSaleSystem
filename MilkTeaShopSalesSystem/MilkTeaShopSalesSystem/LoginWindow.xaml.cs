using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public UserService _service = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailAddressTextBox.Text;
            string pass = PasswordTextBox.Text;


            if (email.IsNullOrEmpty() || pass.IsNullOrEmpty())
            {
                MessageBox.Show("Please full fields!!!", "Require", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            User acc = _service.GetAccount(email, pass);

            if (acc == null)
            {
                MessageBox.Show("Sorry, wrong email or pass", "require", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (acc.UserRole == "Manager")
            {
                ManagerWindow manager = new();
                manager.User = acc;
                manager.Show();
            }
            

            if (acc.UserRole == "Cashier")
            {
                ManageOrder orderStaff = new();
                orderStaff.User = acc;
                orderStaff.Show();
            }
            //ManageOrder main = new();
            //main.User = acc;
            //main.Show();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

