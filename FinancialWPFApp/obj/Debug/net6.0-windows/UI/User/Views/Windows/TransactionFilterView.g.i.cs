﻿#pragma checksum "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66CEEF90CA2BC93D0443FEB281EC0F08FBF71D3F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FinancialWPFApp.UI.User.Views.Windows;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FinancialWPFApp.UI.User.Views.Windows {
    
    
    /// <summary>
    /// TransactionFilterView
    /// </summary>
    public partial class TransactionFilterView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbWallet;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdIncome;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdExpense;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdTypeAll;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdDraft;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdPending;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdCompleted;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdCancel;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdStatusAll;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFrom;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpTo;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FinancialWPFApp;component/ui/user/views/windows/transactionfilterview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbWallet = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
            this.cbWallet.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbWallet_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rdIncome = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.rdExpense = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.rdTypeAll = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rdDraft = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rdPending = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.rdCompleted = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.rdCancel = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.rdStatusAll = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.dpFrom = ((System.Windows.Controls.DatePicker)(target));
            
            #line 109 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
            this.dpFrom.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dpFrom_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dpTo = ((System.Windows.Controls.DatePicker)(target));
            
            #line 121 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
            this.dpTo.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dpTo_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\..\..\..\..\..\UI\User\Views\Windows\TransactionFilterView.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

