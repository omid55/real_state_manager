using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using WindowsInput;

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private bool loaded = false;
        private bool msgShown = false;

        public Login()
        {
            InitializeComponent();
            username.Focus();

            ConfigParams cp = WndConfig.getConfig();
            this.FontSize = cp.fontSize;


            // for farsi language =>
            InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.LMENU);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.LMENU);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            msgShown = false;
            if (username.Text.Trim() == "" || password.Password.Trim() == "")
            {
                msgShown = true;
                MessageBox.Show("لطفا هر دو قسمت را پر بفرمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(DB.getConnectionString());
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoginIsValid";
                SqlParameter param1 = new SqlParameter("@u", SqlDbType.NVarChar, 50);
                param1.Value = MyCrypt.encryptWithDefaultValues(username.Text);
                cmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@p", SqlDbType.NVarChar, 50);
                param2.Value = MyCrypt.encryptWithDefaultValues(password.Password);
                cmd.Parameters.Add(param2);
                Int32 b = (Int32)cmd.ExecuteScalar();
                if (b == 1)
                {
                    //msgShown = true;
                    //MessageBox.Show("اطلاعات صحیح می باشد پس به برنامه وارد می گردید", "ورود موفقیت آمیز", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window w = new Window1();
                    this.Close();
                    w.Show();
                }
                else
                {
                    msgShown = true;
                    MessageBox.Show("شناسه ی ورود یا رمز ورود اشتباه وارد گردیده است لطفا با دقت دوباره امتحان شودید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                msgShown = true;
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (username.IsFocused) password.Focus();
                else if (password.IsFocused) loginButton.Focus();
            }
            if (e.Key == Key.Up)
            {
                if (password.IsFocused) username.Focus();
                else if (loginButton.IsFocused || exitButton.IsFocused) password.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                if (loaded && !msgShown) loginButton_Click(null, null);
                loaded = true;
            }
            else if (e.Key == Key.Escape)
            {
                Environment.Exit(1);
            }
        }
    }
}
