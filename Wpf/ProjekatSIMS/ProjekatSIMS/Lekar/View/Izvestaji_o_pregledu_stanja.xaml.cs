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
    /// Interaction logic for Izvestaji_o_pregledu_stanja.xaml
    /// </summary>
    public partial class Izvestaji_o_pregledu_stanja : Window
    {
        private string tJmbg;

      

        public Izvestaji_o_pregledu_stanja(string tJmbg)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.Izvestaji_o_pregledu_stanjaVM(tJmbg, Izvestaji);

            this.tJmbg = tJmbg;
        }
    }
}