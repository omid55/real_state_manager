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

namespace BackUpAndRestoreDb
{
    /// <summary>
    /// Interaction logic for RemoveAll.xaml
    /// </summary>
    public partial class RemoveAll : Window
    {
        public RemoveAll()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "بلی")
            {
                try
                {
                    DB.execSql("EXEC RemoveAll");
                    DB.execSqlInArchive("EXEC RemoveAll");
                    MessageBox.Show("حذف همه ی اطلاعات با موفقیت انجام شد", "حذف همه ی اطلاعات", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Focus();
        }
    }
}
