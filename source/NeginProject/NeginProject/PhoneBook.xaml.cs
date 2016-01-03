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
    /// Interaction logic for PhoneBook.xaml
    /// </summary>
    public partial class PhoneBook : Window
    {
        public PhoneBook()
        {
            InitializeComponent();

            name_TextBox.Focus();

            WndConfig.setConfig4SimpleSearch(this);
        }

        private void name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (name_TextBox.Text.Trim().Length == 0)
                {
                    gridView.DataSource = null;
                    return;
                }
                String sql = "EXEC SearchTellBook N'" + name_TextBox.Text + "'";
                gridView.DataSource = DB.execSqlReturnDataTable(sql,0);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                try
                {
                    String sql = "EXEC InsertAllToTellBook";
                    gridView.DataSource = DB.execSqlReturnDataTable(sql,0);
                    MessageBox.Show("نام ها و شماره تلفن ها با موفقیت افزوده شدند", "دفترچه تلفن", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
