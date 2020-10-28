﻿#pragma checksum "..\..\AddRecipeMediaWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D0E0D3EA55333E8FF8E2486C84BFECC9FFD0CF7EB937814BD6E7614123596778"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Food_Recipe_App;
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
using System.Windows.Shell;


namespace Food_Recipe_App {
    
    
    /// <summary>
    /// AddRecipeMediaWindow
    /// </summary>
    public partial class AddRecipeMediaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_YoutubeURL;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_AddMedia;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image_AddHeader;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_CancelMedia;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_AddMediaComplete;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser YoutubeElement;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement LocalVideoElement;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\AddRecipeMediaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider timelineSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Food Recipe App;component/addrecipemediawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddRecipeMediaWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBox_YoutubeURL = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\AddRecipeMediaWindow.xaml"
            this.TextBox_YoutubeURL.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_AddMedia = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\AddRecipeMediaWindow.xaml"
            this.Button_AddMedia.Click += new System.Windows.RoutedEventHandler(this.Button_AddMedia_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Image_AddHeader = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.Button_CancelMedia = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\AddRecipeMediaWindow.xaml"
            this.Button_CancelMedia.Click += new System.Windows.RoutedEventHandler(this.Button_CancelMedia_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button_AddMediaComplete = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\AddRecipeMediaWindow.xaml"
            this.Button_AddMediaComplete.Click += new System.Windows.RoutedEventHandler(this.Button_AddMediaComplete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.YoutubeElement = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 7:
            this.LocalVideoElement = ((System.Windows.Controls.MediaElement)(target));
            
            #line 99 "..\..\AddRecipeMediaWindow.xaml"
            this.LocalVideoElement.MediaOpened += new System.Windows.RoutedEventHandler(this.Element_MediaOpened);
            
            #line default
            #line hidden
            
            #line 99 "..\..\AddRecipeMediaWindow.xaml"
            this.LocalVideoElement.MediaEnded += new System.Windows.RoutedEventHandler(this.Element_MediaEnded);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 110 "..\..\AddRecipeMediaWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseDownPlayMedia);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 115 "..\..\AddRecipeMediaWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseDownPauseMedia);
            
            #line default
            #line hidden
            return;
            case 10:
            this.timelineSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 119 "..\..\AddRecipeMediaWindow.xaml"
            this.timelineSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.SeekToMediaPosition);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

