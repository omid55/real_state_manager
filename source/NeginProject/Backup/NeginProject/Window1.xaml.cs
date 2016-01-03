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
using System.Runtime.InteropServices;
using System.Windows.Interop;
using NeginProject.Search;
using NeginProject.Insert;
using System.IO;
using System.Windows.Media.Animation;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
//using WindowsInput;

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private TreeWindow tw = new TreeWindow();
        private DispatcherTimer autoBack;


        public Window1()
        {
            InitializeComponent();

            autoBack = new DispatcherTimer();
            autoBack.Tick += new EventHandler(autoBack_Tick);
            autoBack.Interval = TimeSpan.FromMinutes(1);
        }

        void autoBack_Tick(object sender, EventArgs e)
        {
            ChangeBackGround_Click(null, null);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("configBack.conf");
                String name = sr.ReadToEnd();
                Uri uri = new Uri(Environment.CurrentDirectory + "\\backgrounds\\" + name, UriKind.Absolute);
                image1.Source = new BitmapImage(uri);
                sr.Close();
            }
            catch (Exception)
            {
                if(sr!=null) sr.Close();
            }

            DoubleAnimation Dblanimation = new DoubleAnimation();
            Dblanimation.From = 0;
            Dblanimation.To = 600;
            Dblanimation.Duration = new Duration(TimeSpan.FromSeconds(3));
            tb1.BeginAnimation(TextBlock.WidthProperty, Dblanimation);

            dockManager.ParentWindow = this;
            tw.DockManager = dockManager;
            tw.Show(Dock.Right);

            MainAppMenu.Focus();
            // for farsi language =>
            //InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
            //InputSimulator.SimulateKeyPress(VirtualKeyCode.LMENU);
            //InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Home))
            {
                MainAppMenu.Focus();
            }
        }

        private void MenuItem_GotFocus(object sender, RoutedEventArgs e)
        {
            MenuItem MI = (MenuItem)sender;
        }

        private void Apa_E_S_Click(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanEdariS w = new Insert.ApartmanEdariS();
            //w.Topmost = true;
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void Apa_E_F_Click(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanEdariF w = new Insert.ApartmanEdariF();
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void Apa_M_F_Click(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanMaskooniF w = new Insert.ApartmanMaskooniF();
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void Apa_M_S_Click(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanMaskooniS w = new Insert.ApartmanMaskooniS();
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void BaghVilla_F_Click(object sender, RoutedEventArgs e)
        {
            Insert.BaghVillaF w = new Insert.BaghVillaF();
            if (w.newId!=null && w.newId.Length > 0) w.Show();
        }

        private void Magh_S_Click(object sender, RoutedEventArgs e)
        {
            Insert.MaghazeS w = new Insert.MaghazeS();
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void Majmooe_S_Click(object sender, RoutedEventArgs e)
        {
            Insert.HouseS w = new Insert.HouseS();
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void Magh_F_Click(object sender, RoutedEventArgs e)
        {
            Insert.MaghazeF w = new Insert.MaghazeF();
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void Majmooe_F_Click(object sender, RoutedEventArgs e)
        {
            Insert.HouseF w = new Insert.HouseF();
            if (w.newId != null && w.newId.Length > 0) w.Show();
        }

        private void Apa_M_SimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanMaskooniS().Show();
        }

        private void Apa_M_AdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanMaskooniSAdvanced().Show(); 
        }

        private void Apa_M_FSimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanMaskooniF().Show();
        }

        private void Apa_M_FAdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanMaskooniFAdvanced().Show(); 
        }

        private void Bagh_FSimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.BaghVillaF().Show();
        }

        private void Bagh_FAdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.BaghVillaFAdvanced().Show();
        }

        private void Apa_E_FSimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanEdariF().Show();
        }

        private void Apa_E_FAdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanEdariFAdvanced().Show();
        }

        private void Magh_FSimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.MaghazeF().Show(); 
        }

        private void Magh_FAdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.MaghazeFAdvanced().Show();
        }

        private void Apa_E_SimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanEdariS().Show(); 
        }

        private void Apa_E_AdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.ApartmanEdariSAdvanced().Show(); 
        }

        private void Magh_SSimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.MaghazeS().Show(); 
        }

        private void Magh_SAdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.MaghazeSAdvanced().Show();
        }

        private void House_FSimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.HouseF().Show();
        }

        private void House_FAdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.HouseFAdvanced().Show();
        }

        private void House_SSimpleSearch(object sender, RoutedEventArgs e)
        {
            new Search.HouseS().Show();
        }

        private void House_SAdvancedSearch(object sender, RoutedEventArgs e)
        {
            new Search.HouseSAdvanced().Show();
        }

        private void Apa_M_SIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s=new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان مسکونی استیجاری";
            s.ID_txt.Text = Codes.ApartmanMaskooniEstijari+"-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void Apa_E_SIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان اداری استیجاری";
            s.ID_txt.Text = Codes.ApartmanEdariEstijari + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show(); 
        }

        private void Magh_SIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی مغازه استیجاری";
            s.ID_txt.Text = Codes.MaghazeEstijari + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void House_SIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی منزل یا مجموعه استیجاری";
            s.ID_txt.Text = Codes.HouseEstijari + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void Apa_M_FIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان مسکونی فروشی";
            s.ID_txt.Text = Codes.ApartmanMaskooniForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void Apa_E_FIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان اداری فروشی";
            s.ID_txt.Text = Codes.ApartmanEdariForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void Magh_FIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی مغازه فروشی";
            s.ID_txt.Text = Codes.MaghazeForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void House_FIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی منزل یا مجموعه فروشی";
            s.ID_txt.Text = Codes.HouseForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void Bagh_FIDSearch(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی باغ یا ویلای فروشی";
            s.ID_txt.Text = Codes.BaghVillaForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Show();
        }

        private void ChangeBackGround_Click(object sender, RoutedEventArgs e)
        {
            /*String str = @"pack://application:,,,/Images\";
            if (counter == MAXPICS+1)
            {
                counter = 1;
            }
            str += counter.ToString() + ".jpg";
            counter++;
            image1.Source = new BitmapImage(new Uri(str));*/

            String path = Environment.CurrentDirectory + "\\backgrounds";
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fi = di.GetFiles("*.jpg");

            if (fi.Length == 0) return;

            String name = "";
            StreamReader sr = null;
            try
            {
                int index = 0;
                sr = new StreamReader("configBack.conf");
                name = sr.ReadToEnd();
                for (index = 0; index < fi.Length; index++)
                {
                    if (fi[index].Name == name)
                    {
                        index++;
                        if (index >= fi.Length) index = 0;
                        break;
                    }
                }
                name = fi[index].Name;     // next background name
                sr.Close();
            }
            catch (Exception)
            {
                name = fi[1].Name;
                if(sr!=null) sr.Close();
            }

            Uri uri = new Uri(path + "\\" + name, UriKind.Absolute);
            image1.Source = new BitmapImage(uri);

            StreamWriter sw = new StreamWriter("configBack.conf");
            sw.Write(name);
            sw.Close();
        }

        /*private void Backup_Db(object sender, RoutedEventArgs e)
        {
            //Good BackUp
            string path = @"C:\";
            string newpath = System.IO.Path.Combine(path, "BackUpLocation");
            Directory.CreateDirectory(newpath);
            string file = System.IO.Path.Combine(newpath, "Negindb.bak");
            if (File.Exists(file) == true)
            {
                File.Delete(file);
            }
            try
            {
                String db = Environment.CurrentDirectory + @"\Negindb.mdf";
                //String sql = "EXEC BackUpDB N'" + db + "' , N'" + file + "'";
                String sql = "BACKUP DATABASE ["+db+"] TO  DISK = N'"+file+"' WITH NOFORMAT, NOINIT,  NAME = N'Negindb-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                DB.execSql(sql);
                MessageBox.Show("یک نسخه ی پشتیبان در مسیر زیر با موفقیت قرار گرفت \n" + file, "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
                if (s.Contains("Invalid column name"))
                {
                    MessageBox.Show("یک نسخه ی پشتیبان در مسیر زیر با موفقیت قرار گرفت \n" + file, "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;     // because it's ok
                }
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Restore_Db(object sender, RoutedEventArgs e)
        {
            String db = @"C:\Negindb.mdf";
            String path = "C:\\BackUpLocation\\Negindb.bak";
            try
            {
                //String sql = "EXEC RestoreDB N'" + db + "'," + path;
                //DB.execSql("Select * from MajmooeTbl");
                String sql;
                try
                {
                    sql = "EXEC master.dbo.sp_detach_db @dbname = N'" + db + "', @skipchecks = 'false' ";
                    DB.execSqlWithoutDb(sql);
                }
                catch (Exception) 
                {
                }

                sql = "RESTORE DATABASE [" + db + "] FROM  DISK = N'" + path + "' WITH  FILE = 1,  MOVE N'Negindb' TO N'" + Environment.CurrentDirectory + "\\Negindb.mdf',  MOVE N'Negindb_log' TO N'" + Environment.CurrentDirectory + "\\Negindb_log.ldf',REPLACE , NOUNLOAD,  STATS = 10";
                //sql = "RESTORE DATABASE [" + db + "] FROM  DISK = N'" + path + "' WITH  FILE = 1,  MOVE N'Negindb' TO N'" + "C:\\Negindb.mdf',  MOVE N'Negindb_log' TO N'" + "C:\\Negindb_log.ldf',REPLACE , NOUNLOAD,  STATS = 10";
                String ldf = Environment.CurrentDirectory + @"\Negindb_log.ldf";
                //File.Delete(db);
                //File.Delete(ldf);
                DB.execSqlWithoutDb(sql);
                MessageBox.Show("پایگاه داده ها از مسیر زیر با موفقیت بازیابی شد \n" + path, "پشتیبانی", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در اتصال و یا اجرای درخواست از پایگاه داده ها", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }*/

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Support_Db(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.StartInfo.FileName = "BackUpAndRestoreDb.exe";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            this.Close();
        }

        private void Exit_Prog(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("آیا مایلید از برنامه خارج شوید ؟", "خروج", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void About_Prog(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("برنامه نگین\n\nورژن 1.0.0.0 ", "درباره ما", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Login_Prog(object sender, RoutedEventArgs e)
        {
            new LoginConfig().Show();
        }

        private void changeBackAuto(object sender, RoutedEventArgs e)
        {
            // toggle it =>
            if (autoBack.IsEnabled) autoBack.Stop();
            else autoBack.Start();
        }

        private void Price_Config(object sender, RoutedEventArgs e)
        {
            new PriceConfig().Show();
        }

        private void Phone_Book(object sender, RoutedEventArgs e)
        {
            new PhoneBook().Show();
        }

        private void Wnd_Config(object sender, RoutedEventArgs e)
        {
            new WindowConfig().Show();
        }
    }
}
