﻿#pragma checksum "..\..\..\..\Lekar\View\ValidacijaLeka.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "50DF48F366D75D2F90C10ADB6DA7EB30E0186A0BABEA55B8ADA7C131A2C14081"
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
    /// ValidacijaLeka
    /// </summary>
    public partial class ValidacijaLeka : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nazad;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock t1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock t2;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjekatSIMS;component/lekar/view/validacijaleka.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
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
            this.nazad = ((System.Windows.Controls.TextBlock)(target));
            
            #line 10 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
            this.nazad.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.nazad_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox1_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.t1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.t2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 19 "..\..\..\..\Lekar\View\ValidacijaLeka.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Sacuvaj_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

