﻿#pragma checksum "..\..\EditMember.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ADE891CF3BE52B2BDCAB147A0F29CDB0F654C2E7C34339688489FFD020610181"
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
    /// EditMember
    /// </summary>
    public partial class EditMember : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox journeyName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox journeyPlace;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker journeyBegDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker journeyEndDate;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox memberNameEdit;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox memberNameAddNew;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox memberPhone;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox memberMoney;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveMember;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addMemberAddNew;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addMemberEdit;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button finishEditJourney;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Err;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image journeyThumbnail;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addThumbail;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\EditMember.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView memberList;
        
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
            System.Uri resourceLocater = new System.Uri("/WeSplit;component/editmember.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditMember.xaml"
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
            
            #line 15 "..\..\EditMember.xaml"
            ((WeSplit.EditMember)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 15 "..\..\EditMember.xaml"
            ((WeSplit.EditMember)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
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
            
            #line 52 "..\..\EditMember.xaml"
            this.journeyBegDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.journeyBegDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.journeyEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.memberNameEdit = ((System.Windows.Controls.ComboBox)(target));
            
            #line 58 "..\..\EditMember.xaml"
            this.memberNameEdit.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.routeName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.memberNameAddNew = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.memberPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 73 "..\..\EditMember.xaml"
            this.memberPhone.LostFocus += new System.Windows.RoutedEventHandler(this.memberPhonne_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.memberMoney = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\EditMember.xaml"
            this.memberMoney.LostFocus += new System.Windows.RoutedEventHandler(this.routeMoney_LostFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.saveMember = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\EditMember.xaml"
            this.saveMember.Click += new System.Windows.RoutedEventHandler(this.saveMember_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.addMemberAddNew = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\EditMember.xaml"
            this.addMemberAddNew.Click += new System.Windows.RoutedEventHandler(this.addMemberAddNew_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.addMemberEdit = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\EditMember.xaml"
            this.addMemberEdit.Click += new System.Windows.RoutedEventHandler(this.addMemberEdit_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.finishEditJourney = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\EditMember.xaml"
            this.finishEditJourney.Click += new System.Windows.RoutedEventHandler(this.finishEditJourney_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Err = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.journeyThumbnail = ((System.Windows.Controls.Image)(target));
            return;
            case 16:
            this.addThumbail = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\EditMember.xaml"
            this.addThumbail.Click += new System.Windows.RoutedEventHandler(this.addThumbail_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.memberList = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

