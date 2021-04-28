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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageKreirajObavestenje.xaml
    /// </summary>
    public partial class PageKreirajObavestenje : Page
    {
        public PageKreirajObavestenje()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjaFileStorage n = new ObavestenjaFileStorage();

            string tb = textBox.Text;
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;
            string tb3 = textBox3.Text;

            n.Kreiraj(tb, tb1, tb2, tb3);

            this.NavigationService.Navigate(new PageObavestenjaSekretar());
        }
    }
}
