using BusinessObject.Model;
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_PRN212
{
	/// <summary>
	/// Interaction logic for PlantManagement.xaml
	/// </summary>
	public partial class PlantManagement : UserControl
    {
		private readonly IPlantService _plantService;

		public PlantManagement()
		{
			_plantService = new PlantService();
            InitializeComponent();
        }

		private void loadPlantData()
		{
			var plants = _plantService.GetAllPlants();
			PlantDataGrid.ItemsSource = plants;
		}
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			loadPlantData();
		}

		private void PlantDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (PlantDataGrid.SelectedItem != null)
			{
				var plant = (Plant)PlantDataGrid.SelectedItem;
				PlantIdTxt.Text = plant.PlantID.ToString();
			}
		}
		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			ProductDialog dialog = new ProductDialog();
			if (dialog.ShowDialog() == true)
			{
				try
				{
					_plantService.AddPlant(dialog.Plant);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				finally
				{
					loadPlantData();
				}
			}
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Plant? selected = PlantDataGrid.SelectedItem as Plant;
				if (selected != null)
				{
					ProductDialog dialog = new ProductDialog(selected);
					if (dialog.ShowDialog() == true)
					{
						Plant plantUpdate = new Plant
						{
							PlantID = selected.PlantID,
							PlantName = dialog.Plant.PlantName,
							Description = dialog.Plant.Description,
							Price = dialog.Plant.Price,
							Stock = dialog.Plant.Stock,
							CategoryID = dialog.Plant.CategoryID,
							ImageUrl = dialog.Plant.ImageUrl,
							Status = dialog.Plant.Status
						};
						_plantService.UpdatePlant(plantUpdate);
						loadPlantData();
					}
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            // Bạn cần xác định lại hành vi quay lại.
            // Ví dụ: ẩn hoặc kích hoạt `AdminWindow` hoặc gọi một sự kiện chuyển đổi `UserControl`.
            Visibility = Visibility.Hidden; // Hoặc gọi phương thức ở `AdminWindow` để điều khiển điều hướng.
        }


        private void DeletePlantButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(PlantIdTxt.Text))
			{
				MessageBox.Show("Choose Plants!!");
			}
			else
			{
				int plantID = Convert.ToInt32((PlantIdTxt.Text).Trim());
				_plantService.DeletePlant(plantID);
				MessageBox.Show("Delete success!!");
				loadPlantData();
			}
		}
	}
}
