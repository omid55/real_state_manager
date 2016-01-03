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
using System.Windows.Threading;

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for PriceConfig.xaml
    /// </summary>
    public partial class PriceConfig : Window
    {
        private bool pRahn = false;
        private bool pEjare = false;
        private DispatcherTimer price;


        public PriceConfig()
        {
            InitializeComponent();

            price = new DispatcherTimer();
            price.Interval = TimeSpan.FromSeconds(1);
            price.Tick += new EventHandler(price_Tick);
            price.Start();

            WndConfig.setConfig4SimpleSearch(this);
        }

        void price_Tick(object sender, EventArgs e)
        {
            MyPriceTextBox.doMask(pRahn, rahn);
            MyPriceTextBox.doMask(pEjare, ejare);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (rahn.IsFocused) ejare.Focus();
                else if (ejare.IsFocused) applyButton.Focus();
            }
            else if (e.Key == Key.Up)
            {
                if (ejare.IsFocused) rahn.Focus();
                else if (applyButton.IsFocused || exitButton.IsFocused) ejare.Focus();
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rahn.Text =  MyPriceTextBox.doMaskOnce(Codes.getRahnRatio());
            ejare.Text = MyPriceTextBox.doMaskOnce(Codes.getEjareRatio());

            rahn.Focus();
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            if (rahn.Text.Trim() == "" || ejare.Text.Trim() == "")
            {
                MessageBox.Show("لطفا هر دو قسمت ها پر بفرمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Codes.setRahnAndEjareRatio(MyPriceTextBox.getStringFromMasked(rahn.Text), MyPriceTextBox.getStringFromMasked(ejare.Text));
                MessageBox.Show("تغییرات با موفقیت اعمال گردیدند", "اعمال تغییرات", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اعمال تغییرات بر روی نسبت هزینه ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rahn_TextChanged(object sender, TextChangedEventArgs e)
        {
            pRahn = true;
        }

        private void ejare_TextChanged(object sender, TextChangedEventArgs e)
        {
            pEjare = true;
        }
    }
}
