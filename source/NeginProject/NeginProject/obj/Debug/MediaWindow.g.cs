﻿#pragma checksum "..\..\MediaWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "25553B1B31C343FF8F4748F114C0A5BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.488
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NeginProject;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Controls;
using Xceed.Wpf.DataGrid;
using Xceed.Wpf.DataGrid.Automation;
using Xceed.Wpf.DataGrid.Converters;
using Xceed.Wpf.DataGrid.FilterCriteria;
using Xceed.Wpf.DataGrid.Markup;
using Xceed.Wpf.DataGrid.Print;
using Xceed.Wpf.DataGrid.Stats;
using Xceed.Wpf.DataGrid.ThemePack;
using Xceed.Wpf.DataGrid.ValidationRules;
using Xceed.Wpf.DataGrid.Views;
using Xceed.Wpf.DataGrid.Views.Surfaces;


namespace NeginProject {
    
    
    /// <summary>
    /// MediaWindow
    /// </summary>
    public partial class MediaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 404 "..\..\MediaWindow.xaml"
        internal Xceed.Wpf.DataGrid.DataGridControl grid;
        
        #line default
        #line hidden
        
        
        #line 419 "..\..\MediaWindow.xaml"
        internal System.Windows.Controls.ComboBox presetComboBox;
        
        #line default
        #line hidden
        
        
        #line 420 "..\..\MediaWindow.xaml"
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 421 "..\..\MediaWindow.xaml"
        internal System.Windows.Controls.Button ShowInWindowsButton;
        
        #line default
        #line hidden
        
        
        #line 422 "..\..\MediaWindow.xaml"
        internal System.Windows.Controls.Button ChangeThemeButton;
        
        #line default
        #line hidden
        
        
        #line 423 "..\..\MediaWindow.xaml"
        internal System.Windows.Controls.ComboBox GridBackgroundBrush;
        
        #line default
        #line hidden
        
        
        #line 424 "..\..\MediaWindow.xaml"
        internal System.Windows.Controls.Button BackgroundButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NeginProject;component/mediawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MediaWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\MediaWindow.xaml"
            ((NeginProject.MediaWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\MediaWindow.xaml"
            ((NeginProject.MediaWindow)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid = ((Xceed.Wpf.DataGrid.DataGridControl)(target));
            return;
            case 3:
            this.presetComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 420 "..\..\MediaWindow.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ShowInWindowsButton = ((System.Windows.Controls.Button)(target));
            
            #line 421 "..\..\MediaWindow.xaml"
            this.ShowInWindowsButton.Click += new System.Windows.RoutedEventHandler(this.ShowInWindowsButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ChangeThemeButton = ((System.Windows.Controls.Button)(target));
            
            #line 422 "..\..\MediaWindow.xaml"
            this.ChangeThemeButton.Click += new System.Windows.RoutedEventHandler(this.ChangeThemeButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GridBackgroundBrush = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.BackgroundButton = ((System.Windows.Controls.Button)(target));
            
            #line 424 "..\..\MediaWindow.xaml"
            this.BackgroundButton.Click += new System.Windows.RoutedEventHandler(this.BackgroundButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

