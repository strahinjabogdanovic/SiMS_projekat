using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for SpisakRecepata.xaml
    /// </summary>
    public partial class SpisakRecepata : Window
    {


        

        public SpisakRecepata(string tJmbg)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.SpisakRecepataVM(dataGridLekar, tJmbg);

        }

    }
}