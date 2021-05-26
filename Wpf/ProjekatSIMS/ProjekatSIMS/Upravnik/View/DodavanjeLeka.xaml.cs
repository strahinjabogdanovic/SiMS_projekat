using System.Windows;
using ProjekatSIMS.Package1.Kontroler;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class DodavanjeLeka : Window
    {
        public DodavanjeLeka()
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Upravnik.ViewModel.DodavanjeLekaVM();
        }
    }
}
