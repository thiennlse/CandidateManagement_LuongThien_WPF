using Models.Models;
using RunS;
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

namespace CandidateManagement_LuongThien
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountService _service;

        private IAccountR service;

        public LoginWindow()
        {
            InitializeComponent();
             _service = new HRAccountService();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Email = txtEmail.Text;
            string Password = txtPassword.Password;
            if(Email.Length != 0 || Password != null ) 
            {
                if(_service.getAccount(Email, Password) != null)
                {
                    Hraccount hraccount = _service.getAccount(Email, Password);

                    if (hraccount.MemberRole == 1)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    if (hraccount.MemberRole == 2 || hraccount.MemberRole == 3)
                    {
                        CandidateWindow candidateWindow = new CandidateWindow();
                        candidateWindow.Show();
                    }

                    MessageBox.Show("Đăng nhập thành công !! ");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập. Vui lòng thử lại");
                }


            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin đăng nhập !!!");
            }
            
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
