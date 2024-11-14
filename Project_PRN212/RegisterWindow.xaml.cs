using BusinessObject.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private IUserService userService;
        private LoginWindow loginWindow;
        public RegisterWindow(LoginWindow loginWindow)
        {
            userService = new UserService();
            InitializeComponent();
            this.loginWindow = loginWindow;
        }   

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            loginWindow.Show();
        }

        private void regisBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            string fullname = fullNameTxt.Text.Trim();
            if (!IsValidFullName(fullname))
            {
                MessageBox.Show("Họ và tên không hợp lệ!");
                return;
            }
            string username = usernameTxt.Text.Trim();
            if (!IsValidUsername(username))
            {
                MessageBox.Show("Tên đăng nhập chứa ít nhất 6 kí tự không dấu và bắt đầu bằng 1 chữ cái");
                return;
            }
            string password = passwordBx.Password.Trim();
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Mật khẩu chứa ít nhất 8 ký tự và 1 chữ số!");
                return;
            }
            string email = emailTxt.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!");
                return;
            }

            string phone = phoneTxt.Text.Trim();
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }

            string address = addressTxt.Text.Trim();
            user.Fullname = fullname;
            user.Email = email;
            user.Phone = phone;
            user.Address = address;
            user.Password = password;
            user.UserName = username;
            user.RoleID = 2;
            user.Status = true;
            userService.AddUser(user);
            MessageBox.Show("Đăng kí thành công");
            this.Close();
            loginWindow.Show();
        }

        private bool IsValidPassword(string password)
        {
            // Kiểm tra mật khẩu có ít nhất 8 ký tự và ít nhất một chữ số
            if (password.Length >= 8 && Regex.IsMatch(password, @"[0-9]"))
            {
                return true; // Mật khẩu hợp lệ
            }
            return false; // Mật khẩu không hợp lệ
        }

        private bool IsValidUsername(string username)
        {
            // Kiểm tra nếu username có ít nhất 8 ký tự và bắt đầu bằng chữ cái
            if (username.Length >= 6 && char.IsLetter(username[0]))
            {
                return true; // Tên người dùng hợp lệ
            }
            return false; // Tên người dùng không hợp lệ
        }

        private bool IsValidFullName(string fullName)
        {
            // Kiểm tra fullName không rỗng và không chỉ là khoảng trắng
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return false;
            }

            // Kiểm tra fullName có ít nhất 2 từ (sử dụng dấu cách làm phân cách giữa các từ)
            string[] nameParts = fullName.Split(' ');
            if (nameParts.Length < 2)
            {
                return false;
            }

            // Kiểm tra fullName chỉ chứa các chữ cái (có dấu) và dấu cách
            Regex regex = new Regex(@"^[\p{L}\s]+$");
            return regex.IsMatch(fullName);
        }


        private bool IsValidEmail(string email)
        {
            // Biểu thức chính quy để kiểm tra email hợp lệ
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);  // Trả về true nếu email hợp lệ
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại bắt đầu bằng 0 và có đúng 10 chữ số
            Regex regex = new Regex(@"^0\d{9}$");
            return regex.IsMatch(phoneNumber);  // Trả về true nếu số điện thoại hợp lệ
        }
    }
}
