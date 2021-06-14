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
    public partial class PageObavestenjaSekretar : Page
    {

        private PageObavestenjaSekretarVM viewModel;

        public PageObavestenjaSekretar()
        {
            InitializeComponent();
            this.viewModel = new PageObavestenjaSekretarVM(this, dataGridObavestenja);
            this.DataContext = this.viewModel;
        }

    }
}
