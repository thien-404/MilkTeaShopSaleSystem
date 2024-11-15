
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
    /// Interaction logic for StaffManager.xaml
    /// </summary>
    public partial class StaffManager : Window
    {
        private StaffService _service = new();
        public User AuthenticatedUser { get; set; }
        public StaffManager()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //if (AuthenticatedUser.Equals("Staff"))
            //{
            //     BookListDataGrid.ItemsSource = _service.GetAllStaff();
            //}
            UserListDataGrid.ItemsSource = _service.GetAllStaff();


        }
        private void FillDataGrid(List<User> arr)
        {
            UserListDataGrid.ItemsSource = null;
            UserListDataGrid.ItemsSource = arr;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateStaff detail = new();
            detail.ShowDialog();
            FillDataGrid(_service.GetAllStaff());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User? selected = UserListDataGrid.SelectedItem as User;
            if (selected == null)
            {
                MessageBox.Show("Please select an Staff before edit", "Select one", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            CreateUpdateStaff detail = new();
            detail.EditOne = selected;
            detail.ShowDialog();
            FillDataGrid(_service.GetAllStaff());
        }

        

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure to quit !", "QUIT", MessageBoxButton.YesNo, MessageBoxImage.Question);
            Application.Current.Shutdown();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<User> result = _service.Search(StaffNameTextBox.Text.Trim(), EmailTextBox.Text.Trim());
            FillDataGrid(result);
        }
    }
}
