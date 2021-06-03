using System;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageKreirajObavestenje : Page
    {
        private PageKreirajObavestenjeVM viewModel;

        public PageKreirajObavestenje()
        {
            InitializeComponent();
            this.viewModel = new PageKreirajObavestenjeVM(this);
            this.DataContext = this.viewModel;
        }
    }
}
