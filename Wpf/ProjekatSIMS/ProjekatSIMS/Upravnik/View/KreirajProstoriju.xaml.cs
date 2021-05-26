using System.Collections.ObjectModel;
using System.Windows;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class KreirajProstoriju : Window
    {
        public KreirajProstoriju()
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Upravnik.ViewModel.KreirajProstorijuVM();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
