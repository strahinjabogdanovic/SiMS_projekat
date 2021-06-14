using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS.Sekretar.View
{
    /// <summary>
    /// Interaction logic for PageSekretarZakazTermina.xaml
    /// </summary>
    public partial class PageSekretarZakazTermina : Page
    {
        private PageSekretarZakazTerminaVM viewModel;

        public PageSekretarZakazTermina()
        {
            InitializeComponent();
            //this.viewModel = new PageSekretarZakazTerminaVM(this);
            //this.DataContext = this.viewModel;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            PacijentFileStorage p = new PacijentFileStorage();

            string lekar = comboBox.SelectedValue.ToString();
            string tb = textBox.Text;
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;

            p.KreirajSekretar(lekar, tb, tb1, tb2);

            this.NavigationService.Navigate(new PageTerminiSekretar());
        }
    }
}
