using System.Collections.ObjectModel;
using System.Windows;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class DodajOpremu : Window
    {
        public DodajOpremu(int c)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Upravnik.ViewModel.DodajOpremuVM(c);
        }
        private void odustani_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
