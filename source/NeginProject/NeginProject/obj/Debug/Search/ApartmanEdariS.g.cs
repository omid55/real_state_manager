﻿#pragma checksum "..\..\..\Search\ApartmanEdariS.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E301C6FF59865F353F9B9D349AB4E50D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.488
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
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


namespace NeginProject.Search {
    
    
    /// <summary>
    /// ApartmanEdariS
    /// </summary>
    public partial class ApartmanEdariS : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.Grid title;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.Label date_Lbl;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.Label datePrompt;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.ComboBox DBComboBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.Grid parameters;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.Button search_button;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.Button back_button;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox rahnoejare_Low;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox rahnoejare_High;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.CheckBox Show3D_checkBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.RichTextBox comments;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox address_Txt;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox metraj_Low;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox metraj_High;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox bedrooms_Low;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox bedrooms_High;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox owner;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox rahn_Low;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox rahn_High;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox ejare_Low;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox ejare_High;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Search\ApartmanEdariS.xaml"
        internal System.Windows.Controls.TextBox sanad;
        
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
            System.Uri resourceLocater = new System.Uri("/NeginProject;component/search/apartmanedaris.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Search\ApartmanEdariS.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\Search\ApartmanEdariS.xaml"
            ((NeginProject.Search.ApartmanEdariS)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.title = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.date_Lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.datePrompt = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.DBComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.parameters = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.search_button = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Search\ApartmanEdariS.xaml"
            this.search_button.Click += new System.Windows.RoutedEventHandler(this.search_button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.back_button = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Search\ApartmanEdariS.xaml"
            this.back_button.Click += new System.Windows.RoutedEventHandler(this.back_button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.rahnoejare_Low = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\Search\ApartmanEdariS.xaml"
            this.rahnoejare_Low.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rahnoejare_Low_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.rahnoejare_High = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\Search\ApartmanEdariS.xaml"
            this.rahnoejare_High.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rahnoejare_High_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Show3D_checkBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 12:
            this.comments = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 13:
            this.address_Txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.metraj_Low = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.metraj_High = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.bedrooms_Low = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.bedrooms_High = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.owner = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            this.rahn_Low = ((System.Windows.Controls.TextBox)(target));
            
            #line 81 "..\..\..\Search\ApartmanEdariS.xaml"
            this.rahn_Low.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rahn_Low_TextChanged);
            
            #line default
            #line hidden
            return;
            case 20:
            this.rahn_High = ((System.Windows.Controls.TextBox)(target));
            
            #line 83 "..\..\..\Search\ApartmanEdariS.xaml"
            this.rahn_High.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rahn_High_TextChanged);
            
            #line default
            #line hidden
            return;
            case 21:
            this.ejare_Low = ((System.Windows.Controls.TextBox)(target));
            
            #line 85 "..\..\..\Search\ApartmanEdariS.xaml"
            this.ejare_Low.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ejare_Low_TextChanged);
            
            #line default
            #line hidden
            return;
            case 22:
            this.ejare_High = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\Search\ApartmanEdariS.xaml"
            this.ejare_High.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ejare_High_TextChanged);
            
            #line default
            #line hidden
            return;
            case 23:
            this.sanad = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

