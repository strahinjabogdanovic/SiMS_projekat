using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class Lekovi_U : Window
    {
        public Lekovi_U()
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Upravnik.ViewModel.Lekovi_UVM(dataGridLekovi);
        }
    }
}
