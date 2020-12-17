﻿#pragma checksum "..\..\AddJourney.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "68B25F15E9E5C7C9284D82B9D7C95084F9EABA3B60893017EFA64D60FAB02FD5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using WeSplit;


namespace WeSplit {
    
    
    /// <summary>
    /// AddJourney
    /// </summary>
    public partial class AddJourney : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox journeyName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox journeyPlace;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker journeyBegDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker journeyEndDate;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox routeName;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox routeDescription;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox routeMoney;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addRoute;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addJourney;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addThumbail;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\AddJourney.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView routeList;
        
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
            System.Uri resourceLocater = new System.Uri("/WeSplit;component/addjourney.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddJourney.xaml"
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
            
            #line 15 "..\..\AddJourney.xaml"
            ((WeSplit.AddJourney)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.journeyName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.journeyPlace = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.journeyBegDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.journeyEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.routeName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.routeDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.routeMoney = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.addRoute = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\AddJourney.xaml"
            this.addRoute.Click += new System.Windows.RoutedEventHandler(this.addRoute_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.addJourney = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\AddJourney.xaml"
            this.addJourney.Click += new System.Windows.RoutedEventHandler(this.addJourney_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.addThumbail = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\AddJourney.xaml"
            this.addThumbail.Click += new System.Windows.RoutedEventHandler(this.addThumbail_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.routeList = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
