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

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for TreeWindow.xaml
    /// </summary>
    public partial class TreeWindow : DockingLibrary.DockableContent
    {
        public TreeWindow()
        {
            InitializeComponent();
        }

        private void SMFid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان مسکونی فروشی";
            s.ID_txt.Text = Codes.ApartmanMaskooniForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SMFsimple(object sender, RoutedEventArgs e)
        {
            Search.ApartmanMaskooniF s = new Search.ApartmanMaskooniF();
            s.Topmost = true;
            s.Show();
        }

        private void SMFadv(object sender, RoutedEventArgs e)
        {
            Search.ApartmanMaskooniFAdvanced s = new Search.ApartmanMaskooniFAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void SEFid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان اداری فروشی";
            s.ID_txt.Text = Codes.ApartmanEdariForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SEFsimple(object sender, RoutedEventArgs e)
        {
            Search.ApartmanEdariF s = new Search.ApartmanEdariF();
            s.Topmost = true;
            s.Show();
        }

        private void SEFadv(object sender, RoutedEventArgs e)
        {
            Search.ApartmanEdariFAdvanced s = new Search.ApartmanEdariFAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void SMGHFid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی مغازه فروشی";
            s.ID_txt.Text = Codes.MaghazeForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SMGHFsimple(object sender, RoutedEventArgs e)
        {
            Search.MaghazeF s = new Search.MaghazeF();
            s.Topmost = true;
            s.Show();
        }

        private void SMGHFadv(object sender, RoutedEventArgs e)
        {
            Search.MaghazeFAdvanced s = new Search.MaghazeFAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void SMANFid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی منزل یا مجموعه فروشی";
            s.ID_txt.Text = Codes.HouseForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SMANFsimple(object sender, RoutedEventArgs e)
        {
            Search.HouseF s = new Search.HouseF();
            s.Topmost = true;
            s.Show();
        }

        private void SMANFadv(object sender, RoutedEventArgs e)
        {
            Search.HouseFAdvanced s = new Search.HouseFAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void SBFid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی باغ یا ویلای فروشی";
            s.ID_txt.Text = Codes.BaghVillaForooshi + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SBFsimple(object sender, RoutedEventArgs e)
        {
            Search.BaghVillaF s = new Search.BaghVillaF();
            s.Topmost = true;
            s.Show();
        }

        private void SBFadv(object sender, RoutedEventArgs e)
        {
            Search.BaghVillaFAdvanced s = new Search.BaghVillaFAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void INMS(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanMaskooniS w = new Insert.ApartmanMaskooniS();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INES(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanEdariS w = new Insert.ApartmanEdariS();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INMGHS(object sender, RoutedEventArgs e)
        {
            Insert.MaghazeS w = new Insert.MaghazeS();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INMANS(object sender, RoutedEventArgs e)
        {
            Insert.HouseS w = new Insert.HouseS();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INMF(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanMaskooniF w = new Insert.ApartmanMaskooniF();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INEF(object sender, RoutedEventArgs e)
        {
            Insert.ApartmanEdariF w = new Insert.ApartmanEdariF();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INMGHF(object sender, RoutedEventArgs e)
        {
            Insert.MaghazeF w = new Insert.MaghazeF();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INMANF(object sender, RoutedEventArgs e)
        {
            Insert.HouseF w = new Insert.HouseF();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void INBF(object sender, RoutedEventArgs e)
        {
            Insert.BaghVillaF w = new Insert.BaghVillaF();
            w.Topmost = true;
            if (w.newId.Length > 0) w.Show();
        }

        private void SMSid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان مسکونی استیجاری";
            s.ID_txt.Text = Codes.ApartmanMaskooniEstijari + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SMSsimple(object sender, RoutedEventArgs e)
        {
            Search.ApartmanMaskooniS s = new Search.ApartmanMaskooniS();
            s.Topmost = true;
            s.Show();
        }

        private void SMSadv(object sender, RoutedEventArgs e)
        {
            Search.ApartmanMaskooniSAdvanced s = new Search.ApartmanMaskooniSAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void SESid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی آپارتمان اداری استیجاری";
            s.ID_txt.Text = Codes.ApartmanEdariEstijari + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show(); 
        }

        private void SESsimple(object sender, RoutedEventArgs e)
        {
            Search.ApartmanEdariS s = new Search.ApartmanEdariS();
            s.Topmost = true;
            s.Show();
        }

        private void SESadv(object sender, RoutedEventArgs e)
        {
            Search.ApartmanEdariSAdvanced s = new Search.ApartmanEdariSAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void SMGHSid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی مغازه استیجاری";
            s.ID_txt.Text = Codes.MaghazeEstijari + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SMGHSsimple(object sender, RoutedEventArgs e)
        {
            Search.MaghazeS s = new Search.MaghazeS();
            s.Topmost = true;
            s.Show();
        }

        private void SMGHSadv(object sender, RoutedEventArgs e)
        {
            Search.MaghazeSAdvanced s = new Search.MaghazeSAdvanced();
            s.Topmost = true;
            s.Show();
        }

        private void SMANSid(object sender, RoutedEventArgs e)
        {
            Search.SearchWithID s = new Search.SearchWithID();
            s.title_Lbl.Content = "فرم جستجوی منزل یا مجموعه استیجاری";
            s.ID_txt.Text = Codes.HouseEstijari + "-";
            s.ID_txt.Select(s.ID_txt.Text.Length, 0);
            s.Topmost = true;
            s.Show();
        }

        private void SMANSsimple(object sender, RoutedEventArgs e)
        {
            Search.HouseS s = new Search.HouseS();
            s.Topmost = true;
            s.Show();
        }

        private void SMANSadv(object sender, RoutedEventArgs e)
        {
            Search.HouseSAdvanced s = new Search.HouseSAdvanced();
            s.Topmost = true;
            s.Show();
        }
    }
}
