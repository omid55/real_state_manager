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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Object obj=DB.execSqlReturnScalar("EXEC GetSerialNumber");
            if (obj == null)
            {
                MessageBox.Show("اطلاعات مربوط به شماره ی سریال شما نادرست است لطفا با پشتیبانی نرم افزار تماس بگیرید", "خطای چک کردن شماره سریال", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
            else
            {
                Serial_Txt.Text = (String)obj;
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
