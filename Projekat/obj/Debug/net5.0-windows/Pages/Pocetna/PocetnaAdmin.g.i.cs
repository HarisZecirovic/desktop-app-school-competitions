﻿#pragma checksum "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8C4C226C50D25E8254D3A7CF584119C1EDBA5165"
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
    /// PocetnaAdmin
    /// </summary>
    public partial class PocetnaAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView2;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekat;component/pages/pocetna/pocetnaadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
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
            
            #line 8 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((Projekat.Pages.Pocetna.PocetnaAdmin)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Prikazi);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.listView = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.listView2 = ((System.Windows.Controls.ListView)(target));
            
            #line 80 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            this.listView2.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Prikazi_Timove);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 105 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dodaj);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 106 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Odbij);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 107 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OdjaviSe_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 117 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OrganizujTamicenje_click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 119 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PregledKorisnika);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 126 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ArhivirajTakmicenje_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 128 "..\..\..\..\..\Pages\Pocetna\PocetnaAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Pregled_Arhiviranih);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

