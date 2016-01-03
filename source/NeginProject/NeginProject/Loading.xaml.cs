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
using System.ComponentModel;
using System.IO;

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        private BackgroundWorker openingDB;
        private String expireLblString;
        private bool expired = false;
        private bool registered = false;

        public Loading()
        {
            InitializeComponent();
        }

        public void goToExpiration()
        {
            Expiration xp = new Expiration();
            this.Close();
            xp.Show();
        }

        void openingDB_DoWork(object sender, DoWorkEventArgs e)
        {
            if (openingDB.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            try
            {
                Object obj=DB.execSqlReturnScalar("EXEC GetExpInfo");
                if (obj == null)
                {
                    MessageBox.Show("اطلاعات مربوط به تاریخ مصرف برنامه صحیح نمی باشد لطفا با پشتیبانی برنامه تماس حاصل بفرمایید", "خطای چک کردن مهلت استفاده", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(1);
                }
                else
                {
                    try
                    {
                        String s = (String)obj;

                        byte[] b = new byte[s.Length];
                        for (int i = 0; i < s.Length; i++)
                        {
                            b[i] = (byte)s[i];
                        }
                        FileStream fs = new FileStream("config.conf", FileMode.Create, FileAccess.Write);
                        fs.Write(b, 0, b.Length);
                        fs.Flush();
                        fs.Close();
                        fs.Dispose();
                    
                        String exp = MyCrypt.decryptWithDefaultValues(s);
                        if (exp == "0000")   // first time use
                        {
                            // enabled - begin - last - duration
                            String arg = "1-" + DateTime.Today.ToShortDateString() + "-" + DateTime.Today.ToShortDateString() + "-" + Codes.ExpireDurationInDays.ToString();
                            arg = MyCrypt.encryptWithDefaultValues(arg);
                            DB.execSql("EXEC SetExpInfo N'" + arg + "'",0);
                            expireLblString = Codes.ExpireDurationInDays.ToString();

                            // generating serial number for this product now
                            String serial = "";
                            int serialLeng=10;
                            Random rand = new Random();
                            for (int i = 0; i < serialLeng; i++)
                            {
                                serial += rand.Next(0, 9);
                            }
                            DB.execSql("EXEC SetSerialNumber N'" + serial + "'",0);
                        }
                        else if (exp == "111111")    // registered
                        {
                            registered = true;
                        }
                        else    // in trail period
                        {
                            String[] str = exp.Split('-');
                            String c = str[0];
                            if (c == "0")     // expired
                            {
                                expired = true;
                            }
                            else
                            {
                                DateTime begin = DateTime.Parse(str[1]);
                                DateTime last = DateTime.Parse(str[2]);
                                int diffInDB = Int32.Parse(str[3]);
                                if (DateTime.Today < last)   // expire it now because user change the time more than 1 day
                                {
                                    String arg = "0-" + begin.ToShortDateString() +"-" + DateTime.Today.ToShortDateString() + "-0";
                                    arg = MyCrypt.encryptWithDefaultValues(arg);
                                    DB.execSql("EXEC SetExpInfo N'" + arg + "'",0);
                                    expireLblString = "0";
                                    expired = true;
                                }
                                TimeSpan duration = DateTime.Today.Subtract(begin);
                                int diff = Codes.ExpireDurationInDays - duration.Days;
                                if (diff <= 0 || diffInDB < diff)   // expire it now
                                {
                                    String arg = "0-" + begin.ToShortDateString() + "-" + DateTime.Today.ToShortDateString() + "-0";
                                    arg = MyCrypt.encryptWithDefaultValues(arg);
                                    DB.execSql("EXEC SetExpInfo N'" + arg + "'",0);
                                    expireLblString = "0";
                                    expired = true;
                                }
                                else
                                {
                                    String arg = "1-" + begin.ToShortDateString() + "-" + DateTime.Today.ToShortDateString() + "-" + diff.ToString();
                                    arg = MyCrypt.encryptWithDefaultValues(arg);
                                    DB.execSql("EXEC SetExpInfo N'" + arg + "'",0);
                                    expireLblString = diff.ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("اطلاعات مربوط به تاریخ مصرف برنامه صحیح نمی باشد لطفا با پشتیبانی برنامه تماس حاصل بفرمایید", "خطای چک کردن مهلت استفاده", MessageBoxButton.OK, MessageBoxImage.Error);
                        MessageBox.Show("لطفا متن زیر را به پشتیبانی برنامه اعلام بفرمایید \n\n"+ex.Message,"متن تکنیکی خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        Environment.Exit(1);
                    }
                    try
                    {
                        Codes.setMainDirectory();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("مکان برنامه به درستی یافت نگردید", "خطای بدست آوردن محل اجرای برنامه", MessageBoxButton.OK, MessageBoxImage.Error);
                        MessageBox.Show("لطفا متن زیر را به پشتیبانی برنامه اعلام بفرمایید \n\n" + ex.Message, "متن تکنیکی خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        Environment.Exit(1);
                    }
                }

                DB.execSql("SELECT * FROM ApartemanMaskooniEstijari",0);
                //DB.execSqlInArchive("SELECT * FROM ApartemanMaskooniEstijari");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اتصال به پایگاه داده ها \n لطفا سرور و فایل های مربوط به پایگاه داده ها را چک بفرمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("لطفا متن زیر را به پشتیبانی برنامه اعلام بفرمایید \n\n" + ex.Message, "متن تکنیکی خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
            //openingDB.CancelAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            openingDB = new BackgroundWorker();
            openingDB.DoWork += new DoWorkEventHandler(openingDB_DoWork);
            openingDB.RunWorkerCompleted += new RunWorkerCompletedEventHandler(openingDB_RunWorkerCompleted);
            openingDB.RunWorkerAsync();
        }

        void openingDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            openingDB.Dispose();
            expireLbl.Content = expireLblString;
            if (expired) goToExpiration();
            myprogress.Visibility = Visibility.Hidden;
            Open.IsEnabled = true;
            Open.Visibility = Visibility.Visible;
            image1.Visibility = Visibility.Visible;
            Open.Focus();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Login w = new Login();
            this.Close();
            w.Show();
        }

        private void Open_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (registered)
            {
                expireLbl.Visibility = Visibility.Hidden;
                expireStr.Content = "نسخه ی کامل برنامه ی نگین در اختیار شما است .";
            }
        }
    }
}
