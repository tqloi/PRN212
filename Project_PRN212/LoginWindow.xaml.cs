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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IUserService _userService;
        public LoginWindow()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordBx.Password;

            //check input
            if (username == null || username == "" | password == null || password == "")
            {
                MessageBox.Show("Điền đầy đủ thông tin đăng nhập!");
                return;
            }

            var user = _userService.GetUserByUserNameAndPassword(username, password);
            //check tài khoản tồn tại hay ko
            if (user == null)
            {
                MessageBox.Show("Thông tin đăng nhập sai!");
            } else
            {
                //check trạng thái tài khoản
                if (!user.Status)
                {
                    MessageBox.Show("Tài khoản đã bị khóa!");
                } else
                {
                    //check role đăng nhập
                    //Nếu là admin
                    if (user.RoleID == 1)
                    {
                        this.Hide();
                        new AdminWindow(this, user).Show();
                    } 
                    //nếu khác admin
                    else
                    {
                        this.Hide();
                        new CustomerWindow(this, user).Show();
                    }
                }
            }
        }

        private void regisBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RegisterWindow(this).Show();
        }
    }
}
