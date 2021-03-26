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
        Korisnik krs;
        public ObservableCollection<Korisnik> Korisnici
        {
            get;
            set;
        }


        public SekretarPocetnaStrana()
        {
            InitializeComponent();
            this.DataContext = this;


           // krs.dodaj();
            

            //dataGridNalozi.ItemsSource = Korisnici;


            Korisnici = new ObservableCollection<Korisnik>();
            Korisnici.Add(new Korisnik { ime = "Petar", prezime = "Petrovic" , jmbg = 0038467348372 , pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 1});
            Korisnici.Add(new Korisnik { ime = "Ana", prezime = "Petrov", jmbg = 56345356375, pol = Pol.Zenski, datumRodjenja = "02.01.1987.", email = "ana@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 2 });
            Korisnici.Add(new Korisnik { ime = "Mitar", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 3 });
            Korisnici.Add(new Korisnik { ime = "Marko", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 4 });
            Korisnici.Add(new Korisnik { ime = "Jefinima", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 5 });
            Korisnici.Add(new Korisnik { ime = "Dostr", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 6 });
            Korisnici.Add(new Korisnik { ime = "Boris", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 7 });
            Korisnici.Add(new Korisnik { ime = "Treoja", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 8 });
            Korisnici.Add(new Korisnik { ime = "Prsuta", prezime = "Petrovic", jmbg = 0038467348372, pol = Pol.Muski, datumRodjenja = "02.01.1987.", email = "petar@gmail.com", brojTelefona = "0635627384", adresa = "hfudssdgb", idKorisnika = 9 });

        }

        private void KreirajNalog_Click(object sender, RoutedEventArgs e)
        {
            KreirajNalog kn = new KreirajNalog();
            kn.ShowDialog();
            //dataGridNalozi.Items.Refresh();
        }

        private void ObrisiNalog_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);
            if (Korisnici.Count > 0)
            {
                Korisnici.RemoveAt(currentRowIndex);
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
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);

            




        }
    }
}
