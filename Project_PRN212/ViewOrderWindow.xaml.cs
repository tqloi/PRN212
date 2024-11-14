using BusinessObject.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewOrderWindow.xaml
    /// </summary>
    public partial class ViewOrderWindow : Window
    {
        private User _user;
        private CustomerWindow _customerWindow;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICareServiceService _careServiceService;
        private readonly ICareScheduleService _careScheduleService;
        private readonly IPlantService _plantService;
        public ObservableCollection<OrderDetail> orderDetails { get; set; }
        public Order? selectedOrder { get; set; }
        public Plant? selectedOrderDetail { get; set; }
        public ViewOrderWindow(CustomerWindow customerWindow , User user)
        {
            InitializeComponent();
            _user = user;
            _customerWindow = customerWindow;
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
            orderDetails = new ObservableCollection<OrderDetail>();
            dgOrderDetails.ItemsSource = orderDetails;
            _careServiceService = new CareServiceService();
            _careScheduleService = new CareScheduleService();
            _plantService = new PlantService();
            LoadOrderHistory();
            LoadServiceList();
            
        }
        public void LoadServiceList()
        {
            try
            {
                var cartlist = _careServiceService.GetAllCareServices();
                cboService.ItemsSource = cartlist;
                cboService.DisplayMemberPath = "CareServiceName";
                cboService.SelectedValuePath = "CareServiceID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Load list");
            }

        }
        private void LoadOrderHistory()
        {
            var orders = _orderService.GetAllOrders().Where(br => br.UserOrderID == _user.UserID).ToList();

            dgOrderHistory.ItemsSource = orders;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _customerWindow.Show();
        }

        private void dgOrderHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = dgOrderHistory.SelectedItem as dynamic;
            if (selected != null)
            {
                selectedOrder = _orderService.GetOrderById(selected.OrderID);
                LoadOrderDetail();
            }
        }
        private void dgOrderDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrderDetailItem = dgOrderDetails.SelectedItem as OrderDetail;
            if (selectedOrderDetailItem != null)
            {
                selectedOrderDetail = _plantService.GetPlantById(selectedOrderDetailItem.PlantID);

                if (selectedOrderDetail != null)
                {
                    MessageBox.Show($"Plant found: {selectedOrderDetail.PlantName}");
                }
                else
                {
                    MessageBox.Show("No Plant found for the selected OrderDetail.");
                }
            }
            else
            {
                MessageBox.Show("No OrderDetail selected.");
            }
        }
        private void LoadOrderDetail()
        {
            if(selectedOrder != null)
            {
                var orderDetail = _orderDetailService.GetOrderDetailByOrderID(selectedOrder.OrderID);
                orderDetails.Clear();
                foreach (var detail in orderDetail)
                {
                    var cay = _plantService.GetPlantById(detail.PlantID);
                    // Bạn có thể tạo một đối tượng OrderDetail mới hoặc thêm tên plant vào trong giao diện của bạn
                    // Giả sử bạn muốn thêm tên của Plant vào một thuộc tính OrderDetail, có thể làm như sau:
                    detail.Plant.PlantName = cay.PlantName;

                    // Thêm vào ObservableCollection để giao diện người dùng được cập nhật
                    orderDetails.Add(detail);
                }
            }
        }
        

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Ensure that an OrderDetail is selected
                if (selectedOrderDetail != null)
                {
                    
                    // Check if a service is selected in the combo box
                    if (cboService.SelectedValue != null)
                    {
                        // Parse the selected CareServiceID from the combo box
                        int selectedCareServiceID = int.Parse(cboService.SelectedValue.ToString());

                        // Create a new CareSchedule object
                        CareSchedule careSchedule = new CareSchedule
                        {
                            PlantID = selectedOrderDetail.PlantID,  // Assuming PlantID is the required property
                            UserID = _user.UserID,
                            Status = false,
                            StartDate = DateTime.Now,
                            FinishTime = DateTime.Now.AddMonths(1),  // Example: setting finish time 1 month from start
                            CareServiceID = selectedCareServiceID
                        };

                        // Add the care schedule to the database using the service
                        _careScheduleService.AddCareSchedule(careSchedule);

                        // Show success message
                        MessageBox.Show("Care schedule created successfully!", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Please select a care service.", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an order detail.", "Warning");
                }
            }
            catch (Exception ex)
            {
                // Display the error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        private void ViewServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewServiceDetailWindow serviceDetailWindow = new ViewServiceDetailWindow(this, _user);

            // Hiển thị cửa sổ mới
            serviceDetailWindow.Show();

            // Ẩn hoặc đóng cửa sổ hiện tại nếu không cần giữ nó mở
            this.Hide();
        }
    }
}
