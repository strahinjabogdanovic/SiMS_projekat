using System;
using System.Collections.Generic;
using System.IO;
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
using ProjekatSIMS.Sekretar.View;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageHitnoZakazivanje.xaml
    /// </summary>
    public partial class PageHitnoZakazivanje : Page
    {
        public PageHitnoZakazivanje()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSekretar());
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string oblastLekara = comboBox1.SelectedValue.ToString();
            string tb = textBox.Text;
            string tb1 = textBox1.Text;

            String ime = "";
            String prezime = "";
            Boolean nasao = false;

            using (var sr = new StreamReader("podaci.txt"))
            {

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    ime = termin[0];
                    prezime = termin[1];

                    if (ime.Equals(tb) && prezime.Equals(tb1))
                    {
                        this.NavigationService.Navigate(new PageHitnoZakazTermin(oblastLekara));
                        nasao = true;
                    }


                }

            }

            using (var sr = new StreamReader("naloziGuest.txt"))
            {

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    ime = termin[0];
                    prezime = termin[1];

                    if (ime.Equals(tb) && prezime.Equals(tb1))
                    {
                        this.NavigationService.Navigate(new PageHitnoZakazTermin(oblastLekara));
                        nasao = true;
                    }

                }

            }

            if (nasao == false)
            {
                //MessageBox.Show("Pacijent ne postoji u sistemu!");
                this.NavigationService.Navigate(new PageKreirajGuestNalog());
            }
        }
    }
}
