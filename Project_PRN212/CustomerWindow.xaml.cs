using BusinessObject.Model;
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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private User user;
        private LoginWindow loginWindow;
        public CustomerWindow(LoginWindow loginWindow, User user)
        {
            this.loginWindow = loginWindow;
            this.user = user;   
            InitializeComponent();
        }

        private void profileBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new ProfileWindow(this, user).Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            loginWindow.Show();
        }

        private void viewProductBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new ViewProductWindow(this, user).Show();
        }

        private void viewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new ViewOrderWindow(this, user).Show();
        }
    }
}
