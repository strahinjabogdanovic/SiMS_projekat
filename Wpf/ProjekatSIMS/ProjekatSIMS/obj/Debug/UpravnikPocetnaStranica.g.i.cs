﻿#pragma checksum "..\..\UpravnikPocetnaStranica.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "25A1BF8A63B45AA15FBD23132A1DE366B4D15650DC8CA14FE3AF16C40FBF071D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjekatSIMS;
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


namespace ProjekatSIMS {
    
    
    /// <summary>
    /// UpravnikPocetnaStranica
    /// </summary>
    public partial class UpravnikPocetnaStranica : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\UpravnikPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridProstorije;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\UpravnikPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\UpravnikPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\UpravnikPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\UpravnikPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button3;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\UpravnikPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button4;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\UpravnikPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button5;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjekatSIMS;component/upravnikpocetnastranica.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpravnikPocetnaStranica.xaml"
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
            this.dataGridProstorije = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\UpravnikPocetnaStranica.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.KreirajProstoriju_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\UpravnikPocetnaStranica.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.ObrisiProstoriju_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\UpravnikPocetnaStranica.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.IzmeniProstoriju_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button3 = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\UpravnikPocetnaStranica.xaml"
            this.button3.Click += new System.Windows.RoutedEventHandler(this.PrikaziSveInfo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button4 = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\UpravnikPocetnaStranica.xaml"
            this.button4.Click += new System.Windows.RoutedEventHandler(this.oprema_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button5 = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\UpravnikPocetnaStranica.xaml"
            this.button5.Click += new System.Windows.RoutedEventHandler(this.rasporedjivanje_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

