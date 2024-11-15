﻿using BusinessObject.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Project_PRN212
{
    /// <summary>
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : UserControl
    {
        private AdminWindow adminUserControl;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public ObservableCollection<OrderDetail> orderDetails { get; set; }
        public Order? selectedOrder { get; set; }
        public OrderManagement(AdminWindow adminUserControl)
        {
            InitializeComponent();
            this.adminUserControl = adminUserControl;
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
            orderDetails = new ObservableCollection<OrderDetail>();
            dgViewOrderDetails.ItemsSource = orderDetails;
            loadOrder();
        }

        private void loadOrder()
        {
            var orders = _orderService.GetAllOrders().ToList();

            dgOrderManagement.ItemsSource = orders;
            Debug.WriteLine($"Total orders loaded: {orders.Count}");
        }

        private void LoadOrderDetail()
        {
            if (selectedOrder != null)
            {
                var orderDetail = _orderDetailService.GetOrderDetailByOrderID(selectedOrder.OrderID);
                orderDetails.Clear();
                Debug.WriteLine($"Total order details: {orderDetail.Count()}");
                foreach (var detail in orderDetail)
                {
                    orderDetails.Add(detail);
                }
            }
        }
        private void dgOrderManagement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dgOrderManagement.SelectedItem is Order selected)
            {
                selectedOrder = _orderService.GetOrderById(selected.OrderID);
                LoadOrderDetail();
            }
            else
            {
                Debug.WriteLine("No order selected.");
            }
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy giá trị từ ô tìm kiếm (TextBox)
            string keyword = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword.");
                return;
            }

            var results = _orderService.SearchByKeyword(keyword);

            if (results.Any())
            {
                dgOrderManagement.ItemsSource = results;
            }
            else
            {
                MessageBox.Show("No results found.");
            }
        }
    }
}
