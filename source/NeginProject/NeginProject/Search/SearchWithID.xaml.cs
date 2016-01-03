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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace NeginProject.Search
{
    /// <summary>
    /// Interaction logic for SearchWithID.xaml
    /// </summary>
    public partial class SearchWithID : Window
    {
        private bool loaded = false;
        private bool errorOccurred = false;
        public Session session;

        public SearchWithID()
        {
            InitializeComponent();
            ID_txt.Focus();
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            errorOccurred = false;
            try
            {
                String str = ID_txt.Text;
                String mode = "";
                int index = 0;
                while (str[index] != '-')
                {
                    mode += str[index++];
                }
                String sql = "EXEC SearchByID " + str.Substring(2) + "," + mode;

                DataTable dt = DB.execSqlReturnDataTable(sql,DBComboBox.SelectedIndex);

                if (Show3D_checkBox.IsChecked == true)
                {
                    Result3D res3d = new Result3D();
                    res3d.dt = dt;
                    res3d.Show();
                }
                else
                {
                    ResultWindow res = new ResultWindow();
                    res.which = Int32.Parse(mode);
                    res.gridView.DataSource = res.dt = dt;
                    res.session = session;
                    res.dbIndex = DBComboBox.SelectedIndex;
                    res.Show();
                }
            }
            catch (Exception)
            {
                errorOccurred = true;
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (loaded && !errorOccurred) search_button_Click(null, null);
                loaded = true;
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }

    public static class MyExtensions
    {
        public static bool isDigit(this char c)
        {
            return ('0' <= c && c <= '9');
        }
    }
}
