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
    public partial class PageZakazivanjeDatum : Page
    {
        private PageZakazivanjeDatumVM viewModel;

        public PageZakazivanjeDatum(string tb)
        {
            InitializeComponent();
            this.viewModel = new PageZakazivanjeDatumVM(this, tb, dataGridTerminiDatum);
            this.DataContext = this.viewModel;
        }

    }
}
