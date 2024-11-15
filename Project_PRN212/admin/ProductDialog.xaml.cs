using BusinessObject.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using Services;
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
	/// Interaction logic for ProductDialog.xaml
	/// </summary>
	public partial class ProductDialog : Window
	{
		private string selectedImagePath;
		public Plant Plant { get; set; }
		private readonly IPlantService _service;
        private readonly ICategoryService _categoryService;
		
        public ProductDialog(Plant? plant = null)
		{
			InitializeComponent();
			_service = new PlantService();
            _categoryService = new CategoryService();
            Plant = plant ?? new Plant();
			DataContext = Plant;
            LoadCategories();

            if (plant != null)
			{
				txtPlantName.Text = plant.PlantName;
				txtDescription.Text = plant.Description;
				txtPrice.Text = plant.Price.ToString();
				txtStock.Text = plant.Stock.ToString();
                txtCategoryID.SelectedItem = plant.Category;
                cboPlantStatus.SelectedIndex = plant.Status ? 0 : 1;
				if (plant.ImageUrl != null)
				{
					SelectedImage.Source = SelectedImage.Source = new BitmapImage(new Uri(plant.ImageUrl, UriKind.RelativeOrAbsolute));
				}
            }
		}
        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategories(); 
            txtCategoryID.ItemsSource = categories;
            txtCategoryID.DisplayMemberPath = "CategoryName"; 
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			if (ValidateInputs())
			{
				Plant.PlantName = txtPlantName.Text;
				Plant.Description = txtDescription.Text;
				Plant.Price = decimal.Parse(txtPrice.Text);
				Plant.Stock = int.Parse(txtStock.Text);
				Plant.Status = (cboPlantStatus.SelectedItem as ComboBoxItem)?.Tag.ToString() == "1" ? true : false;
				Plant.CategoryID = int.Parse(txtCategoryID.Text);
				if (!string.IsNullOrEmpty(selectedImagePath))
				{
					// Đặt thư mục lưu ảnh (ví dụ: C:\UploadedImages)
					string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
					string targetDirectory = System.IO.Path.Combine(projectDirectory, "img");

					// Tạo thư mục nếu chưa tồn tại
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}

					// Đường dẫn ảnh lưu trữ trong thư mục "img"
					string fileName = System.IO.Path.GetFileName(selectedImagePath);
					string destinationPath = System.IO.Path.Combine(targetDirectory, fileName);

					// Copy ảnh vào thư mục đích
					File.Copy(selectedImagePath, destinationPath, overwrite: true);

					// Cập nhật đường dẫn ảnh trong Plants
					Plant.ImageUrl = destinationPath;
					DialogResult = true;
					Close();
				}
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}

		private bool ValidateInputs()
		{
			StringBuilder errorMessage = new StringBuilder();

			if (string.IsNullOrWhiteSpace(txtPlantName.Text))
			{
				errorMessage.AppendLine("Plants Name is required.");
			}

			if (string.IsNullOrWhiteSpace(txtDescription.Text))
			{
				errorMessage.AppendLine("Detail Description is required.");
			}

			if (string.IsNullOrWhiteSpace(txtPrice.Text))
			{
				errorMessage.AppendLine("Plants Price is required.");
			}
			else if (!int.TryParse(txtStock.Text, out _))
			{
				errorMessage.AppendLine("Stock must be a valid number.");
			}

			if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
			{
				errorMessage.AppendLine("Categoiry ID is required.");
			}
			if (errorMessage.Length > 0)
			{
				MessageBox.Show(errorMessage.ToString(), "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				return false;
			}

			return true;
		}

		private void cboPlantStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ImportButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

			if (openFileDialog.ShowDialog() == true)
			{
				selectedImagePath = openFileDialog.FileName;
				SelectedImage.Source = new BitmapImage(new Uri(selectedImagePath));
			}
		}

	}
}

