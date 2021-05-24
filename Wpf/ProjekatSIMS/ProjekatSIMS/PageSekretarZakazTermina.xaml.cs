using Package1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageSekretarZakazTermina.xaml
    /// </summary>
    public partial class PageSekretarZakazTermina : Page
    {
        public PageSekretarZakazTermina()
        {
            InitializeComponent();
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
