using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PageKreirajGuestNalog : Page
    {
        private PageKreirajGuestNalogVM viewModel;

        public PageKreirajGuestNalog()
        {
            InitializeComponent();
            this.viewModel = new PageKreirajGuestNalogVM(this);
            this.DataContext = this.viewModel;
        }
    }
}
