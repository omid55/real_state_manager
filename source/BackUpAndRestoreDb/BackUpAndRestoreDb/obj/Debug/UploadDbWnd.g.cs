﻿#pragma checksum "..\..\UploadDbWnd.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6ADE9A149C4BA953418AAFB69A3D91AE"
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


namespace BackUpAndRestoreDb {
    
    
    /// <summary>
    /// UploadDbWnd
    /// </summary>
    public partial class UploadDbWnd : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Button UploadButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.ProgressBar progressBar1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.CheckBox createDbCheckBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.TextBox ServerTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.ComboBox DatabaseComboBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.TextBox UserNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Label label4;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.PasswordBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Label label5;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.RadioButton ClientModeRadio;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.RadioButton ServerModeRadio;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.TextBox SourceServerTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.ComboBox SourceDbComboBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Label SourceServerLabel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\UploadDbWnd.xaml"
        internal System.Windows.Controls.Label SourceDbLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/BackUpAndRestoreDb;component/uploaddbwnd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UploadDbWnd.xaml"
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
            
            #line 2 "..\..\UploadDbWnd.xaml"
            ((BackUpAndRestoreDb.UploadDbWnd)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UploadButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\UploadDbWnd.xaml"
            this.UploadButton.Click += new System.Windows.RoutedEventHandler(this.UploadButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\UploadDbWnd.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.progressBar1 = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 5:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\UploadDbWnd.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.createDbCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 14 "..\..\UploadDbWnd.xaml"
            this.createDbCheckBox.Checked += new System.Windows.RoutedEventHandler(this.createDbCheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ServerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DatabaseComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\UploadDbWnd.xaml"
            this.DatabaseComboBox.GotFocus += new System.Windows.RoutedEventHandler(this.DatabaseComboBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.UserNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.label4 = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.PasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 15:
            this.label5 = ((System.Windows.Controls.Label)(target));
            return;
            case 16:
            this.ClientModeRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 24 "..\..\UploadDbWnd.xaml"
            this.ClientModeRadio.Checked += new System.Windows.RoutedEventHandler(this.ClientModeRadio_Checked);
            
            #line default
            #line hidden
            return;
            case 17:
            this.ServerModeRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 25 "..\..\UploadDbWnd.xaml"
            this.ServerModeRadio.Checked += new System.Windows.RoutedEventHandler(this.ServerModeRadio_Checked);
            
            #line default
            #line hidden
            return;
            case 18:
            this.SourceServerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            this.SourceDbComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\UploadDbWnd.xaml"
            this.SourceDbComboBox.GotFocus += new System.Windows.RoutedEventHandler(this.SourceDbComboBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 20:
            this.SourceServerLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 21:
            this.SourceDbLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
