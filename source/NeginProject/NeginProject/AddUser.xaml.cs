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

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();

            User_Txt.Focus();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersianDate pd = new PersianDate(DateTime.Today);
                String today = pd.ToShortDateString();
                String sql = "EXEC AddUser N'" + User_Txt.Text + "',N'" + Pass_Txt.Password + "',N'" + today + "'," +
                    Insert_CheckBox.IsChecked + "," + Search_CheckBox.IsChecked + "," + Delete_CheckBox.IsChecked + "," + Edit_CheckBox.IsChecked;

                DB.execSql(sql,0);
                MessageBox.Show("کاربر جدید با موفقیت ثبت گردید", "ثبت کاربر", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            else if(e.Key==Key.Up && Pass_Txt.IsFocused)
            {
                User_Txt.Focus();
            }
            else if (e.Key == Key.Down)
            {
                if (User_Txt.IsFocused)
                {
                    Pass_Txt.Focus();
                }
                else if(Pass_Txt.IsFocused)
                {
                    Insert_CheckBox.Focus();
                }
            }
        }
    }
}
