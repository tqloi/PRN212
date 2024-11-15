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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private LoginWindow loginWindow;
        public AdminWindow(LoginWindow loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
        }

        private void userManagement_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new CustomerManagement(this).Show();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            loginWindow.Show();
        }

        private void orderManagement_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new OrderManagement(this).Show();
        }
		private void productManagement_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			new PlantManagement(this).Show();
		}
	}
}
