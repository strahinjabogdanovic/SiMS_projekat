﻿#pragma checksum "..\..\..\..\Lekar\View\SpisakRecepata.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FB657500D26D958FFE457B4B81C208FD002C9639A7AD280540C6AA0D75E2CE9E"
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
    /// SpisakRecepata
    /// </summary>
    public partial class SpisakRecepata : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Lekar\View\SpisakRecepata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridLekar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Lekar\View\SpisakRecepata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock t;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Lekar\View\SpisakRecepata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nazad;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjekatSIMS;component/lekar/view/spisakrecepata.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Lekar\View\SpisakRecepata.xaml"
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
            
            #line 20 "..\..\..\..\Lekar\View\SpisakRecepata.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NoviRecept_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.t = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.nazad = ((System.Windows.Controls.TextBlock)(target));
            
            #line 23 "..\..\..\..\Lekar\View\SpisakRecepata.xaml"
            this.nazad.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.nazad_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

