using BusinessObject.Model;
using Project_PRN212.admin;
using System;
using System.Collections.Generic;
using System.IO;
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
        private User user;
        private LoginWindow loginWindow;
        public AdminWindow()
        {
            InitializeComponent();
            string imgCartoon = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString()}\\Images\\cartoon-woman-pretty.png";
            string imgavatar = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString()}\\Images\\avatar1.jpg";
            ImgCartoon.Source = new BitmapImage(new Uri(imgCartoon));
            avatar1.Source = new BitmapImage(new Uri(imgavatar));
            avatar2.Source = new BitmapImage(new Uri(imgavatar));
        }

        public AdminWindow(LoginWindow loginWindow, User user)
        {
            this.loginWindow = loginWindow;
            this.user = user;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Dashboard());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            loginWindow.Show();
        }

        private void btn_Dashboard(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Dashboard());
        }

        private void btn_UserManagement(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new CustomerManagement());
        }

        private void btn_PlantManagement(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new PlantManagement());
        }

        private void btn_OrderManagement(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new OrderManagement(this));
        }

        private void btn_CareManagement(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Profile(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //new ProfileWindow(this, user).Show();
        }
    }
}
