﻿#pragma checksum "..\..\..\WindowConfig.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9EA0AB67D5C0A9594FF9AF01188527E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DockingLibrary;
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


namespace NeginProject {
    
    
    /// <summary>
    /// WindowConfig
    /// </summary>
    public partial class WindowConfig : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.Button applyButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.CheckBox big_CheckBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.TextBox fontSize_Txt;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.CheckBox small_CheckBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.ComboBox comboBox1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\WindowConfig.xaml"
        internal System.Windows.Controls.CheckBox rahn_complete_CheckBox;
        
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
            System.Uri resourceLocater = new System.Uri("/NeginProject;component/windowconfig.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowConfig.xaml"
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
            
            #line 4 "..\..\..\WindowConfig.xaml"
            ((NeginProject.WindowConfig)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.applyButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\WindowConfig.xaml"
            this.applyButton.Click += new System.Windows.RoutedEventHandler(this.applyButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\WindowConfig.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.big_CheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.fontSize_Txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.small_CheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.comboBox1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.rahn_complete_CheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
