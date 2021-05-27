using ProjekatSIMS.Sekretar.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.View
{
    public partial class PagePrioritetZakazivanja : Page
    {
        private PagePrioritetZakazivanjaVM viewModel;

        public PagePrioritetZakazivanja()
        {
            InitializeComponent();
            this.viewModel = new PagePrioritetZakazivanjaVM(this);
            this.DataContext = this.viewModel;
        }

    }
}
