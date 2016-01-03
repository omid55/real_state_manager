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
using System.Data;
using Xceed.Wpf.DataGrid;

namespace NeginProject
{
    /// <summary>
    /// Interaction logic for Result3D.xaml
    /// </summary>
    public partial class Result3D : Window
    {
        public DataTable dt;
        private bool loaded = false;


        public Result3D()
        {
            InitializeComponent();

            //Xceed.Wpf.DataGrid.Licenser.LicenseKey = "DGP36-57BBK-GWU7J-08BA";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridCollectionView dataGridCollectionView = new DataGridCollectionView(dt.DefaultView);
            dataGridCollectionView.AutoFilterMode = AutoFilterMode.And;
            dataGridCollectionView.DistinctValuesConstraint = DistinctValuesConstraint.Filtered;

            grid.ItemsSource = dataGridCollectionView;
            loaded = true;
        }

        public void doTheme()
        {
            if (!loaded || cardflow3DView.IsChecked == true) return;
            int index = ThemeSelectorComboBox.SelectedIndex;
            switch (index)
            {
                case 0:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.ThemePack.GlassTheme();
                    break;

                case 1:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.ThemePack.LiveExplorerTheme();
                    break;

                case 2:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.ThemePack.WMP11Theme();
                    break;

                case 3:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.Windows7Theme();
                    break;

                case 4:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.ThemePack.Office2007BlueTheme();
                    break;

                case 5:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.ThemePack.Office2007BlackTheme();
                    break;

                case 6:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.ThemePack.Office2007SilverTheme();
                    break;

                case 7:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.AeroNormalColorTheme();
                    break;

                case 8:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.RoyaleNormalColorTheme();
                    break;

                case 9:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.ZuneNormalColorTheme();
                    break;

                case 10:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.LunaNormalColorTheme();
                    break;

                case 11:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.LunaHomesteadTheme();
                    break;

                case 12:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.LunaMetallicTheme();
                    break;

                case 13:
                    grid.View.Theme = new Xceed.Wpf.DataGrid.Views.ClassicSystemColorTheme();
                    break;
            }
        }

        private void ThemeSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doTheme();
        }

        private void TableflowViewRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (grid == null)
                return;

            Xceed.Wpf.DataGrid.Views.TableflowView tableflowView = new Xceed.Wpf.DataGrid.Views.TableflowView();
            tableflowView.ContainerHeight = 40d;

            grid.View = tableflowView;
            doTheme();
        }

        private void TableViewRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (grid == null)
                return;

            Xceed.Wpf.DataGrid.Views.TableView view = new Xceed.Wpf.DataGrid.Views.TableView();

            /*HierarchicalGroupByControl hgc = new HierarchicalGroupByControl();
            hgc.NoGroupContent = "موارد موجود";
            DataTemplate data = new DataTemplate();
            view.FixedHeaders.Add(new DataTemplate(hgc));*/

            grid.View = view;
            doTheme();
        }

        private void CardViewRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (grid == null)
                return;

            Xceed.Wpf.DataGrid.Views.CardView view = new Xceed.Wpf.DataGrid.Views.CardView();

            grid.View = view;
            doTheme();
        }

        private void CompactCardViewRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (grid == null)
                return;

            Xceed.Wpf.DataGrid.Views.CompactCardView view = new Xceed.Wpf.DataGrid.Views.CompactCardView();

            grid.View = view;
            doTheme();
        }

        private void Cardflow3DView_Checked(object sender, RoutedEventArgs e)
        {
            if (grid == null)
                return;

            grid.View = new Xceed.Wpf.DataGrid.Views.CardflowView3D();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }
    }
}
