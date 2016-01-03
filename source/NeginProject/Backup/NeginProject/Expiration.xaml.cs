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
    /// Interaction logic for Expiration.xaml
    /// </summary>
    public partial class Expiration : Window
    {
        public Expiration()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
