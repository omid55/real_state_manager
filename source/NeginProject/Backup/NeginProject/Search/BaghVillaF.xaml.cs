﻿using System;
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
using System.Windows.Threading;
using System.Data;

namespace NeginProject.Search
{
    /// <summary>
    /// Interaction logic for BaghVillaF.xaml
    /// </summary>
    public partial class BaghVillaF : Window
    {
        private bool pricel = false;
        private bool priceh = false;
        private DispatcherTimer price;
        private bool loaded = false;
        private bool errorOccurred = false;
        private string[] cols;


        public BaghVillaF()
        {
            InitializeComponent();
            Calendar cal = new Calendar(DateTime.Today.ToShortDateString(), Calendar.Solar_Date);
            date_Lbl.Content = cal.calcOtherModeNumeric();

            address_Txt.Focus();

            price = new DispatcherTimer();
            price.Tick += new EventHandler(price_Tick);
            price.Interval = TimeSpan.FromSeconds(1);
            price.Start();

            WndConfig.setConfig4SimpleSearch(this);
        }

        void price_Tick(object sender, EventArgs e)
        {
            MyPriceTextBox.doMask(pricel, price_Low);
            MyPriceTextBox.doMask(priceh, price_High);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (area_Low.IsFocused || area_High.IsFocused) address_Txt.Focus();
                else if (owner.IsFocused) area_Low.Focus();
                else if (price_Low.IsFocused || price_High.IsFocused) owner.Focus();
                else if (search_button.IsFocused) price_Low.Focus();
                else if (back_button.IsFocused) price_High.Focus();
            }
            else if (e.Key == Key.Down)
            {
                if (address_Txt.IsFocused) area_Low.Focus();
                else if (area_Low.IsFocused || area_High.IsFocused) owner.Focus();
                else if (owner.IsFocused) price_Low.Focus();
                else if (price_Low.IsFocused || price_High.IsFocused) search_button.Focus();
            }
            else if (e.Key == Key.Left)
            {
                if (area_Low.IsFocused) area_High.Focus();
                else if (price_Low.IsFocused) price_High.Focus();
            }
            else if (e.Key == Key.Right)
            {
                if (area_High.IsFocused) area_Low.Focus();
                else if (price_High.IsFocused) price_Low.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                if (loaded && !errorOccurred) Button_Click(null, null);
                loaded = true; 
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void price_Low_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricel = true;
        }

        private void price_High_TextChanged(object sender, TextChangedEventArgs e)
        {
            priceh = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            errorOccurred = false;
            try
            {
                String sql = "EXEC SearchBaghVillaFSimple N'" + address_Txt.Text + "',N'" + area_Low.Text + "',N'"
                    + area_High.Text + "',N'" + owner.Text + "',N'" 
                    + MyPriceTextBox.getStringFromMasked(price_Low.Text) + "',N'"
                    + MyPriceTextBox.getStringFromMasked(price_High.Text) + "'";

                DataTable dt = DB.execSqlReturnDataTable(sql);

                if (Show3D_checkBox.IsChecked == true)
                {
                    Result3D res3d = new Result3D();
                    res3d.dt = dt;
                    res3d.Show();
                }
                else
                {
                    ResultWindow res = new ResultWindow();
                    res.which = Codes.BaghVillaForooshi;

                    res.dt = dt.Copy();
                    if (cols == null)
                    {
                        cols = new string[dt.Columns.Count];
                        for (int i = 0; i < cols.Length; i++)
                        {
                            cols[i] = dt.Columns[i].ColumnName;
                        }
                    }
                    for (int i = 1; i < cols.Length; i++)
                    {
                        if (i == 2 || i == 24) continue;
                        if ((area_Low.Text.Trim().Length != 0 || area_High.Text.Trim().Length != 0) && i == 3) continue;
                        if (owner.Text.Trim().Length != 0 && i == 20) continue;
                        dt.Columns.Remove(cols[i]);
                    }
                    res.gridView.DataSource = dt;
                    res.Show();
                }
            }
            catch (Exception)
            {
                errorOccurred = true;
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
