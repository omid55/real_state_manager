﻿#pragma checksum "..\..\..\Search\SearchWithID.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9C64FAC5EBF206F3257D01E93A46754A"
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
    /// SearchWithID
    /// </summary>
    public partial class SearchWithID : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Search\SearchWithID.xaml"
        internal System.Windows.Controls.Label title_Lbl;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Search\SearchWithID.xaml"
        internal System.Windows.Controls.TextBox ID_txt;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Search\SearchWithID.xaml"
        internal System.Windows.Controls.Button search_button;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Search\SearchWithID.xaml"
        internal System.Windows.Controls.Button back_button;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Search\SearchWithID.xaml"
        internal System.Windows.Controls.CheckBox Show3D_checkBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Search\SearchWithID.xaml"
        internal System.Windows.Controls.ComboBox DBComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/NeginProject;component/search/searchwithid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Search\SearchWithID.xaml"
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
            
            #line 3 "..\..\..\Search\SearchWithID.xaml"
            ((NeginProject.Search.SearchWithID)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.title_Lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ID_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.search_button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Search\SearchWithID.xaml"
            this.search_button.Click += new System.Windows.RoutedEventHandler(this.search_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.back_button = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Search\SearchWithID.xaml"
            this.back_button.Click += new System.Windows.RoutedEventHandler(this.back_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Show3D_checkBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.DBComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

