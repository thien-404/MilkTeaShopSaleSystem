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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MilkTeaShopSalesSystem
{
    /// <summary>
    /// Interaction logic for CreateUpdateStaff.xaml
    /// </summary>
    public partial class CreateUpdateStaff : Window
    {
        private StaffService _service = new();
        public CreateUpdateStaff()
        {
            InitializeComponent();
        }
        public User EditOne { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StaffIdTextBox.IsEnabled = false;
            if (EditOne == null)
            {
                DetailTitle.Content = "Create";

                return;

            }
            DetailTitle.Content = "Update";


            StaffIdTextBox.Text = EditOne.UserId.ToString();
            StaffNameTextBox.Text = EditOne.UserName.ToString();
            EmailTextBox.Text = EditOne.Email.ToString();
            PasswordTextBox.Text = EditOne.Password.ToString();
            RoleTextBox.Text = EditOne.UserRole.ToString();
            StatusTextBox.Text = EditOne.UserStatus.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User obj;
            if (EditOne != null)
            {
                obj = EditOne;  // Lấy đối tượng đã được truyền từ `UpdateButton_Click`
            }
            else
            {
                // Nếu không, đây là chế độ tạo mới
                obj = new User();
            }

            //obj.AirConditionerId = int.Parse(AirConditionerIdTextBox.Text);
            obj.UserName = StaffNameTextBox.Text;
            obj.Email = EmailTextBox.Text;
            obj.Password = PasswordTextBox.Text;
            obj.UserRole = RoleTextBox.Text;
            obj.UserStatus = int.Parse(StatusTextBox.Text);
            

            if (EditOne == null)
            {
               _service.CreateUser(obj);
            }
            else
            {
                _service.UpdateUser(obj);
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
