﻿using BusinessObject.Model;
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
    /// Interaction logic for ViewProductWindow.xaml
    /// </summary>
    public partial class ViewProductWindow : Window
    {
        private int quantity = 1;
        private User _user;
        private CustomerWindow _customerWindow;
        private readonly IPlantService _laptopService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public ViewProductWindow(CustomerWindow customerWindow, User user)
        {
            InitializeComponent();
            _customerWindow = customerWindow;
            _user = user;
            _laptopService = new PlantService();
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
            LoadLaptopInformation();
        }

        private void LoadLaptopInformation()
        {
            var allLap = _laptopService.GetAllLaptops();

            var availableLaps = allLap
                .Where(lap => lap.Status)
                .ToList();

            LaptopListBox.ItemsSource = availableLaps;
        }

        private void DecreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            if (quantity > 1) // Đảm bảo số lượng không dưới 1
            {
                quantity--;
                QuantityTextBlock.Text = quantity.ToString();
            }else
            {
                MessageBox.Show("Check", "Stock at least 1", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void IncreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            quantity++;
            QuantityTextBlock.Text = quantity.ToString();
        }

        private void buyBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = LaptopListBox.SelectedItems.Cast<Plant>().ToList();
            if (selected.Count == 0)
            {
                MessageBox.Show("Please select product.", "No Plants Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var order = new Order
            {
                UserOrderID = _user.UserID,
                DateOrder = DateTime.Now
            };
            order.TotalPrice = selected.Sum(lap => lap.Price * Convert.ToInt32(QuantityTextBlock.Text));
            if(_orderService.GetOrderByUser(_user.UserID).Sum(lap => lap.TotalPrice) >= 100000000)
            {
                order.TotalPrice = order.TotalPrice - 5000000;
                MessageBox.Show("you get 5 million discount!", "Good news", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (order.TotalPrice >= 100000000)
            {
                order.TotalPrice = order.TotalPrice * 0.95m;
                MessageBox.Show("You get 5% off!", "Good news", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            _orderService.AddOrder(order);
            foreach (var lap in selected)
            {
                if(lap.Stock <= Convert.ToInt32(QuantityTextBlock.Text))
                {
                    MessageBox.Show($"Only {lap.Stock} products left", "There is currently not enough stock to meet demand.", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    PlantID = lap.PlantID,
                    Stock = Convert.ToInt32(QuantityTextBlock.Text),
                    Price = lap.Price * Convert.ToInt32(QuantityTextBlock.Text)
                };
                _orderDetailService.AddOrderDetail(orderDetail);
                lap.Stock -= Convert.ToInt32(QuantityTextBlock.Text);
                if (lap.Stock == 0) lap.Status = false;
                _laptopService.UpdatePlant(lap);
                MessageBox.Show("Orders successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _customerWindow.Show();
        }
    }
}
