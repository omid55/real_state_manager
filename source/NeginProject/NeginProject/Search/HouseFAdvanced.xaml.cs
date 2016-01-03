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
using System.Data;

namespace NeginProject.Search
{
    /// <summary>
    /// Interaction logic for HouseFAdvanced.xaml
    /// </summary>
    public partial class HouseFAdvanced : Window
    {
        private DispatcherTimer price;
        private bool pricemeter1 = false;
        private bool pricemeter2 = false;
        private bool pricetotal = false;
        private bool loaded = false;
        private bool errorOccurred = false;
        private string[] cols;
        public Session session;


        public HouseFAdvanced()
        {
            InitializeComponent();

            textBox1.Focus();

            price = new DispatcherTimer();
            price.Tick += new EventHandler(price_Tick);
            price.Interval = TimeSpan.FromSeconds(1);
            price.Start();

            code_Label.Content = Codes.HouseForooshi + " - ";
        }

        void price_Tick(object sender, EventArgs e)
        {
            MyPriceTextBox.doMask(pricemeter1, textBox19);
            MyPriceTextBox.doMask(pricemeter2, textBox20);
            MyPriceTextBox.doMask(pricetotal, textBox21);
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            errorOccurred = false;
            TextRange _RText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
            try
            {
                String tr = _RText.Text.TrimEnd();
                tr = tr.TrimStart();
                if (tr == "\r\n") tr = "";

                String date = (MaskedDate.Text[0] == '_') ? "" : MaskedDate.Text;

                String[] s = { "'" + ID_Txt.Text + "'","N'" + date + "'","N'" + textBox1.Text + "'","N'" + textBox2.Text + "'","N'" + textBox3.Text + "'","N'" + textBox4.Text
                    + "'","N'" + textBox5.Text + "'","N'" + textBox6.Text + "'","N'" + textBox7.Text + "'","N'" + textBox8.Text
                    + "'","N'" + textBox9.Text + "'","N'" + textBox10.Text + "'","N'" + textBox11.Text + "'","N'" + textBox12.Text
                    + "'","N'" + textBox13.Text + "'","N'" + textBox14.Text + "'","N'" + textBox15.Text + "'","N'" + textBox16.Text
                    + "'","N'" + textBox17.Text + "'","N'" + textBox18.Text + "'","N'" + MyPriceTextBox.getStringFromMasked(textBox19.Text) + "'","N'" + MyPriceTextBox.getStringFromMasked(textBox20.Text)
                    + "'","N'" + MyPriceTextBox.getStringFromMasked(textBox21.Text) + "'", checkBox1.IsChecked.ToString() , checkBox2.IsChecked.ToString() , checkBox3.IsChecked.ToString()
                    , checkBox4.IsChecked.ToString() , checkBox5.IsChecked.ToString() , checkBox6.IsChecked.ToString()
                    , checkBox7.IsChecked.ToString() , checkBox8.IsChecked.ToString() , checkBox9.IsChecked.ToString()
                    , checkBox10.IsChecked.ToString() , checkBox11.IsChecked.ToString() , checkBox12.IsChecked.ToString()
                    , checkBox13.IsChecked.ToString() , checkBox14.IsChecked.ToString() 
                    ,"N'" + _RText.Text + "'","N'" + txt_Moarefino.Text + "'"};

                SearchSQL sq = new SearchSQL(s, "SearchManzelF");
                DataTable dt = sq.getResult(DBComboBox.SelectedIndex);

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
                    res.which = Codes.HouseForooshi;

                    if (dt != null)
                    {
                        res.dt = dt.Copy();
                        if (cols == null)
                        {
                            cols = new string[dt.Columns.Count];
                            for (int i = 0; i < cols.Length; i++)
                            {
                                cols[i] = dt.Columns[i].ColumnName;
                            }
                        }
                        if (MaskedDate.Text == "____/__/__") dt.Columns.Remove(cols[1]);
                        if (textBox2.Text.Trim().Length == 0) dt.Columns.Remove(cols[3]);
                        if (textBox3.Text.Trim().Length == 0) dt.Columns.Remove(cols[4]);
                        if (textBox4.Text.Trim().Length == 0) dt.Columns.Remove(cols[5]);
                        if (textBox5.Text.Trim().Length == 0) dt.Columns.Remove(cols[6]);
                        if (textBox6.Text.Trim().Length == 0) dt.Columns.Remove(cols[7]);
                        if (textBox7.Text.Trim().Length == 0) dt.Columns.Remove(cols[8]);
                        if (textBox8.Text.Trim().Length == 0) dt.Columns.Remove(cols[9]);
                        if (textBox9.Text.Trim().Length == 0) dt.Columns.Remove(cols[10]);
                        if (textBox10.Text.Trim().Length == 0) dt.Columns.Remove(cols[11]);
                        if (textBox11.Text.Trim().Length == 0) dt.Columns.Remove(cols[12]);
                        if (textBox12.Text.Trim().Length == 0) dt.Columns.Remove(cols[13]);
                        if (textBox13.Text.Trim().Length == 0) dt.Columns.Remove(cols[14]);
                        if (textBox14.Text.Trim().Length == 0) dt.Columns.Remove(cols[15]);
                        if (textBox15.Text.Trim().Length == 0) dt.Columns.Remove(cols[16]);
                        if (textBox16.Text.Trim().Length == 0) dt.Columns.Remove(cols[17]);
                        if (textBox17.Text.Trim().Length == 0) dt.Columns.Remove(cols[18]);
                        if (textBox18.Text.Trim().Length == 0) dt.Columns.Remove(cols[19]);
                        if (textBox19.Text.Trim().Length == 0) dt.Columns.Remove(cols[20]);
                        if (textBox20.Text.Trim().Length == 0) dt.Columns.Remove(cols[21]);
                        if (checkBox1.IsChecked == false) dt.Columns.Remove(cols[23]);
                        if (checkBox2.IsChecked == false) dt.Columns.Remove(cols[24]);
                        if (checkBox3.IsChecked == false) dt.Columns.Remove(cols[25]);
                        if (checkBox4.IsChecked == false) dt.Columns.Remove(cols[26]);
                        if (checkBox5.IsChecked == false) dt.Columns.Remove(cols[27]);
                        if (checkBox6.IsChecked == false) dt.Columns.Remove(cols[28]);
                        if (checkBox7.IsChecked == false) dt.Columns.Remove(cols[29]);
                        if (checkBox8.IsChecked == false) dt.Columns.Remove(cols[30]);
                        if (checkBox9.IsChecked == false) dt.Columns.Remove(cols[31]);
                        if (checkBox10.IsChecked == false) dt.Columns.Remove(cols[32]);
                        if (checkBox11.IsChecked == false) dt.Columns.Remove(cols[33]);
                        if (checkBox12.IsChecked == false) dt.Columns.Remove(cols[34]);
                        if (checkBox13.IsChecked == false) dt.Columns.Remove(cols[35]);
                        if (checkBox14.IsChecked == false) dt.Columns.Remove(cols[36]);
                        if (_RText.Text == "\r\n") dt.Columns.Remove(cols[37]);
                        if (txt_Moarefino.Text.Length == 0) dt.Columns.Remove(cols[38]);
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
                if (ID_Txt.IsFocused) MaskedDate.Focus();
                if (textBox1.IsFocused || textBox8.IsFocused) ID_Txt.Focus();
                if (textBox2.IsFocused || textBox3.IsFocused || textBox4.IsFocused || textBox5.IsFocused || textBox6.IsFocused || textBox7.IsFocused) textBox1.Focus();
                else if (textBox8.IsFocused) textBox2.Focus();
                else if (textBox9.IsFocused) textBox3.Focus();
                else if (textBox10.IsFocused) textBox4.Focus();
                else if (textBox11.IsFocused) textBox5.Focus();
                else if (textBox12.IsFocused) textBox6.Focus();
                else if (textBox13.IsFocused) textBox7.Focus();
                else if (textBox14.IsFocused || textBox15.IsFocused) textBox18.Focus();
                else if (textBox16.IsFocused) gridView.Focus();
                else if (textBox17.IsFocused) textBox16.Focus();
                else if (textBox18.IsFocused) textBox17.Focus();
                else if (textBox19.IsFocused) textBox14.Focus();
                else if (textBox20.IsFocused) textBox15.Focus();
                else if (richTextBox1.IsFocused) textBox19.Focus();
                else if (txt_Moarefino.IsFocused) textBox21.Focus();
                else if (textBox21.IsFocused) checkBox7.Focus();
            }
            else if (e.Key == Key.Down)
            {
                if (MaskedDate.IsFocused) ID_Txt.Focus();
                if (ID_Txt.IsFocused) textBox8.Focus();
                if (textBox1.IsFocused) textBox2.Focus();
                else if (textBox2.IsFocused) textBox8.Focus();
                else if (textBox3.IsFocused) textBox9.Focus();
                else if (textBox4.IsFocused) textBox10.Focus();
                else if (textBox5.IsFocused) textBox11.Focus();
                else if (textBox6.IsFocused) textBox12.Focus();
                else if (textBox7.IsFocused) textBox13.Focus();
                else if (textBox8.IsFocused || textBox9.IsFocused) textBox14.Focus();
                else if (textBox10.IsFocused || textBox11.IsFocused || textBox12.IsFocused) textBox15.Focus();
                else if (textBox13.IsFocused) checkBox1.Focus();
                else if (textBox14.IsFocused || textBox15.IsFocused) textBox16.Focus();
                else if (textBox16.IsFocused) textBox17.Focus();
                else if (textBox17.IsFocused) textBox18.Focus();
                else if (textBox18.IsFocused) textBox19.Focus();
                else if (textBox19.IsFocused || textBox20.IsFocused) richTextBox1.Focus();
                else if (textBox21.IsFocused) txt_Moarefino.Focus();
                else if (txt_Moarefino.IsFocused || richTextBox1.IsFocused) search_button.Focus();
            }
            else if (e.Key == Key.Left)
            {
                if (textBox2.IsFocused) textBox3.Focus();
                else if (textBox3.IsFocused) textBox4.Focus();
                else if (textBox4.IsFocused) textBox5.Focus();
                else if (textBox5.IsFocused) textBox6.Focus();
                else if (textBox6.IsFocused) textBox7.Focus();
                else if (textBox8.IsFocused) textBox9.Focus();
                else if (textBox9.IsFocused) textBox10.Focus();
                else if (textBox10.IsFocused) textBox11.Focus();
                else if (textBox11.IsFocused) textBox12.Focus();
                else if (textBox12.IsFocused) textBox13.Focus();
                else if (textBox14.IsFocused && !gridView.Focused) textBox15.Focus();
                else if (textBox19.IsFocused) textBox20.Focus();
                else if (textBox20.IsFocused) textBox21.Focus();
                else if (richTextBox1.IsFocused) txt_Moarefino.Focus();
                else if (textBox16.IsFocused || textBox17.IsFocused || textBox18.IsFocused) checkBox1.Focus();
            }
            else if (e.Key == Key.Right)
            {
                if (textBox3.IsFocused) textBox2.Focus();
                else if (textBox4.IsFocused) textBox3.Focus();
                else if (textBox5.IsFocused) textBox4.Focus();
                else if (textBox6.IsFocused) textBox5.Focus();
                else if (textBox7.IsFocused) textBox6.Focus();
                else if (textBox9.IsFocused) textBox8.Focus();
                else if (textBox10.IsFocused) textBox9.Focus();
                else if (textBox11.IsFocused) textBox10.Focus();
                else if (textBox12.IsFocused) textBox11.Focus();
                else if (textBox13.IsFocused) textBox12.Focus();
                else if (textBox15.IsFocused && !gridView.Focused) textBox14.Focus();
                else if (textBox20.IsFocused) textBox19.Focus();
                else if (textBox21.IsFocused) textBox20.Focus();
                else if (txt_Moarefino.IsFocused) richTextBox1.Focus();
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

        private void textBox19_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricemeter1 = true;
        }

        private void textBox20_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricemeter2 = true;
        }

        private void textBox21_TextChanged(object sender, TextChangedEventArgs e)
        {
            pricetotal = true;
        }
    }
}
