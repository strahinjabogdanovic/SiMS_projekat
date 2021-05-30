using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for KreirajTerminLekar.xaml
    /// </summary>
    public partial class KreirajTerminLekar : Window
    {



        public KreirajTerminLekar()
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.KreirajTerminLekarVM();

        }
        public KreirajTerminLekar(string jmbg)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.KreirajTerminLekarVM(jmbg);


        }


    }
}