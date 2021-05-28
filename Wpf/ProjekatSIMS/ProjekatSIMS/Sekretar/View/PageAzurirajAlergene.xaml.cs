using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageAzurirajAlergene : Page
    {
        private PageAzurirajAlergeneVM viewModel;

        public PageAzurirajAlergene(int currentRowIndex)
        {
            InitializeComponent();
            this.viewModel = new PageAzurirajAlergeneVM(this, currentRowIndex);
            this.DataContext = this.viewModel;
        }

    }
}
