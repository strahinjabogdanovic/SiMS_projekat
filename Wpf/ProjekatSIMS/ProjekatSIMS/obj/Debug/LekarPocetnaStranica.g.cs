﻿#pragma checksum "..\..\LekarPocetnaStranica.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "224E9117905E9465EE253B2A9819863C6C5BC55EF835FD1719A33D557828741A"
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
    /// LekarPocetnaStranica
    /// </summary>
    public partial class LekarPocetnaStranica : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\LekarPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridLekar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\LekarPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\LekarPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\LekarPocetnaStranica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjekatSIMS;component/lekarpocetnastranica.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LekarPocetnaStranica.xaml"
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
            this.dataGridLekar = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\LekarPocetnaStranica.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.Kreiraj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\LekarPocetnaStranica.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.Obrisi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\LekarPocetnaStranica.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.Izmeni_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

