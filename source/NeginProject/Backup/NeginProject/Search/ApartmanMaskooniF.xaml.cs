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
    /// Interaction logic for ApartmanMaskooniF.xaml
    /// </summary>
    public partial class ApartmanMaskooniF : Window
    {
        private DispatcherTimer price;
        private bool pricel = false;
        private bool priceh = false;
        private bool loaded = false;
        private string[] cols;


        public ApartmanMaskooniF()
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
                if (metraj_Low.IsFocused || metraj_High.IsFocused) address_Txt.Focus();
                else if (bedrooms_Low.IsFocused) metraj_Low.Focus();
                else if (bedrooms_High.IsFocused) metraj_High.Focus();
                else if (vahedha_Low.IsFocused) bedrooms_Low.Focus();
                else if (vahedha_High.IsFocused) bedrooms_High.Focus();
                else if (sakht_Low.IsFocused) vahedha_Low.Focus();
                else if (sakht_High.IsFocused) vahedha_High.Focus();
                else if (owner.IsFocused) sakht_Low.Focus();
                else if (price_Low.IsFocused || price_High.IsFocused) owner.Focus();
                else if (search_button.IsFocused) price_Low.Focus();
                else if (back_button.IsFocused) price_High.Focus();
            }
            else if (e.Key == Key.Down)
            {
                if (address_Txt.IsFocused) metraj_Low.Focus();
                else if (metraj_Low.IsFocused) bedrooms_Low.Focus();
                else if (metraj_High.IsFocused) bedrooms_High.Focus();
                else if (bedrooms_Low.IsFocused) vahedha_Low.Focus();
                else if (bedrooms_High.IsFocused) vahedha_High.Focus();
                else if (vahedha_Low.IsFocused) sakht_Low.Focus();
                else if (vahedha_High.IsFocused) sakht_High.Focus();
                else if (sakht_Low.IsFocused || sakht_High.IsFocused) owner.Focus();
                else if (owner.IsFocused) price_Low.Focus();
                else if (price_Low.IsFocused || price_High.IsFocused) search_button.Focus();
            }
            else if (e.Key == Key.Left)
            {
                if (metraj_Low.IsFocused) metraj_High.Focus();
                else if (bedrooms_Low.IsFocused) bedrooms_High.Focus();
                else if (vahedha_Low.IsFocused) vahedha_High.Focus();
                else if (sakht_Low.IsFocused) sakht_High.Focus();
                else if (price_Low.IsFocused) price_High.Focus();
            }
            else if (e.Key == Key.Right)
            {
                if (metraj_High.IsFocused) metraj_Low.Focus();
                else if (bedrooms_High.IsFocused) bedrooms_Low.Focus();
                else if (vahedha_High.IsFocused) vahedha_Low.Focus();
                else if (sakht_High.IsFocused) sakht_Low.Focus();
                else if (price_High.IsFocused) price_Low.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                if(loaded) search_button_Click(null, null);
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

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            try
            {
                String sql = "EXEC SearchApartmanMaskooniFSimple N'" + address_Txt.Text + "',N'" + metraj_Low.Text + "',N'"
                    + metraj_High.Text + "',N'" + bedrooms_Low.Text + "',N'" + bedrooms_High.Text + "',N'" + vahedha_Low.Text
                    + "',N'" + vahedha_High.Text + "',N'" + sakht_Low.Text + "',N'" + sakht_High.Text + "',N'" + owner.Text
                    + "',N'" + MyPriceTextBox.getStringFromMasked(price_Low.Text) + "',N'" + MyPriceTextBox.getStringFromMasked(price_High.Text) + "'";

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

                    res.dt = dt.Copy();
                    res.which = Codes.ApartmanMaskooniForooshi;
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
                        if (i == 2 || i == 21) continue;
                        if ((metraj_Low.Text.Trim().Length != 0 || metraj_High.Text.Trim().Length != 0) && i == 3) continue;
                        if ((bedrooms_Low.Text.Trim().Length != 0 || bedrooms_High.Text.Trim().Length != 0) && i == 5) continue;
                        if ((vahedha_Low.Text.Trim().Length != 0 || vahedha_High.Text.Trim().Length != 0) && i == 10) continue;
                        if ((sakht_Low.Text.Trim().Length != 0 || sakht_High.Text.Trim().Length != 0) && i == 8) continue;
                        if (owner.Text.Trim().Length != 0 && i == 19) continue;
                        if ((price_Low.Text.Trim().Length != 0 || price_High.Text.Trim().Length != 0) && i == 22) continue;
                        dt.Columns.Remove(cols[i]);
                    }
                    res.gridView.DataSource = dt;
                    res.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
