﻿#pragma checksum "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7BCCDF019B27CACCD3B11F1D4BE198171E46D289"
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


namespace ProjekatSIMS.Lekar.View {
    
    
    /// <summary>
    /// SlobodniTerminiSpecijaliste
    /// </summary>
    public partial class SlobodniTerminiSpecijaliste : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tBlock1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Labela;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox slobcombo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button zakazi;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjekatSIMS;component/lekar/view/slobodniterminispecijaliste.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
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
            this.tBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.combo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
            this.combo.DropDownClosed += new System.EventHandler(this.combo_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Labela = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.slobcombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.zakazi = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Lekar\View\SlobodniTerminiSpecijaliste.xaml"
            this.zakazi.Click += new System.Windows.RoutedEventHandler(this.zakazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

