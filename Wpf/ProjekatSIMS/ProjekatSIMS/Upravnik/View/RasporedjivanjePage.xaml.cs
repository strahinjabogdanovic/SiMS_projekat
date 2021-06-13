using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Upravnik.View
{
    public partial class RasporedjivanjePage : Page
    {
        int izabrani_red = 0;
        ProstorijeKontroler pk = new ProstorijeKontroler();
        public RasporedjivanjePage(int currentRowIndex)
        {
            InitializeComponent();

            izabrani_red = currentRowIndex;

            List<string> imena_prostorija = pk.prostorije_u_cb(izabrani_red);
            foreach (string imena in imena_prostorija)
            {
                ComboBoxItem newitem = new ComboBoxItem();
                newitem.Content = imena;
                cb1.Items.Add(newitem);
            }

            this.DataContext = this;
        }
        private int vreme_ren()
        {
            DatumiServis ds = new DatumiServis();
            return ds.izabraniDatum(myDatePicker) - ds.danasnjiDatum();
        }

        public void stoperica()
        {
            int premestanje = vreme_ren();
            Stopwatch stopwatch = Stopwatch.StartNew();
            MessageBox.Show("Oprema ce biti premestana za " + premestanje + " minuta");
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds >= premestanje * 10000)
                {
                    break;
                }
            }
        }

        private void potvrdi_click(object sender, RoutedEventArgs e)
        {
            String naziv_u = t2.Text;
            String kolicina_u = t1.Text;

            pk.prostorija_iz(naziv_u, kolicina_u, izabrani_red);
            stoperica();
            pk.prostorija_u(cb1.SelectedValue.ToString(), naziv_u, kolicina_u);
            this.NavigationService.Navigate(new OpremaPage(izabrani_red));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OpremaPage(izabrani_red));
        }
    }
}
