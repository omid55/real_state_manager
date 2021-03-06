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
    /// Interaction logic for HouseS.xaml
    /// </summary>
    public partial class HouseS : Window
    {
        private DispatcherTimer price;
        private bool rahnl = false;
        private bool rahnh = false;
        private bool ejarel = false;
        private bool ejareh = false;
        private bool rahnoejarel = false;
        private bool rahnoejareh = false;
        private bool loaded = false;
        private bool errorOccurred = false;
        private string[] cols;
        public Session session;


        public HouseS()
        {
            InitializeComponent();
            PersianDate pd = new PersianDate(DateTime.Today);
            date_Lbl.Content = pd.ToShortDateString();

            address_Txt.Focus();

            price = new DispatcherTimer();
            price.Tick += new EventHandler(price_Tick);
            price.Interval = TimeSpan.FromSeconds(1);
            price.Start();

            WndConfig.setConfig4SimpleSearch(this);
        }

        void price_Tick(object sender, EventArgs e)
        {
            MyPriceTextBox.doMask(rahnl, rahn_Low);
            MyPriceTextBox.doMask(rahnh, rahn_High);
            MyPriceTextBox.doMask(ejarel, ejare_Low);
            MyPriceTextBox.doMask(ejareh, ejare_High);
            MyPriceTextBox.doMask(rahnoejarel, rahnoejare_Low);
            MyPriceTextBox.doMask(rahnoejareh, rahnoejare_High);
        }

        private String model1()    // when user fill rahn_low rahn_high ejare_low ejare_high
        {
            String sql = "";
            TextRange _text = new TextRange(comments.Document.ContentStart, comments.Document.ContentEnd);
            String cmt = _text.Text;
            cmt = cmt.Remove(cmt.Length - 2);
            if (WndConfig.getConfig().rahn_complete && ejare_Low.Text.Trim().Length == 0 && ejare_High.Text.Trim().Length == 0 && (rahn_Low.Text.Trim().Length != 0 || rahn_High.Text.Trim().Length != 0))  // rahn e complete
            {
                sql = "EXEC SearchManzelSRahnComplete N'" + address_Txt.Text + "',N'" + metraj_Low.Text + "',N'" +
                    metraj_High.Text + "',N'" + zirbanaa_Low.Text + "',N'" +
                        zirbanaa_High.Text + "',N'" + tabaghaat_Low.Text + "',N'" +
                            tabaghaat_High.Text + "',N'" + vahed_Low.Text + "',N'" +
                                vahed_High.Text + "',N'" + owner.Text + "',N'" + MyPriceTextBox.getStringFromMasked(rahn_Low.Text) + "',N'" +
                                    MyPriceTextBox.getStringFromMasked(rahn_High.Text) + "',N'" + cmt + "'";
            }
            else
            {
                sql = "EXEC SearchManzelSSimple N'" + address_Txt.Text + "',N'" + metraj_Low.Text + "',N'" +
                    metraj_High.Text + "',N'" + zirbanaa_Low.Text + "',N'" +
                        zirbanaa_High.Text + "',N'" + tabaghaat_Low.Text + "',N'" +
                            tabaghaat_High.Text + "',N'" + vahed_Low.Text + "',N'" +
                                vahed_High.Text + "',N'" + owner.Text + "',N'" + MyPriceTextBox.getStringFromMasked(rahn_Low.Text) + "',N'" +
                                    MyPriceTextBox.getStringFromMasked(rahn_High.Text) + "',N'" + MyPriceTextBox.getStringFromMasked(ejare_Low.Text) +
                                        "',N'" + MyPriceTextBox.getStringFromMasked(ejare_High.Text) + "',N'" + cmt + "'";
            }
            return sql;
        }

        private String model2(String roel, String roeh)    // when user fill rahnoejare_low rahnoejare_high
        {
            TextRange _text = new TextRange(comments.Document.ContentStart, comments.Document.ContentEnd);
            String cmt = _text.Text;
            cmt = cmt.Remove(cmt.Length - 2);
            String sql = "EXEC SearchRahnOEjareManzelEstijari N'" + address_Txt.Text + "',N'" + metraj_Low.Text + "',N'" +
                metraj_High.Text + "',N'" + zirbanaa_Low.Text + "',N'" +
                zirbanaa_High.Text + "',N'" + tabaghaat_Low.Text + "',N'" +
                tabaghaat_High.Text + "',N'" + vahed_Low.Text + "',N'" +
                vahed_High.Text + "',N'" + owner.Text + "'," + roel + "," +
                roeh + ",N'" + cmt + "'," + Codes.getEjareRatio() + "," + Codes.getRahnRatio();
            return sql;
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            errorOccurred = false;
            try
            {
                String sql;
                if (rahn_High.Text.Trim().Length == 0 && rahn_Low.Text.Trim().Length == 0 && ejare_High.Text.Trim().Length == 0 && ejare_Low.Text.Trim().Length == 0)
                {
                    if (rahnoejare_Low.Text.Trim().Length == 0 && rahnoejare_High.Text.Trim().Length == 0)
                    {
                        sql = model1();
                    }
                    else
                    {
                        String low = MyPriceTextBox.getStringFromMasked(rahnoejare_Low.Text);
                        String high = MyPriceTextBox.getStringFromMasked(rahnoejare_High.Text);
                        if (low.Trim().Length == 0 || high.Trim().Length == 0)
                        {
                            MessageBox.Show("لطفا در این حالت که می خواهید از فیلد رهن و اجاره استفاده بنمایید هر دو طرف آن را پر بفرمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        sql = model2(low, high);
                    }
                }
                else
                {
                    sql = model1();
                }

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
                    res.session = session;
                    res.which = Codes.HouseEstijari;

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
                        if (i == 2 || i == 17 || i == 18) continue;
                        if ((metraj_Low.Text.Trim().Length != 0 || metraj_High.Text.Trim().Length != 0) && i == 7) continue;
                        if ((zirbanaa_Low.Text.Trim().Length != 0 || zirbanaa_High.Text.Trim().Length != 0) && i == 6) continue;
                        if ((tabaghaat_Low.Text.Trim().Length != 0 || tabaghaat_High.Text.Trim().Length != 0) && i == 9) continue;
                        if ((vahed_Low.Text.Trim().Length != 0 || vahed_High.Text.Trim().Length != 0) && i == 10) continue;
                        if (owner.Text.Trim().Length != 0 && i == 15) continue;
                        dt.Columns.Remove(cols[i]);
                    }
                    res.gridView.DataSource = dt;
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
            if (e.Key == Key.Up)
            {
                if (address_Txt.IsFocused) rahnoejare_Low.Focus();
                else if (metraj_Low.IsFocused || metraj_High.IsFocused) address_Txt.Focus();
                else if (zirbanaa_Low.IsFocused) metraj_Low.Focus();
                else if (zirbanaa_High.IsFocused) metraj_High.Focus();
                else if (tabaghaat_Low.IsFocused) zirbanaa_Low.Focus();
                else if (tabaghaat_High.IsFocused) zirbanaa_High.Focus();
                else if (vahed_Low.IsFocused) tabaghaat_Low.Focus();
                else if (vahed_High.IsFocused) tabaghaat_High.Focus();
                else if (owner.IsFocused) vahed_Low.Focus();
                else if (rahn_Low.IsFocused || rahn_High.IsFocused) owner.Focus();
                else if (ejare_Low.IsFocused) rahn_Low.Focus();
                else if (ejare_High.IsFocused) rahn_High.Focus();
                else if (rahnoejare_Low.IsFocused) ejare_Low.Focus();
                else if (rahnoejare_High.IsFocused) ejare_High.Focus();
                else if (comments.IsFocused) rahnoejare_Low.Focus();
                //else if (search_button.IsFocused) rahnoejare_Low.Focus();
                //else if (back_button.IsFocused) rahnoejare_High.Focus();
            }
            else if (e.Key == Key.Down)
            {
                if (address_Txt.IsFocused) metraj_Low.Focus();
                else if (metraj_Low.IsFocused) zirbanaa_Low.Focus();
                else if (metraj_High.IsFocused) zirbanaa_High.Focus();
                else if (zirbanaa_Low.IsFocused) tabaghaat_Low.Focus();
                else if (zirbanaa_High.IsFocused) tabaghaat_High.Focus();
                else if (tabaghaat_Low.IsFocused) vahed_Low.Focus();
                else if (tabaghaat_High.IsFocused) vahed_High.Focus();
                else if (vahed_Low.IsFocused || vahed_High.IsFocused) owner.Focus();
                else if (owner.IsFocused) rahn_Low.Focus();
                else if (rahn_Low.IsFocused) ejare_Low.Focus();
                else if (rahn_High.IsFocused) ejare_High.Focus();
                else if (ejare_Low.IsFocused) rahnoejare_Low.Focus();
                else if (ejare_High.IsFocused) rahnoejare_High.Focus();
                else if (ejare_Low.IsFocused || ejare_High.IsFocused) comments.Focus();
                else if (comments.IsFocused) search_button.Focus();
            }
            else if (e.Key == Key.Left)
            {
                if (metraj_Low.IsFocused) metraj_High.Focus();
                else if (zirbanaa_Low.IsFocused) zirbanaa_High.Focus();
                else if (tabaghaat_Low.IsFocused) tabaghaat_High.Focus();
                else if (vahed_Low.IsFocused) vahed_High.Focus();
                else if (rahn_Low.IsFocused) rahn_High.Focus();
                else if (ejare_Low.IsFocused) ejare_High.Focus();
                else if (rahnoejare_Low.IsFocused) rahnoejare_High.Focus();
            }
            else if (e.Key == Key.Right)
            {
                if (metraj_High.IsFocused) metraj_Low.Focus();
                else if (zirbanaa_High.IsFocused) zirbanaa_Low.Focus();
                else if (tabaghaat_High.IsFocused) tabaghaat_Low.Focus();
                else if (vahed_High.IsFocused) vahed_Low.Focus();
                else if (rahn_High.IsFocused) rahn_Low.Focus();
                else if (ejare_High.IsFocused) ejare_Low.Focus();
                else if (rahnoejare_High.IsFocused) rahnoejare_Low.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                if (loaded && !errorOccurred) search_button_Click(null, null);
                loaded = true;
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void rahn_Low_TextChanged(object sender, TextChangedEventArgs e)
        {
            rahnl = true;
        }

        private void rahn_High_TextChanged(object sender, TextChangedEventArgs e)
        {
            rahnh = true;
        }

        private void ejare_Low_TextChanged(object sender, TextChangedEventArgs e)
        {
            ejarel = true;
        }

        private void ejare_High_TextChanged(object sender, TextChangedEventArgs e)
        {
            ejareh = true;
        }

        private void rahnoejare_Low_TextChanged(object sender, TextChangedEventArgs e)
        {
            rahnoejarel = true;
        }

        private void rahnoejare_High_TextChanged(object sender, TextChangedEventArgs e)
        {
            rahnoejareh = true;
        }
    }
}
