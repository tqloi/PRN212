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
using BusinessObject.Model;
using Services;

namespace Project_PRN212
{
    /// <summary>
    /// Interaction logic for ViewServiceDetailWindow.xaml
    /// </summary>
    public partial class ViewServiceDetailWindow : Window
    {
        private User _user;
        private ViewOrderWindow _customerWindow;
        private readonly ICareScheduleService _careScheduleService;
        
       
        
        public ViewServiceDetailWindow(ViewOrderWindow viewOrderWindow ,User user)
        {
            InitializeComponent();
            _user = user;
            _careScheduleService = new CareScheduleService();
            _customerWindow = viewOrderWindow;
           
            LoadCareSchedule();
        }

        

        private void LoadCareSchedule()
        {
            var user = _user.UserID;
            var orders = _careScheduleService.GetCareScheduleByUserID(user);

            dgServices.ItemsSource = orders;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _customerWindow.Show();
            this.Close();
            
        }
    }
}
