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
    public partial class PageGuestNalozi : Page
    {
        private PageGuestNaloziVM viewModel;

        public PageGuestNalozi()
        {
            InitializeComponent();
            this.viewModel = new PageGuestNaloziVM(this, dataGridGuestNalozi);
            this.DataContext = this.viewModel;
        }

    }
}
