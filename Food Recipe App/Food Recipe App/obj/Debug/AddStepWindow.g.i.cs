﻿#pragma checksum "..\..\AddStepWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C37603324A73C5C77ECF674453D6957EC8F791706018356E0E65CCEADB72E416"
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
    /// AddStepWindow
    /// </summary>
    public partial class AddStepWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\AddStepWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_StepDescription;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddStepWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_AddStepImage;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AddStepWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image_AddHeader;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\AddStepWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_AddStep;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AddStepWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image_AddStep;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\AddStepWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListView_AddStepPictures;
        
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
            System.Uri resourceLocater = new System.Uri("/Food Recipe App;component/addstepwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddStepWindow.xaml"
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
            this.TextBox_StepDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Button_AddStepImage = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\AddStepWindow.xaml"
            this.Button_AddStepImage.Click += new System.Windows.RoutedEventHandler(this.Button_AddStepImage_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Image_AddHeader = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.Button_AddStep = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\AddStepWindow.xaml"
            this.Button_AddStep.Click += new System.Windows.RoutedEventHandler(this.Button_AddStep_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Image_AddStep = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.ListView_AddStepPictures = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
