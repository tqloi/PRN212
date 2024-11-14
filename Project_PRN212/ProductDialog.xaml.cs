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
		public Plant Laptop { get; set; }
		private readonly IPlantService _service;

		public ProductDialog(Plant? laptop = null)
		{
			InitializeComponent();
			_service = new PlantService();
			Laptop = laptop ?? new Plant();
			DataContext = Laptop;

			if (laptop != null)
			{
				txtLaptopName.Text = laptop.PlantName;
				txtDescription.Text = laptop.Description;
				txtPrice.Text = laptop.Price.ToString();
				txtStock.Text = laptop.Stock.ToString();
				txtCategoryID.Text = laptop.CategoryID.ToString();
				cboLaptopStatus.SelectedIndex = laptop.Status ? 0 : 1;
				SelectedImage.Source = SelectedImage.Source = new BitmapImage(new Uri(laptop.ImageUrl, UriKind.RelativeOrAbsolute));
            }
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			if (ValidateInputs())
			{
				Laptop.PlantName = txtLaptopName.Text;
				Laptop.Description = txtDescription.Text;
				Laptop.Price = decimal.Parse(txtPrice.Text);
				Laptop.Stock = int.Parse(txtStock.Text);
				Laptop.Status = (cboLaptopStatus.SelectedItem as ComboBoxItem)?.Tag.ToString() == "1" ? true : false;
				Laptop.CategoryID = int.Parse(txtCategoryID.Text);
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
					Laptop.ImageUrl = destinationPath;
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

			if (string.IsNullOrWhiteSpace(txtLaptopName.Text))
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

		private void cboLaptopStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

