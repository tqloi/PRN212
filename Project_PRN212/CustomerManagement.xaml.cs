using BusinessObject.Model;
using Repository;
using Services;
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

namespace Project_PRN212
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : Window
    {
        private AdminWindow adminWindow;
        private readonly IUserService _userService;
        public CustomerManagement(AdminWindow adminWindow)
        {
            _userService = new UserService();
            InitializeComponent();
            this.adminWindow = adminWindow;
        }

        private void loadCustomerData()
        {
            var users = _userService.GetAllUsers();
            UserDataGrid.ItemsSource = users;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadCustomerData();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            adminWindow.Show();
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
            } else
            {
                int userID = Convert.ToInt32((customerIdTxt.Text).Trim());
                _userService.DeleteUserBasedOnStatus(userID);
                MessageBox.Show("Delete success!!");
                loadCustomerData();
            }
        }
    }
}
