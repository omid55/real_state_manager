using System;
using System.IO;
using System.Windows;

namespace NeginProject
{
    public class Codes
    {
        public const int ApartmanMaskooniEstijari = 1;
        public const int ApartmanEdariEstijari = 2;
        public const int MaghazeEstijari = 3;
        public const int HouseEstijari = 4;
        public const int ApartmanMaskooniForooshi = 5;
        public const int ApartmanEdariForooshi = 6;
        public const int MaghazeForooshi = 7;
        public const int HouseForooshi = 8;
        public const int BaghVillaForooshi = 9;

        //public const long RahnRatio = 1000000;
        //public const long EjareRatio = 30000;

        public const int ExpireDurationInDays = 30;
        public static String mainDirectory = "";


        public static void setMainDirectory()
        {
            mainDirectory = Environment.CurrentDirectory;
        }

        public static String getRahnRatio()
        {
            String res = "";
            try
            {
                var sr = new StreamReader(mainDirectory + "\\price.conf");
                res = sr.ReadLine();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("فایل اطلاعات قیمت ها یافت نشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show("فایل اطلاعات قیمت ها صحیح نمی باشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return res;
        }

        public static String getEjareRatio()
        {
            String res = "";
            try
            {
                var sr = new StreamReader(mainDirectory + "\\price.conf");
                sr.ReadLine();
                res = sr.ReadLine();
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("فایل اطلاعات قیمت ها یافت نشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show("فایل اطلاعات قیمت ها صحیح نمی باشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return res;
        }

        public static void setRahnAndEjareRatio(String rahn, String ejare)
        {
            try
            {
                var sw = new StreamWriter(mainDirectory + "\\price.conf");
                sw.WriteLine(rahn);
                sw.WriteLine(ejare);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}