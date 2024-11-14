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
	/// Interaction logic for LaptopManagement.xaml
	/// </summary>
	public partial class LaptopManagement : Window
	{
		private AdminWindow adminWindow;
		private readonly IPlantService _laptopService;

		public LaptopManagement(AdminWindow adminWindow)
		{
			InitializeComponent();
			this.adminWindow = adminWindow;
			_laptopService = new PlantService();
		}

		private void loadLaptopData()
		{
			var laptops = _laptopService.GetAllLaptops();
			LaptopDataGrid.ItemsSource = laptops;
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			loadLaptopData();
		}

		private void LaptopDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (LaptopDataGrid.SelectedItem != null)
			{
				var laptop = (Plant)LaptopDataGrid.SelectedItem;
				laptopIdTxt.Text = laptop.PlantID.ToString();
			}
		}
		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			ProductDialog dialog = new ProductDialog();
			if (dialog.ShowDialog() == true)
			{
				try
				{
					_laptopService.AddPlant(dialog.Laptop);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				finally
				{
					loadLaptopData();
				}
			}
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Plant? selected = LaptopDataGrid.SelectedItem as Plant;
				if (selected != null)
				{
					ProductDialog dialog = new ProductDialog(selected);
					if (dialog.ShowDialog() == true)
					{
						Plant laptopUpdate = new Plant
						{
							PlantID = selected.PlantID,
							PlantName = dialog.Laptop.PlantName,
							Description = dialog.Laptop.Description,
							Price = dialog.Laptop.Price,
							Stock = dialog.Laptop.Stock,
							CategoryID = dialog.Laptop.CategoryID,
							ImageUrl = dialog.Laptop.ImageUrl,
							Status = dialog.Laptop.Status
						};
						_laptopService.UpdatePlant(laptopUpdate);
						loadLaptopData();
					}
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void DeleteLaptopButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(laptopIdTxt.Text))
			{
				MessageBox.Show("Choose Plants!!");
			}
			else
			{
				int laptopID = Convert.ToInt32((laptopIdTxt.Text).Trim());
				_laptopService.DeletePlant(laptopID);
				MessageBox.Show("Delete success!!");
				loadLaptopData();
			}
		}
		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			adminWindow.Show();
		}
	}
}
