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

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : Window
    {
        public ManageUsers()
        {
            InitializeComponent();

            gridView.AllowUserToOrderColumns = gridView.AllowUserToResizeColumns = gridView.AllowUserToResizeRows = true;
            gridView.AllowUserToAddRows = gridView.AllowUserToDeleteRows = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String sql = "EXEC ShowUsers";
                gridView.DataSource = DB.execSqlReturnDataTable(sql,0);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            Edit_Button.Visibility = Visibility.Hidden;
            Verify_Button.Visibility = Visibility.Visible;
            WarningLabel.Visibility = Visibility.Visible;
            gridView.AllowUserToAddRows = gridView.AllowUserToDeleteRows = true;
        }

        private void Verify_Button_Click(object sender, RoutedEventArgs e)
        {
            Edit_Button.Visibility = Visibility.Visible;
            Verify_Button.Visibility = Visibility.Hidden;
            WarningLabel.Visibility = Visibility.Hidden;
            gridView.AllowUserToAddRows = gridView.AllowUserToDeleteRows = false;
            try
            {
                String sql = "EXEC DeleteAllUsers";
                DB.execSql(sql,0);
                gridView.RefreshEdit();
                DataTable dt = (DataTable)gridView.DataSource;
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    String username = (String)dt.Rows[i].ItemArray[0];
                    String pass = (String)dt.Rows[i].ItemArray[1];
                    String date = (String)dt.Rows[i].ItemArray[2];
                    Boolean ins = (Boolean)dt.Rows[i].ItemArray[3];
                    Boolean se = (Boolean)dt.Rows[i].ItemArray[4];
                    Boolean de = (Boolean)dt.Rows[i].ItemArray[5];
                    Boolean ed = (Boolean)dt.Rows[i].ItemArray[6];
                    sql = "EXEC AddUser N'" + username + "',N'" + pass + "',N'" + date + "'," +
                        ins + "," + se + "," + de + "," + ed;

                    DB.execSql(sql,0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
