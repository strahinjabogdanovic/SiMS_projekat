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
    public partial class PageSekretar : Page
    {
        private PageSekretarVM viewModel;

        public PageSekretar()
        {
            InitializeComponent();
            this.viewModel = new PageSekretarVM(this, dataGridNalozi);
            this.DataContext = this.viewModel;
        }

    }
}
