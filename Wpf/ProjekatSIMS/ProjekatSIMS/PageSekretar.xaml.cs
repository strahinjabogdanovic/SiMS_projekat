using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PageSekretar.xaml
    /// </summary>
    public partial class PageSekretar : Page
    {
        private readonly string filePath;

        public ObservableCollection<Pacijent> Korisnici
        {
            get;
            set;
        }

        public PageSekretar()
        {
            filePath = "podaci.txt";
            Korisnici = new ObservableCollection<Pacijent>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var korisnik = new Pacijent();
                korisnik.ime = termin[0].ToString();
                korisnik.prezime = termin[1].ToString();
                korisnik.jmbg = long.Parse(termin[2].ToString());
                if (termin[3].ToString() != null)
                {

                    if (termin[3].ToString() == "Muski")
                    {
                        korisnik.pol = Pol.Muski;

                    }
                    else if (termin[3].ToString() == "Zenski")
                    {
                        korisnik.pol = Pol.Zenski;
                    }
                }
                korisnik.datumRodjenja = termin[4].ToString();
                korisnik.email = termin[5].ToString();
                korisnik.brojTelefona = termin[6].ToString();
                korisnik.adresa = termin[7].ToString();
                Korisnici.Add(korisnik);


            }


            InitializeComponent();
            this.DataContext = this;

            StreamReader sr = new StreamReader("podaci.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }

        private void KreirajNalog_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSKreirajNalog());

        }

        private void ObrisiNalog_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataFileStorage n = new NaloziPacijenataFileStorage();
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);
            Pacijent k = Korisnici.ElementAt(currentRowIndex);
            if (Korisnici.Count > 0)
            {
                Korisnici.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            n.Obrisi(k);


            //dataGridNalozi.Items.Refresh();
        }

        private void IzmeniNalog_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataFileStorage np = new NaloziPacijenataFileStorage();
            np.Update(dataGridNalozi);


        }

        private void PrikaziSveInfo_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataFileStorage n = new NaloziPacijenataFileStorage();
            n.Prikazi(dataGridNalozi);
            this.NavigationService.Navigate(new PageSPrikazInfo());

        }

        private void GuestNalog_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageGuestNalozi());
            //GuestNalozi gn = new GuestNalozi();
            //gn.ShowDialog();

        }

        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        private void MedKarton_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataFileStorage n = new NaloziPacijenataFileStorage();
            n.Prikazi(dataGridNalozi);
            this.NavigationService.Navigate(new PageMedKarton());

        }

        private void Termini_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }
    }
}
