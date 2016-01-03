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
using System.IO;
using Microsoft.Win32;
using Xceed.Wpf.DataGrid;
using System.Data;
using System.Diagnostics;
using NeginProject.Themes;
using System.Collections;

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for MediaWindow.xaml
    /// </summary>
    public partial class MediaWindow : Window
    {
        private string name = "other";
        private int themeIndex = 0;
        private int backIndex = 0;


        public MediaWindow()
        {
            InitializeComponent();

            getFromConfigFile();
        }

        public void getFromConfigFile()    // and set themeIndex and backIndex if the file exists
        {
            try
            {
                string pa = Codes.mainDirectory + "\\theme.conf";
                if (File.Exists(pa))
                {
                    StreamReader sr = new StreamReader(pa);
                    string res = sr.ReadLine();
                    string[] ix = res.Split(',');
                    themeIndex = Int32.Parse(ix[0]);
                    backIndex = Int32.Parse(ix[1]);
                    sr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در حین دسترسی به اطلاعات نحوه ی نمایش رخ داده است ", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void setToConfigFile()    // and set themeIndex and backIndex if the file exists
        {
            try
            {
                string pa = Codes.mainDirectory + "\\theme.conf";
                StreamWriter sw = new StreamWriter(pa);
                sw.WriteLine(themeIndex + "," + backIndex);
                sw.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در حین ذخیره ی اطلاعات نحوه ی نمایش رخ داده است ", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void init(string id)
        {
            string[] str = id.Split(' ');
            name = str.First<string>() + "_" + str.Last<string>();   // name setted now

            grid.Background = ((DictionaryEntry)GridBackgroundBrush.Items[backIndex]).Value as Brush;

            PresetItem item = presetComboBox.Items[themeIndex] as PresetItem;
            if (item != null)
            {
                Style viewStyle = null;
                if (item.ResourceDictionary != null)
                    viewStyle = (Style)item.ResourceDictionary[typeof(Xceed.Wpf.DataGrid.Views.CardflowView3D)];
                this.presetComboBox.SelectedItem = null;
                ViewImportExportManager.ImportViewFromStyle(this.grid.View, viewStyle);
            }
        }

        private string[] imageExtensions = new string[] { "gif","jpg","jpe","png","bmp","dib","tif","wmf","jpeg","ras","eps","pcx","pcd","tga" };
        
        public bool isItImage(string name)
        {
            string extension = name.Split('.').Last<string>();
            foreach (string img in imageExtensions)
            {
                if (extension.ToLower().CompareTo(img) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void init3D()
        {
            try
            {
                string path = checkOrCreateDirectory();
                DataTable dt = new DataTable();
                dt.Columns.Add("Image", typeof(BitmapImage));
                foreach (string f in Directory.GetFiles(path))
                {
                    if (isItImage(f))
                    {
                        dt.Rows.Add(new BitmapImage(new Uri(f)));
                    }
                }

                DataGridCollectionView dataGridCollectionView = new DataGridCollectionView(dt.DefaultView);
                dataGridCollectionView.AutoFilterMode = AutoFilterMode.And;
                dataGridCollectionView.DistinctValuesConstraint = DistinctValuesConstraint.Filtered;

                grid.ItemsSource = dataGridCollectionView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در حین نمایش تصاویر رخ داده است ", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("لطفا متن زیر را به پشتیبانی برنامه اعلام بفرمایید \n\n" + ex.Message, "متن تکنیکی خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string checkOrCreateDirectory()   // return new Directory
        {
            string path = Codes.mainDirectory;
            string newPath = path + "\\Media\\" + name;
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            // in each way the directory for this item exists now
            return newPath;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Image Files (*.jpg;*.bmp;*.jpeg;*.gif;*.png)|*.jpg;*.bmp;*.jpeg;*.png" +
                        "|Audio Files (*.wma;*.mp3;*.wav;*.ogg)|*.wma;*.mp3;*.wav;*.ogg" +
                        "|Video Files (*.wmv;*.mpg;*.avi)|*.wmv;*.mpg;*.avi" +
                        "|All Files (*.*)|*.*";
            string newPath = checkOrCreateDirectory();
            if (ofd.ShowDialog().Value)
            {
                string[] selects = ofd.FileNames;
                if (selects.Count<string>() == 0) return;
                foreach (string s in selects)
                {
                    string fullpath = newPath + "\\" + s.Split('\\').Last<string>();
                    if (!File.Exists(fullpath))
                    {
                        File.Copy(s, fullpath);
                    }
                }

                init3D();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init3D();
        }

        private void ShowInWindowsButton_Click(object sender, RoutedEventArgs e)
        {
            string path = checkOrCreateDirectory();
            string[] files = Directory.GetFiles(path);
            int len = files.Count<string>();
            int idx=0;
            while (idx<len && !isItImage(files[idx]))
            {
                idx++;
            }
            if (idx < len)
            {
                string Path = files[idx];
                Process p = new Process();
                p.StartInfo.FileName = "rundll32.exe";
                p.StartInfo.Arguments = @"C:\WINDOWS\System32\shimgvw.dll,ImageView_Fullscreen " + Path;
                p.Start();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void ChangeThemeButton_Click(object sender, RoutedEventArgs e)
        {
            themeIndex = (themeIndex + 1) % presetComboBox.Items.Count;
            PresetItem item = presetComboBox.Items[themeIndex] as PresetItem;
            setToConfigFile();

            if (item != null)
            {
                Style viewStyle = null;
                if (item.ResourceDictionary != null)
                    viewStyle = (Style)item.ResourceDictionary[typeof(Xceed.Wpf.DataGrid.Views.CardflowView3D)];
                this.presetComboBox.SelectedItem = null;
                ViewImportExportManager.ImportViewFromStyle(this.grid.View, viewStyle);
            }
        }

        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            if (grid != null)
            {
                backIndex = (backIndex + 1) % GridBackgroundBrush.Items.Count;
                grid.Background = ((DictionaryEntry)GridBackgroundBrush.Items[backIndex]).Value as Brush;
                setToConfigFile();
            }
        }
    }
}
