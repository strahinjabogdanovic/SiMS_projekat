using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageHitnoZakazTermin : Page
    {
        private PageHitnoZakazTerminVM viewModel;

        public PageHitnoZakazTermin(string oblastLekara)
        {
            InitializeComponent();
            this.viewModel = new PageHitnoZakazTerminVM(this, oblastLekara, dataGridHitnoZakazivanje);
            this.DataContext = this.viewModel;
        }

    }
}
