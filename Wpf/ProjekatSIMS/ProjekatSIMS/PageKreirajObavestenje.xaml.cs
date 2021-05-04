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
            string tb3 = textBox3.Text;
            string datum = myDatePicker.ToString();
            String[] termin = datum.Split(' ');
            String[] termin1 = termin[0].Split('-');
            string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";

            n.Kreiraj(tb, tb1, datum1, tb3);

            this.NavigationService.Navigate(new PageObavestenjaSekretar());
        }
    }
}
