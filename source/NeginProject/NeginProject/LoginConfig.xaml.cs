﻿using System;
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

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for LoginConfig.xaml
    /// </summary>
    public partial class LoginConfig : Window
    {
        public LoginConfig()
        {
            InitializeComponent();
            oldUsername.Focus();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (oldUsername.IsFocused) oldPassword.Focus();
                else if (oldPassword.IsFocused) newUsername.Focus();
                else if (newUsername.IsFocused) newPassword.Focus();
                else if (newPassword.IsFocused) newPassword2.Focus();
                else if (newPassword2.IsFocused) applyButton.Focus();
            }
            else if (e.Key == Key.Up)
            {
                if (oldPassword.IsFocused) oldUsername.Focus();
                else if (newUsername.IsFocused) oldUsername.Focus();
                else if (newPassword.IsFocused) newUsername.Focus();
                else if (newPassword2.IsFocused) newPassword.Focus();
                else if (applyButton.IsFocused || exitButton.IsFocused) newPassword2.Focus();
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            if (oldUsername.Text.Trim() == "" || oldPassword.Password.Trim() == "" || newUsername.Text.Trim() == "" || newPassword.Password.Trim() == "" || newPassword2.Password.Trim() == "")
            {
                MessageBox.Show("لطفا همه ی قسمت ها را پر بفرمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (newPassword.Password != newPassword2.Password)
            {
                MessageBox.Show("رمز جدید در دو محل یکسان وارد نشده است لطفا در وارد کردن صحیح و یکسان آن در دو فیلد مربوطه دقت فرمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                newPassword.Clear();
                newPassword2.Clear();
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
                param1.Value = MyCrypt.encryptWithDefaultValues(oldUsername.Text);
                cmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@p", SqlDbType.NVarChar, 50);
                param2.Value = MyCrypt.encryptWithDefaultValues(oldPassword.Password);
                cmd.Parameters.Add(param2);
                Int32 b = (Int32)cmd.ExecuteScalar();
                cmd.Dispose();
                if (b == 1)
                {
                    // Admin Change His/Her Profile
                    SqlCommand setCmd = con.CreateCommand();
                    setCmd.CommandText = "SetLoginInfo";
                    setCmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter para1 = new SqlParameter("@u", SqlDbType.NVarChar, 50);
                    para1.Value = MyCrypt.encryptWithDefaultValues(newUsername.Text);
                    setCmd.Parameters.Add(para1);
                    SqlParameter para2 = new SqlParameter("@p", SqlDbType.NVarChar, 50);
                    para2.Value = MyCrypt.encryptWithDefaultValues(newPassword.Password);
                    setCmd.Parameters.Add(para2);
                    setCmd.ExecuteNonQuery();
                    con.Close();
                    setCmd.Dispose();
                    MessageBox.Show("اطلاعات وارد شدن به نرم افزار با موفقیت اعمال گردید", "تغییر شناسه یا رمز ورود به برنامه", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UserLoginIsValid";
                    SqlParameter para1 = new SqlParameter("@u", SqlDbType.NVarChar, 50);
                    para1.Value = oldUsername.Text;
                    command.Parameters.Add(para1);
                    SqlParameter para2 = new SqlParameter("@p", SqlDbType.NVarChar, 50);
                    para2.Value = oldPassword.Password;
                    command.Parameters.Add(para2);
                    Int32 res = (Int32)command.ExecuteScalar();
                    if (res == 1)
                    {
                        // User Change His/Her Profile
                        String q = "EXEC SetUserLoginInfo N'" + oldUsername.Text + "',N'" + oldPassword.Password + "',N'" + newUsername.Text + "',N'" + newPassword.Password + "'";
                        DB.execSql(q,0);
                        MessageBox.Show("اطلاعات وارد شدن به نرم افزار با موفقیت اعمال گردید", "تغییر شناسه یا رمز ورود به برنامه", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("شناسه ی ورود فعلی یا رمز ورود فعلی اشتباه وارد گردیده است لطفا با دقت دوباره امتحان شودید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    con.Close();
                    command.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
