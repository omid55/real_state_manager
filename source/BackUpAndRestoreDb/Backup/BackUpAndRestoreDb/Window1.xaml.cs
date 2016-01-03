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
using System.IO;
using System.Data.SqlClient;

namespace BackUpAndRestoreDb
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        String mdf = "Negindb.mdf";
        String ldf = "Negindb_log.ldf";
        String bak = "C:\\BackUpLocation\\Negindb.bak";


        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = @"C:\";
                string newpath = System.IO.Path.Combine(path, "BackUpLocation");
                Directory.CreateDirectory(newpath);

                FileStream fmdf = new FileStream(mdf, FileMode.Open, FileAccess.Read);
                FileStream fldf = new FileStream(ldf, FileMode.Open, FileAccess.Read);
                FileStream fbak = new FileStream(bak, FileMode.Create, FileAccess.Write);

                byte[] fmcontent = new byte[fmdf.Length];
                fmdf.Read(fmcontent, 0, (int)fmdf.Length);
                fbak.Write(fmcontent, 0, (int)fmdf.Length);

                byte[] sym = new byte[3];
                sym[0] = (byte)'$'; sym[1] = (byte)'*'; sym[2] = (byte)'^';
                fbak.Write(sym, 0, 3);

                byte[] flcontent = new byte[fldf.Length];
                fldf.Read(flcontent, 0, (int)fldf.Length);
                fbak.Write(flcontent, 0, (int)fldf.Length);

                fbak.Flush();
                fbak.Close();
                fmdf.Close();
                fldf.Close();

                MessageBox.Show("یک نسخه ی پشتیبان در مسیر زیر با موفقیت قرار گرفت \n" + bak, "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در دسترسی به حافظه لطفا چک بفرمایید که حافظه قابل نوشتن و دارای فضای خالی مناسب باشد", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void execSql(String t)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            con = new SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|Negindb.mdf\";Integrated Security=True;User Instance=True";
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "EXEC SetExpInfo N'" + t + "'";
            cmd.ExecuteNonQuery();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("config.conf"))
            {
                StreamReader sr = null;
                String text = "";
                try
                {
                    sr = new StreamReader("config.conf");
                    text = sr.ReadToEnd();
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در دسترسی به فایل های مربوط به برنامه لطفا با پشتیبانی برنامه تماس حاصل بفرمایید", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                sr.Close();
                sr.Dispose();
                FileStream fmdf = new FileStream(mdf, FileMode.Create, FileAccess.Write);
                FileStream fldf = new FileStream(ldf, FileMode.Create, FileAccess.Write);
                FileStream fbak = new FileStream(bak, FileMode.Open, FileAccess.Read);

                byte[] fbcontent = new byte[fbak.Length];
                fbak.Read(fbcontent, 0, (int)fbak.Length);
                int len = fbcontent.Length;
                int index = 0;
                FileStream tmp = fmdf;
                while (index < len)
                {
                    if (fbcontent[index] == (byte)'$' && fbcontent[index + 1] == (byte)'*' && fbcontent[index + 2] == (byte)'^')
                    {
                        break;
                    }
                    index++;
                }
                fmdf.Write(fbcontent, 0, index);
                fldf.Write(fbcontent, index + 3, len - index - 3);

                fmdf.Flush();
                fldf.Flush();
                fmdf.Close();
                fldf.Close();
                fbak.Close();
                try
                {
                    execSql(text);
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در اتصال به پایگاه داده ها", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("پایگاه داده ها از مسیر زیر با موفقیت بازیابی شد \n" + bak, "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Information);
                Environment.Exit(1);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                p.StartInfo.FileName = "NeginProject.exe";
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در دسترسی به فایل اجرایی برنامه ی اصلی", "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                new RemoveAll().Show();
            }
        }
    }
}
