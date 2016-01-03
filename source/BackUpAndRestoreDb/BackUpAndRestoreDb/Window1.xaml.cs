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
using System.Data.SqlClient;


namespace BackUpAndRestoreDb
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BackUpDatabase b = new BackUpDatabase();
                b.doBackUp();

                MessageBox.Show("یک نسخه ی پشتیبان در مسیر زیر با موفقیت قرار گرفت \n" + b.bak, "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در دسترسی به حافظه لطفا چک بفرمایید که حافظه قابل نوشتن و دارای فضای خالی مناسب باشد", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(ex.Message, "خطای تکنیکی");
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            BackUpDatabase b = new BackUpDatabase();
            bool done = b.doRestore();
            if (done)
            {
                MessageBox.Show("پایگاه داده ها از مسیر زیر با موفقیت بازیابی شد \n" + b.bak, "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Information);
                Environment.Exit(1);
            }   
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                p.StartInfo.FileName = "NeginProject.exe";
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در دسترسی به فایل اجرایی برنامه ی اصلی", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                new RemoveAll().Show();
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            new UploadDbWnd().Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
