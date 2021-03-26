using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for SekretarPocetnaStrana.xaml
    /// </summary>
    public partial class SekretarPocetnaStrana : Window
    {
        public ObservableCollection<Korisnik> Korisnici
        {
            get;
            set;
        }


        public SekretarPocetnaStrana()
        {
            InitializeComponent();
            this.DataContext = this;
            Korisnici = new ObservableCollection<Korisnik>();
            Korisnici.Add(new Korisnik { ime = "Petar", prezime = "Petrovic" , jmbg = 0038467348372 , pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 1});
            Korisnici.Add(new Korisnik { ime = "Ana", prezime = "Petrov", jmbg = 56345356375, pol = Pol.Zenski, datumRodjenja = "02.01.1987.", email = "ana@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 2 });
        }

        private void KreirajNalog_Click(object sender, RoutedEventArgs e)
        {
            KreirajNalog kn = new KreirajNalog();
            kn.ShowDialog();
        }

        private void ObrisiNalog_Click(object sender, RoutedEventArgs e)
        {
            if (Korisnici.Count > 0)
            {
                Korisnici.RemoveAt(Korisnici.Count - 1);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void IzmeniNalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrikaziSveInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
