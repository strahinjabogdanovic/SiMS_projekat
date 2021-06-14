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
    public partial class PageTerminiSekretar : Page
    {
        private PageTerminiSekretarVM viewModel;

        public PageTerminiSekretar()
        {
            InitializeComponent();
            this.viewModel = new PageTerminiSekretarVM(this, dataGridTerminiSekretar);
            this.DataContext = this.viewModel;
        }

    }
}
