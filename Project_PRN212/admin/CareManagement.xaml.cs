using BusinessObject.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_PRN212.admin
{
    /// <summary>
    /// Interaction logic for CareManagement.xaml
    /// </summary>
    public partial class CareManagement : UserControl
    {
        private readonly ICareScheduleService _careScheduleService;
        private readonly ICareServiceService _careServiceService;
        public CareManagement()
        {
            _careScheduleService = new CareScheduleService();
            _careServiceService = new CareServiceService();
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadCareScheduleData();
        }

        private void loadCareScheduleData()
        {
            var schedules = _careScheduleService.GetAllCareSchedules();
            UserDataGrid.ItemsSource = schedules;
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserDataGrid.SelectedItem != null)
            {
                var schedule = (CareSchedule)UserDataGrid.SelectedItem;
                scheduleIdTxt.Text = schedule.CareScheduleID.ToString();
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(scheduleIdTxt.Text))
            {
                MessageBox.Show("Choose user!!");
            }
            else
            {
                int scheduleID = Convert.ToInt32((scheduleIdTxt.Text).Trim());
                _careScheduleService.ChangeState(scheduleID);
                MessageBox.Show("Action successfull!!");
                loadCareScheduleData();
            }
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

            var results = _careScheduleService.SearchByKeyword(keyword);

            if (results.Any())
            {
                UserDataGrid.ItemsSource = results;
            }
            else
            {
                MessageBox.Show("No results found.");
            }
        }
    }
}
