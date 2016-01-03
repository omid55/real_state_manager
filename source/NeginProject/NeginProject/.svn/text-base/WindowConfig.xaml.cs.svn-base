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
    /// Interaction logic for WindowConfig.xaml
    /// </summary>
    public partial class WindowConfig : Window
    {
        public WindowConfig()
        {
            InitializeComponent();

            WndConfig.setConfig4SimpleSearch(this);

            ConfigParams param = WndConfig.getConfig();
            fontSize_Txt.Text = param.fontSize.ToString();
            big_CheckBox.IsChecked = param.isMaximized;
            small_CheckBox.IsChecked = param.simpleIsMaximized;
            rahn_complete_CheckBox.IsChecked = param.rahn_complete;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConfigParams param = new ConfigParams();
                param.fontSize = Int32.Parse(fontSize_Txt.Text);
                param.isMaximized = big_CheckBox.IsChecked.Value;
                param.simpleIsMaximized = small_CheckBox.IsChecked.Value;
                param.rahn_complete = rahn_complete_CheckBox.IsChecked.Value;
                WndConfig.saveConfig(param);
                MessageBox.Show("تغییرات با موفقیت اعمال گردیدند", "اعمال تغییرات", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را با دقت بیشتری وارد نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
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
