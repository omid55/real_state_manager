﻿#pragma checksum "..\..\MyMediaPlayer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "041B5CB175224026C269E8178377FA05"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.488
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
    /// MyMediaPlayer
    /// </summary>
    public partial class MyMediaPlayer : DockingLibrary.DockableContent, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.MediaElement mediaPlayer;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.Button playBtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.Slider VolSlider;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.Slider PositionSlider;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.Label nowPlaying;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MyMediaPlayer.xaml"
        internal System.Windows.Controls.Label label1;
        
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
            System.Uri resourceLocater = new System.Uri("/NeginProject;component/mymediaplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MyMediaPlayer.xaml"
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
            this.mediaPlayer = ((System.Windows.Controls.MediaElement)(target));
            
            #line 8 "..\..\MyMediaPlayer.xaml"
            this.mediaPlayer.MediaOpened += new System.Windows.RoutedEventHandler(this.Element_MediaOpened);
            
            #line default
            #line hidden
            return;
            case 2:
            this.playBtn = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\MyMediaPlayer.xaml"
            this.playBtn.Click += new System.Windows.RoutedEventHandler(this.play_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 10 "..\..\MyMediaPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.stop_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 11 "..\..\MyMediaPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.pause_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.VolSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 6:
            this.PositionSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 13 "..\..\MyMediaPlayer.xaml"
            this.PositionSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.PositionSlider_DragCompleted));
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 14 "..\..\MyMediaPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChooseFile_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.nowPlaying = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

