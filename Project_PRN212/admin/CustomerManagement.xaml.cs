using BusinessObject.Model;
using Repository;
using Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_PRN212
{
    public partial class CustomerManagement : UserControl
    {
        private readonly IUserService _userService;

        public CustomerManagement()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private void loadCustomerData()
        {
            var users = _userService.GetAllUsers();
            UserDataGrid.ItemsSource = users;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadCustomerData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserDataGrid.SelectedItem != null)
            {
                var user = (User)UserDataGrid.SelectedItem;
                customerIdTxt.Text = user.UserID.ToString();
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(customerIdTxt.Text))
            {
                MessageBox.Show("Choose user!!");
            }
            else
            {
                int userID = Convert.ToInt32((customerIdTxt.Text).Trim());

                // Kiểm tra role của user
                int userRole = _userService.GetUserById(userID).RoleID;
                if (userRole == 1) // Giả sử role = 1 là admin
                {
                    MessageBox.Show("Cannot ban this user as they are an admin!");
                }
                else
                {
                    _userService.DeleteUserBasedOnStatus(userID);
                    MessageBox.Show("Action successful!!");
                    loadCustomerData();
                }
            }
        }
    }
}
