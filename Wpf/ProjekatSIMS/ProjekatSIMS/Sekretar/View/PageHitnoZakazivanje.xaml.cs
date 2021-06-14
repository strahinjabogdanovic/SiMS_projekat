using ProjekatSIMS.Sekretar.ViewModel;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.View
{
    /// <summary>
    /// Interaction logic for PageHitnoZakazivanje.xaml
    /// </summary>
    public partial class PageHitnoZakazivanje : Page
    {
        private PageHitnoZakazivanjeVM viewModel;

        public PageHitnoZakazivanje()
        {
            InitializeComponent();
            //this.viewModel = new PageHitnoZakazivanjeVM(this);
            //this.DataContext = this.viewModel;
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
