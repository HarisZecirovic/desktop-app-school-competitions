﻿#pragma checksum "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6736626AD96AFCCFC99C7C691BF9B1E855D2A50A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekat.Pages.Pocetna;
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


namespace Projekat.Pages.Pocetna {
    
    
    /// <summary>
    /// OrganizujTakmicenje
    /// </summary>
    public partial class OrganizujTakmicenje : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazivDb;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox razredDb;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker rokZaPrijavuDb;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datumDb;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projekat;component/pages/pocetna/organizujtakmicenje.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nazivDb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.razredDb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.rokZaPrijavuDb = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.datumDb = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            
            #line 104 "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Potvrdi_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 105 "..\..\..\..\..\Pages\Pocetna\OrganizujTakmicenje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NazadClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

