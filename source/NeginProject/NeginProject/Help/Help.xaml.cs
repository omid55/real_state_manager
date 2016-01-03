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

namespace NeginProject.Help
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();

            initCategoryComboBox();
        }

        public void initCategoryComboBox()
        {
            try
            {
                DataTable dt = DB.execSqlReturnDataTable("EXEC GetHelpCategories",0);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String catag = (String)dt.Rows[i].ItemArray[0];
                    CategoryComboBox.Items.Add(catag);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها , لطفا با پشتیبان تماس بگیرید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        public void setHelpContents(String sql)
        {
            try
            {
                DataTable dt = DB.execSqlReturnDataTable(sql,0);
                HelpId.Content = dt.Rows[0].ItemArray[0].ToString();
                HelpTextBlock.Text = (String)dt.Rows[0].ItemArray[1];
            }
            catch (Exception)
            {
                MessageBox.Show("راهنما در دست تکمیل است ...", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            String sql = "EXEC GetNextHelp " + (CategoryComboBox.SelectedIndex + 1) + " , " + HelpId.Content;
            setHelpContents(sql);
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            String sql = "EXEC GetPrevHelp " + (CategoryComboBox.SelectedIndex + 1) + " , " + HelpId.Content;
            setHelpContents(sql);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.Items.Count > 0)
            {
                CategoryComboBox.SelectedIndex = 0;
                NextButton_Click(this, null);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            else if (e.Key == Key.Right || e.Key == Key.Up)
            {
                NextButton_Click(this, null);
            }
            else if (e.Key == Key.Left || e.Key == Key.Down)
            {
                PrevButton_Click(this, null);
            }
        }
    }
}
