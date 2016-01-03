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
using System.Windows.Threading;

namespace NeginProject.Insert
{
    /// <summary>
    /// Interaction logic for BaghVillaF.xaml
    /// </summary>
    public partial class BaghVillaF : Window
    {
        private DispatcherTimer price;
        private bool pricemeter = false;
        private bool pricetotal = false;
        public String newId;
        private bool isRed = false;

        public BaghVillaF()
        {
            InitializeComponent();

            initLabels();

            textBox1.Focus();

            price = new DispatcherTimer();
            price.Tick += new EventHandler(price_Tick);
            price.Interval = TimeSpan.FromSeconds(1);
            price.Start();

            WndConfig.setConfiguration(this);
        }

        private void initLabels()
        {
            Calendar cal = new Calendar(DateTime.Today.ToShortDateString(), Calendar.Solar_Date);
            date_Lbl.Content = cal.calcOtherModeNumeric();
            newId = getNewId();
            ID_Lbl.Content = Codes.BaghVillaForooshi + " -  " + newId;
        }

        void price_Tick(object sender, EventArgs e)
        {
            MyPriceTextBox.doMask(pricemeter, textBox22);
            MyPriceTextBox.doMask(pricetotal, textBox23);
        }

        private String getNewId()
        {
            String sql = "EXEC GetNewIdBaghVillaF";
            String str = "";
            try
            {
                str = DB.execSqlReturnScalar(sql).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها , لطفا با پشتیبان تماس بگیرید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return str;
        }

        private void insert_button_Click(object sender, RoutedEventArgs e)
        {
            if (!isRed)
            {
                if (textBox20.Text.Trim() == "")
                {
                    isRed = true;
                    textBox20.Background = Brushes.Pink;
                }
                if (textBox21.Text.Trim() == "")
                {
                    isRed = true;
                    textBox21.Background = Brushes.Pink;
                }
                if (textBox23.Text.Trim() == "")
                {
                    isRed = true;
                    textBox23.Background = Brushes.Pink;
                }
            }
            else
            {
                TextRange _RText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                try
                {
                    String sql = "EXEC InsertBaghVillaF '" + date_Lbl.Content
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
                    MessageBox.Show("رکورد جدید با موفقیت ثبت گردید", "ثبت", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (AgainCheckBox.IsChecked == false)
                    {
                        Insert.BaghVillaF w = new Insert.BaghVillaF();
                        this.Close();
                        if (w.newId != null && w.newId.Length > 0) w.Show();
                    }
                    else
                    {
                        initLabels();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox txt = ((TextBox)sender);
                if (txt.Text.Trim() == "" && txt.Background != Brushes.White) txt.Background = Brushes.White;
                else if (txt.Background != Brushes.LightGray) txt.Background = Brushes.LightGray;
            }
            catch (Exception)
            {
                RichTextBox txt = ((RichTextBox)sender);
                TextRange _RText = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                if (_RText.Text.Trim() == "" && txt.Background != Brushes.White) txt.Background = Brushes.White;
                else if (txt.Background != Brushes.LightGray) txt.Background = Brushes.LightGray;
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            TextRange _text = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
            if (_text.Text.Trim() == "" && textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "" && textBox4.Text.Trim() == "" && textBox5.Text.Trim() == "" && textBox6.Text.Trim() == "" && textBox7.Text.Trim() == "" && textBox8.Text.Trim() == "" && textBox9.Text.Trim() == "" && textBox10.Text.Trim() == "" && textBox11.Text.Trim() == "" && textBox12.Text.Trim() == "" && textBox13.Text.Trim() == "" && textBox14.Text.Trim() == "" && textBox15.Text.Trim() == "" && textBox16.Text.Trim() == "" && textBox17.Text.Trim() == "" && textBox18.Text.Trim() == "" && textBox19.Text.Trim() == "" && textBox20.Text.Trim() == "" && textBox21.Text.Trim() == "" && textBox22.Text.Trim() == "" && textBox23.Text.Trim() == "" && textBox24.Text.Trim() == "")
            {
                Close();
                return;
            }
            MessageBoxResult res = MessageBox.Show("آیا می خواهید صفحه ی ثبت را ببندید ؟", "ثبت", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void textBox22_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricemeter = true;
            if (((TextBox)sender).Text.Trim() == "" && ((TextBox)sender).Background != Brushes.White) ((TextBox)sender).Background = Brushes.White;
            else if (((TextBox)sender).Background != Brushes.LightGray) ((TextBox)sender).Background = Brushes.LightGray;
        }

        private void textBox23_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricetotal = true;
            if (((TextBox)sender).Text.Trim() == "" && ((TextBox)sender).Background != Brushes.White) ((TextBox)sender).Background = Brushes.White;
            else if (((TextBox)sender).Background != Brushes.LightGray) ((TextBox)sender).Background = Brushes.LightGray;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
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
                else if (back_button.IsFocused || insert_button.IsFocused) richTextBox1.Focus();
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
                else if (richTextBox1.IsFocused) insert_button.Focus();
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
            else if (e.Key == Key.Escape)
            {
                TextRange _text = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                if (_text.Text.Trim() == "" && textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "" && textBox4.Text.Trim() == "" && textBox5.Text.Trim() == "" && textBox6.Text.Trim() == "" && textBox7.Text.Trim() == "" && textBox8.Text.Trim() == "" && textBox9.Text.Trim() == "" && textBox10.Text.Trim() == "" && textBox11.Text.Trim() == "" && textBox12.Text.Trim() == "" && textBox13.Text.Trim() == "" && textBox14.Text.Trim() == "" && textBox15.Text.Trim() == "" && textBox16.Text.Trim() == "" && textBox17.Text.Trim() == "" && textBox18.Text.Trim() == "" && textBox19.Text.Trim() == "" && textBox20.Text.Trim() == "" && textBox21.Text.Trim() == "" && textBox22.Text.Trim() == "" && textBox23.Text.Trim() == "" && textBox24.Text.Trim() == "")
                {
                    Close();
                    return;
                }
                MessageBoxResult res = MessageBox.Show("آیا می خواهید صفحه ی ثبت را ببندید ؟", "ثبت", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (newId.Length == 0) Close();
        }
    }
}
