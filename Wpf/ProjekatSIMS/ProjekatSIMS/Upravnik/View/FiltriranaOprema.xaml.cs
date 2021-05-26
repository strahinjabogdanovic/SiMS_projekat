using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class FiltriranaOprema : Window
    {
        public FiltriranaOprema(String s)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Upravnik.ViewModel.FiltriranaOpremaVM(dataGridPronadji, s);
        }
    }
}
