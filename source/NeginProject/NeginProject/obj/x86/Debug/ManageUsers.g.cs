﻿#pragma checksum "..\..\..\ManageUsers.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7EADD1CE2F54DACC53E1796773B438CD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
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
using System.Windows.Forms;
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
    /// ManageUsers
    /// </summary>
    public partial class ManageUsers : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Forms.Integration.WindowsFormsHost dgv;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Forms.DataGridView gridView;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Button button3;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Button Edit_Button;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Image image2;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Image image3;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Button Verify_Button;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Image image4;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ManageUsers.xaml"
        internal System.Windows.Controls.Label WarningLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/NeginProject;component/manageusers.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManageUsers.xaml"
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
            
            #line 6 "..\..\..\ManageUsers.xaml"
            ((NeginProject.ManageUsers)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgv = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 3:
            this.gridView = ((System.Windows.Forms.DataGridView)(target));
            return;
            case 4:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\ManageUsers.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\ManageUsers.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.button3 = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\ManageUsers.xaml"
            this.button3.Click += new System.Windows.RoutedEventHandler(this.button3_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Edit_Button = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\ManageUsers.xaml"
            this.Edit_Button.Click += new System.Windows.RoutedEventHandler(this.Edit_Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.image2 = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.image3 = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.Verify_Button = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\ManageUsers.xaml"
            this.Verify_Button.Click += new System.Windows.RoutedEventHandler(this.Verify_Button_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.image4 = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.WarningLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
