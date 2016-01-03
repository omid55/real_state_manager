using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

namespace NeginProject
{
    class WndConfig
    {
        private static String path= Environment.CurrentDirectory+"\\wndconfig.conf";

        public static ConfigParams getConfig()
        {
            ConfigParams con = null;
            try
            {
                StreamReader sr = new StreamReader(path);
                String content = sr.ReadLine();
                con = new ConfigParams();
                String[] str=content.Split(',');
                con.fontSize = Int32.Parse(str[0]);
                con.isMaximized = Boolean.Parse(str[1]);
                con.simpleIsMaximized = Boolean.Parse(str[2]);
                con.rahn_complete = Boolean.Parse(str[3]);
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در دسترسی به فایل تنظیمات صفحات", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return con;
        }

        public static void saveConfig(ConfigParams param)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(param.fontSize+","+param.isMaximized+","+param.simpleIsMaximized+","+param.rahn_complete);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در دسترسی به فایل تنظیمات صفحات", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void setConfiguration(Window w)
        {
            ConfigParams cp = WndConfig.getConfig();
            if (cp.isMaximized)
            {
                w.WindowState = WindowState.Maximized;
            }
            else
            {
                w.WindowState = WindowState.Normal;
            }
            w.FontSize = cp.fontSize;
        }

        public static void setConfig4SimpleSearch(Window w)
        {
            ConfigParams cp = WndConfig.getConfig();
            if (cp.simpleIsMaximized)
            {
                w.WindowState = WindowState.Maximized;
            }
            else
            {
                w.WindowState = WindowState.Normal;
            }
            w.FontSize = cp.fontSize;
        }
    }
}
