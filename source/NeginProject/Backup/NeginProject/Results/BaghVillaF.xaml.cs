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
using System.Windows.Shapes;
using System.Data;
using System.Windows.Threading;

namespace NeginProject.Results
{
    /// <summary>
    /// Interaction logic for BaghVillaF.xaml
    /// </summary>
    public partial class BaghVillaF : Window
    {
        public DataTable dt;
        public int index;
        public ResultWindow tw;
        private bool changeMode = false;
        private bool msgShow = false;
        private bool editing = false;
        private bool pricemeter = false;
        private bool pricetotal = false;
        private DispatcherTimer price;


        public BaghVillaF()
        {
            InitializeComponent();
            textBox1.Focus();

            price = new DispatcherTimer();
            price.Tick += new EventHandler(price_Tick);
            price.Interval = TimeSpan.FromSeconds(1);

            WndConfig.setConfiguration(this);
        }

        void price_Tick(object sender, EventArgs e)
        {
            MyPriceTextBox.doMask(pricemeter, textBox22);
            MyPriceTextBox.doMask(pricetotal, textBox23);
        }

        private void makeEditableAll()
        {
            textBox1.IsReadOnly = false;
            textBox2.IsReadOnly = false;
            textBox3.IsReadOnly = false;
            textBox4.IsReadOnly = false;
            textBox5.IsReadOnly = false;
            textBox6.IsReadOnly = false;
            textBox7.IsReadOnly = false;
            textBox8.IsReadOnly = false;
            textBox9.IsReadOnly = false;
            textBox10.IsReadOnly = false;
            textBox11.IsReadOnly = false;
            textBox12.IsReadOnly = false;
            textBox13.IsReadOnly = false;
            textBox14.IsReadOnly = false;
            textBox15.IsReadOnly = false;
            textBox16.IsReadOnly = false;
            textBox17.IsReadOnly = false;
            textBox18.IsReadOnly = false;
            textBox19.IsReadOnly = false;
            textBox20.IsReadOnly = false;
            textBox21.IsReadOnly = false;
            textBox22.IsReadOnly = false;
            textBox23.IsReadOnly = false;
            textBox24.IsReadOnly = false;
            richTextBox1.IsReadOnly = false;
        }

        private void makeNonEditableAll()
        {
            textBox1.IsReadOnly = true;
            textBox2.IsReadOnly = true;
            textBox3.IsReadOnly = true;
            textBox4.IsReadOnly = true;
            textBox5.IsReadOnly = true;
            textBox6.IsReadOnly = true;
            textBox7.IsReadOnly = true;
            textBox8.IsReadOnly = true;
            textBox9.IsReadOnly = true;
            textBox10.IsReadOnly = true;
            textBox11.IsReadOnly = true;
            textBox12.IsReadOnly = true;
            textBox13.IsReadOnly = true;
            textBox14.IsReadOnly = true;
            textBox15.IsReadOnly = true;
            textBox16.IsReadOnly = true;
            textBox17.IsReadOnly = true;
            textBox18.IsReadOnly = true;
            textBox19.IsReadOnly = true;
            textBox20.IsReadOnly = true;
            textBox21.IsReadOnly = true;
            textBox22.IsReadOnly = true;
            textBox23.IsReadOnly = true;
            textBox24.IsReadOnly = true;
            richTextBox1.IsReadOnly = true;
        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {
            if (index + 1 >= dt.Rows.Count)
                return;

            removeLbl.Visibility = Visibility.Hidden;
            Object[] obj = dt.Rows[++index].ItemArray;
            this.ID_Lbl.Content = Codes.BaghVillaForooshi + " - " + obj[0].ToString();
            this.date_Lbl.Content = obj[1].ToString();
            this.textBox1.Text = obj[2].ToString();
            this.textBox2.Text = obj[3].ToString();
            this.textBox3.Text = obj[4].ToString();
            this.textBox4.Text = obj[5].ToString();
            this.textBox5.Text = obj[6].ToString();
            this.textBox6.Text = obj[7].ToString();
            this.textBox7.Text = obj[8].ToString();
            this.textBox8.Text = obj[9].ToString();
            this.textBox9.Text = obj[10].ToString();
            this.textBox10.Text = obj[11].ToString();
            this.textBox11.Text = obj[12].ToString();
            this.textBox12.Text = obj[13].ToString();
            this.textBox13.Text = obj[14].ToString();
            this.textBox14.Text = obj[15].ToString();
            this.textBox15.Text = obj[16].ToString();
            this.textBox16.Text = obj[17].ToString();
            this.textBox17.Text = obj[18].ToString();
            this.textBox18.Text = obj[19].ToString();
            this.textBox19.Text = obj[20].ToString();
            this.textBox20.Text = obj[21].ToString();
            this.textBox21.Text = obj[22].ToString();
            this.textBox22.Text = MyPriceTextBox.doMaskOnce(obj[23].ToString());
            this.textBox23.Text = MyPriceTextBox.doMaskOnce(obj[24].ToString());
            this.checkBox1.IsChecked = (bool)obj[25];
            this.checkBox2.IsChecked = (bool)obj[26];
            this.checkBox3.IsChecked = (bool)obj[27];
            this.checkBox4.IsChecked = (bool)obj[28];
            this.checkBox5.IsChecked = (bool)obj[29];
            this.checkBox6.IsChecked = (bool)obj[30];
            this.checkBox7.IsChecked = (bool)obj[31];
            this.checkBox8.IsChecked = (bool)obj[32];
            this.checkBox9.IsChecked = (bool)obj[33];
            this.checkBox10.IsChecked = (bool)obj[34];
            this.checkBox11.IsChecked = (bool)obj[35];
            this.checkBox12.IsChecked = (bool)obj[36];
            this.checkBox13.IsChecked = (bool)obj[37];
            this.checkBox14.IsChecked = (bool)obj[38];
            this.checkBox15.IsChecked = (bool)obj[39];
            this.checkBox16.IsChecked = (bool)obj[40];
            this.checkBox17.IsChecked = (bool)obj[41];
            this.checkBox18.IsChecked = (bool)obj[42];
            this.checkBox19.IsChecked = (bool)obj[43];
            this.checkBox20.IsChecked = (bool)obj[44];
            this.checkBox21.IsChecked = (bool)obj[45];
            this.checkBox22.IsChecked = (bool)obj[46];
            this.checkBox23.IsChecked = (bool)obj[47];
            this.checkBox24.IsChecked = (bool)obj[48];
            this.checkBox25.IsChecked = (bool)obj[49];
            this.checkBox26.IsChecked = (bool)obj[50];
            this.checkBox27.IsChecked = (bool)obj[51];
            this.checkBox28.IsChecked = (bool)obj[52];
            this.checkBox29.IsChecked = (bool)obj[53];
            this.checkBox30.IsChecked = (bool)obj[54];
            TextRange _RText = new TextRange(this.richTextBox1.Document.ContentStart, this.richTextBox1.Document.ContentEnd);
            _RText.Text = obj[55].ToString();
            this.textBox24.Text = obj[56].ToString();
        }

        private void before_button_Click(object sender, RoutedEventArgs e)
        {
            if (index - 1 < 0)
                return;

            removeLbl.Visibility = Visibility.Hidden;
            Object[] obj = dt.Rows[--index].ItemArray;
            this.ID_Lbl.Content = Codes.BaghVillaForooshi + " - " + obj[0].ToString();
            this.date_Lbl.Content = obj[1].ToString();
            this.textBox1.Text = obj[2].ToString();
            this.textBox2.Text = obj[3].ToString();
            this.textBox3.Text = obj[4].ToString();
            this.textBox4.Text = obj[5].ToString();
            this.textBox5.Text = obj[6].ToString();
            this.textBox6.Text = obj[7].ToString();
            this.textBox7.Text = obj[8].ToString();
            this.textBox8.Text = obj[9].ToString();
            this.textBox9.Text = obj[10].ToString();
            this.textBox10.Text = obj[11].ToString();
            this.textBox11.Text = obj[12].ToString();
            this.textBox12.Text = obj[13].ToString();
            this.textBox13.Text = obj[14].ToString();
            this.textBox14.Text = obj[15].ToString();
            this.textBox15.Text = obj[16].ToString();
            this.textBox16.Text = obj[17].ToString();
            this.textBox17.Text = obj[18].ToString();
            this.textBox18.Text = obj[19].ToString();
            this.textBox19.Text = obj[20].ToString();
            this.textBox20.Text = obj[21].ToString();
            this.textBox21.Text = obj[22].ToString();
            this.textBox22.Text = MyPriceTextBox.doMaskOnce(obj[23].ToString());
            this.textBox23.Text = MyPriceTextBox.doMaskOnce(obj[24].ToString());
            this.checkBox1.IsChecked = (bool)obj[25];
            this.checkBox2.IsChecked = (bool)obj[26];
            this.checkBox3.IsChecked = (bool)obj[27];
            this.checkBox4.IsChecked = (bool)obj[28];
            this.checkBox5.IsChecked = (bool)obj[29];
            this.checkBox6.IsChecked = (bool)obj[30];
            this.checkBox7.IsChecked = (bool)obj[31];
            this.checkBox8.IsChecked = (bool)obj[32];
            this.checkBox9.IsChecked = (bool)obj[33];
            this.checkBox10.IsChecked = (bool)obj[34];
            this.checkBox11.IsChecked = (bool)obj[35];
            this.checkBox12.IsChecked = (bool)obj[36];
            this.checkBox13.IsChecked = (bool)obj[37];
            this.checkBox14.IsChecked = (bool)obj[38];
            this.checkBox15.IsChecked = (bool)obj[39];
            this.checkBox16.IsChecked = (bool)obj[40];
            this.checkBox17.IsChecked = (bool)obj[41];
            this.checkBox18.IsChecked = (bool)obj[42];
            this.checkBox19.IsChecked = (bool)obj[43];
            this.checkBox20.IsChecked = (bool)obj[44];
            this.checkBox21.IsChecked = (bool)obj[45];
            this.checkBox22.IsChecked = (bool)obj[46];
            this.checkBox23.IsChecked = (bool)obj[47];
            this.checkBox24.IsChecked = (bool)obj[48];
            this.checkBox25.IsChecked = (bool)obj[49];
            this.checkBox26.IsChecked = (bool)obj[50];
            this.checkBox27.IsChecked = (bool)obj[51];
            this.checkBox28.IsChecked = (bool)obj[52];
            this.checkBox29.IsChecked = (bool)obj[53];
            this.checkBox30.IsChecked = (bool)obj[54];
            TextRange _RText = new TextRange(this.richTextBox1.Document.ContentStart, this.richTextBox1.Document.ContentEnd);
            _RText.Text = obj[55].ToString();
            this.textBox24.Text = obj[56].ToString();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void goOutFromChangeMode()
        {
            textBox1.Focus();
            changeMode = false;
            changeCombo.Visibility = Visibility.Hidden;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (!changeMode)
            {
                if (e.Key == Key.Right || e.Key == Key.Up) next_button_Click(null, null);
                else if (e.Key == Key.Left || e.Key == Key.Down) before_button_Click(null, null);
                else if (e.Key == Key.Escape) Close();
                else if (e.Key == Key.Enter)
                {
                    if (msgShow)
                    {
                        msgShow = false;
                        return;
                    }
                    changeCombo.Visibility = Visibility.Visible;
                    changeCombo.Focus();
                    changeMode = true;
                }
            }
            else  // now we are in changeMode
            {
                if (e.Key == Key.Escape)
                {
                    goOutFromChangeMode();
                    if (editing)
                    {
                        makeNonEditableAll();
                        editButton.Visibility = Visibility.Hidden;
                        editing = false;
                        price.Stop();
                    }
                }
                else if (e.Key == Key.Enter)
                {
                    if (msgShow)
                    {
                        msgShow = false;
                        return;
                    }
                    if (editing)
                    {
                        editButton_Click(null, null);
                        return;
                    }
                    if (changeCombo.SelectedIndex == 2)   // cancel
                    {
                        goOutFromChangeMode();
                    }
                    else if (changeCombo.SelectedIndex == 1) // remove 
                    {
                        try
                        {
                            String str = (String)ID_Lbl.Content;
                            String mode = "";
                            int ind = 0;
                            while (str[ind] != '-')
                            {
                                mode += str[ind++];
                            }
                            mode.TrimEnd();
                            String sql = "EXEC RemoveByID " + str.Substring(ind + 1).TrimStart() + "," + mode;
                            DB.execSql(sql);
                            TextRange _RText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                            String sqlForArchive = "EXEC InsertBaghVillaF '" + date_Lbl.Content
                                + "',N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text
                                + "',N'" + textBox5.Text + "',N'" + textBox6.Text + "',N'" + textBox7.Text + "',N'" + textBox8.Text
                                + "',N'" + textBox9.Text + "',N'" + textBox10.Text + "',N'" + textBox11.Text + "',N'" + textBox12.Text
                                + "',N'" + textBox13.Text + "',N'" + textBox14.Text + "',N'" + textBox15.Text + "',N'" + textBox16.Text
                                + "',N'" + textBox17.Text + "',N'" + textBox18.Text + "',N'" + textBox19.Text + "',N'" + textBox20.Text
                                + "',N'" + textBox21.Text + "',N'" + MyPriceTextBox.getStringFromMasked(textBox22.Text)
                                + "',N'" + MyPriceTextBox.getStringFromMasked(textBox23.Text)
                                + "'," + checkBox1.IsChecked + "," + checkBox2.IsChecked + "," + checkBox3.IsChecked
                                + "," + checkBox4.IsChecked + "," + checkBox5.IsChecked + "," + checkBox6.IsChecked
                                + "," + checkBox7.IsChecked + "," + checkBox8.IsChecked + "," + checkBox9.IsChecked
                                + "," + checkBox10.IsChecked + "," + checkBox11.IsChecked + "," + checkBox12.IsChecked
                                + "," + checkBox13.IsChecked + "," + checkBox14.IsChecked + "," + checkBox15.IsChecked
                                + "," + checkBox16.IsChecked + "," + checkBox17.IsChecked + "," + checkBox18.IsChecked
                                + "," + checkBox19.IsChecked + "," + checkBox20.IsChecked + "," + checkBox21.IsChecked
                                + "," + checkBox22.IsChecked + "," + checkBox23.IsChecked + "," + checkBox24.IsChecked
                                + "," + checkBox25.IsChecked + "," + checkBox26.IsChecked + "," + checkBox27.IsChecked
                                + "," + checkBox28.IsChecked + "," + checkBox29.IsChecked + "," + checkBox30.IsChecked
                                + ",N'" + _RText.Text + "',N'" + textBox24.Text + "'";

                            DB.execSqlInArchive(sqlForArchive);
                            dt.Rows.RemoveAt(index);
                            msgShow = true;
                            MessageBox.Show("ملک مورد نظر با موفقیت حذف گردید", "حذف", MessageBoxButton.OK, MessageBoxImage.Information);
                            goOutFromChangeMode();
                            tw.Close();
                            removeLbl.Content = "این ملک حذف گردیده است و برای آخرین بار در این فرم آن را ملاحظه می فرمایید";
                            removeLbl.Visibility = Visibility.Visible;
                        }
                        catch (Exception)
                        {
                            msgShow = true;
                            MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else   // edit
                    {
                        textBox1.Focus();
                        changeCombo.Visibility = Visibility.Hidden;
                        editButton.Visibility = Visibility.Visible;
                        editing = true;
                        makeEditableAll();
                        price.Start();
                    }
                }
                if (editing)
                {
                    if (e.Key == Key.Up)
                    {
                        if (textBox2.IsFocused || textBox3.IsFocused || textBox4.IsFocused || textBox5.IsFocused || textBox6.IsFocused) textBox1.Focus();
                        else if (textBox7.IsFocused) textBox8.Focus();
                        else if (textBox8.IsFocused) textBox7.Focus();
                        else if (textBox9.IsFocused) textBox2.Focus();
                        else if (textBox10.IsFocused) textBox9.Focus();
                        else if (textBox11.IsFocused) textBox10.Focus();
                        else if (textBox14.IsFocused) textBox11.Focus();
                        else if (textBox13.IsFocused) textBox5.Focus();
                        else if (textBox12.IsFocused) textBox13.Focus();
                        else if (textBox15.IsFocused) textBox12.Focus();
                        else if (textBox16.IsFocused) textBox15.Focus();
                        else if (textBox17.IsFocused) textBox14.Focus();
                        else if (textBox18.IsFocused) textBox17.Focus();
                        else if (textBox19.IsFocused) textBox18.Focus();
                        else if (textBox20.IsFocused || textBox21.IsFocused) textBox19.Focus();
                        else if (textBox22.IsFocused) textBox20.Focus();
                        else if (textBox23.IsFocused) textBox21.Focus();
                        else if (richTextBox1.IsFocused) textBox22.Focus();
                        else if (textBox24.IsFocused) checkBox20.Focus();
                        else if (checkBox20.IsFocused) checkBox9.Focus();
                    }
                    else if (e.Key == Key.Down)
                    {
                        if (textBox1.IsFocused) textBox2.Focus();
                        else if (textBox2.IsFocused || textBox3.IsFocused) textBox9.Focus();
                        else if (textBox4.IsFocused || textBox5.IsFocused || textBox6.IsFocused) textBox13.Focus();
                        else if (textBox7.IsFocused) checkBox11.Focus();
                        else if (textBox8.IsFocused) textBox7.Focus();
                        else if (textBox9.IsFocused) textBox10.Focus();
                        else if (textBox10.IsFocused) textBox11.Focus();
                        else if (textBox11.IsFocused) textBox14.Focus();
                        else if (textBox12.IsFocused) textBox15.Focus();
                        else if (textBox13.IsFocused) textBox12.Focus();
                        else if (textBox14.IsFocused || textBox16.IsFocused) textBox17.Focus();
                        else if (textBox15.IsFocused) textBox16.Focus();
                        else if (textBox17.IsFocused) textBox18.Focus();
                        else if (textBox18.IsFocused) textBox19.Focus();
                        else if (textBox19.IsFocused) textBox20.Focus();
                        else if (textBox20.IsFocused) textBox22.Focus();
                        else if (textBox21.IsFocused) textBox23.Focus();
                        else if (textBox22.IsFocused || textBox23.IsFocused) richTextBox1.Focus();
                        else if (textBox24.IsFocused) richTextBox1.Focus();
                    }
                    else if (e.Key == Key.Left)
                    {
                        if (textBox1.IsFocused) textBox8.Focus();
                        else if (textBox2.IsFocused) textBox3.Focus();
                        else if (textBox3.IsFocused) textBox4.Focus();
                        else if (textBox4.IsFocused) textBox5.Focus();
                        else if (textBox5.IsFocused) textBox6.Focus();
                        else if (textBox6.IsFocused) textBox7.Focus();
                        else if (textBox9.IsFocused) textBox13.Focus();
                        else if (textBox10.IsFocused) textBox12.Focus();
                        else if (textBox11.IsFocused) textBox15.Focus();
                        else if (textBox14.IsFocused) textBox16.Focus();
                        else if (textBox20.IsFocused) textBox21.Focus();
                        else if (textBox22.IsFocused) textBox23.Focus();
                        else if (richTextBox1.IsFocused) textBox24.Focus();
                        else if (textBox13.IsFocused || textBox12.IsFocused || textBox15.IsFocused || textBox16.IsFocused || textBox17.IsFocused || textBox18.IsFocused || textBox19.IsFocused || textBox21.IsFocused || textBox23.IsFocused) checkBox1.Focus();
                    }
                    else if (e.Key == Key.Right)
                    {
                        if (textBox8.IsFocused) textBox1.Focus();
                        else if (textBox3.IsFocused) textBox2.Focus();
                        else if (textBox4.IsFocused) textBox3.Focus();
                        else if (textBox5.IsFocused) textBox4.Focus();
                        else if (textBox6.IsFocused) textBox5.Focus();
                        else if (textBox7.IsFocused) textBox6.Focus();
                        else if (textBox13.IsFocused) textBox9.Focus();
                        else if (textBox12.IsFocused) textBox10.Focus();
                        else if (textBox15.IsFocused) textBox11.Focus();
                        else if (textBox16.IsFocused) textBox14.Focus();
                        else if (textBox21.IsFocused) textBox20.Focus();
                        else if (textBox23.IsFocused) textBox22.Focus();
                        else if (textBox24.IsFocused) textBox23.Focus();
                    }
                }
            }
        }

        private void textBox22_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricemeter = true;
        }

        private void textBox23_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricetotal = true;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            makeNonEditableAll();
            String id = ((String)ID_Lbl.Content);
            int ind = id.IndexOf('-');
            id = id.Substring(ind + 1);
            TextRange _RText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
            try
            {
                String sql = "EXEC EditBaghVillaF " + id + ",'" + date_Lbl.Content
                    + "',N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text
                    + "',N'" + textBox5.Text + "',N'" + textBox6.Text + "',N'" + textBox7.Text + "',N'" + textBox8.Text
                    + "',N'" + textBox9.Text + "',N'" + textBox10.Text + "',N'" + textBox11.Text + "',N'" + textBox12.Text
                    + "',N'" + textBox13.Text + "',N'" + textBox14.Text + "',N'" + textBox15.Text + "',N'" + textBox16.Text
                    + "',N'" + textBox17.Text + "',N'" + textBox18.Text + "',N'" + textBox19.Text + "',N'" + textBox20.Text
                    + "',N'" + textBox21.Text + "',N'" + MyPriceTextBox.getStringFromMasked(textBox22.Text)
                    + "',N'" + MyPriceTextBox.getStringFromMasked(textBox23.Text)
                    + "'," + checkBox1.IsChecked + "," + checkBox2.IsChecked + "," + checkBox3.IsChecked
                    + "," + checkBox4.IsChecked + "," + checkBox5.IsChecked + "," + checkBox6.IsChecked
                    + "," + checkBox7.IsChecked + "," + checkBox8.IsChecked + "," + checkBox9.IsChecked
                    + "," + checkBox10.IsChecked + "," + checkBox11.IsChecked + "," + checkBox12.IsChecked
                    + "," + checkBox13.IsChecked + "," + checkBox14.IsChecked + "," + checkBox15.IsChecked
                    + "," + checkBox16.IsChecked + "," + checkBox17.IsChecked + "," + checkBox18.IsChecked
                    + "," + checkBox19.IsChecked + "," + checkBox20.IsChecked + "," + checkBox21.IsChecked
                    + "," + checkBox22.IsChecked + "," + checkBox23.IsChecked + "," + checkBox24.IsChecked
                    + "," + checkBox25.IsChecked + "," + checkBox26.IsChecked + "," + checkBox27.IsChecked
                    + "," + checkBox28.IsChecked + "," + checkBox29.IsChecked + "," + checkBox30.IsChecked
                    + ",N'" + _RText.Text + "',N'" + textBox24.Text + "'";

                DB.execSql(sql);
                msgShow = true;
                MessageBox.Show("رکورد با موفقیت ویرایش گردید", "ویرایش", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                msgShow = true;
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tw.Close();
            editButton.Visibility = Visibility.Hidden;
            goOutFromChangeMode();

            DataRow dr = dt.NewRow();
            dr.BeginEdit();
            dr[0] = id;
            dr[1] = date_Lbl.Content;
            dr[2] = textBox1.Text;
            dr[3] = textBox2.Text;
            dr[4] = textBox3.Text;
            dr[5] = textBox4.Text;
            dr[6] = textBox5.Text;
            dr[7] = textBox6.Text;
            dr[8] = textBox7.Text;
            dr[9] = textBox8.Text;
            dr[10] = textBox9.Text;
            dr[11] = textBox10.Text;
            dr[12] = textBox11.Text;
            dr[13] = textBox12.Text;
            dr[14] = textBox13.Text;
            dr[15] = textBox14.Text;
            dr[16] = textBox15.Text;
            dr[17] = textBox16.Text;
            dr[18] = textBox17.Text;
            dr[19] = textBox18.Text;
            dr[20] = textBox19.Text;
            dr[21] = textBox20.Text;
            dr[22] = textBox21.Text;
            dr[23] = MyPriceTextBox.getStringFromMasked(textBox22.Text);
            dr[24] = MyPriceTextBox.getStringFromMasked(textBox23.Text);
            dr[25] = checkBox1.IsChecked;
            dr[26] = checkBox2.IsChecked;
            dr[27] = checkBox3.IsChecked;
            dr[28] = checkBox4.IsChecked;
            dr[29] = checkBox5.IsChecked;
            dr[30] = checkBox6.IsChecked;
            dr[31] = checkBox7.IsChecked;
            dr[32] = checkBox8.IsChecked;
            dr[33] = checkBox9.IsChecked;
            dr[34] = checkBox10.IsChecked;
            dr[35] = checkBox11.IsChecked;
            dr[36] = checkBox12.IsChecked;
            dr[37] = checkBox13.IsChecked;
            dr[38] = checkBox14.IsChecked;
            dr[39] = checkBox15.IsChecked;
            dr[40] = checkBox16.IsChecked;
            dr[41] = checkBox17.IsChecked;
            dr[42] = checkBox18.IsChecked;
            dr[43] = checkBox19.IsChecked;
            dr[44] = checkBox20.IsChecked;
            dr[45] = checkBox21.IsChecked;
            dr[46] = checkBox22.IsChecked;
            dr[47] = checkBox23.IsChecked;
            dr[48] = checkBox24.IsChecked;
            dr[49] = checkBox25.IsChecked;
            dr[50] = checkBox26.IsChecked;
            dr[51] = checkBox27.IsChecked;
            dr[52] = checkBox28.IsChecked;
            dr[53] = checkBox29.IsChecked;
            dr[54] = checkBox30.IsChecked;
            dr[55] = _RText.Text;
            dr[56] = textBox24.Text;
            dr.EndEdit();

            dt.Rows.RemoveAt(index);
            dt.Rows.InsertAt(dr, index);

            editing = false;
            price.Stop();
        }
    }
}