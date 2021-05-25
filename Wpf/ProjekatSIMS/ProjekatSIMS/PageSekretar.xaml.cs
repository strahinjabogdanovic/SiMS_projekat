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
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Kontroler;

namespace ProjekatSIMS
{
    public partial class PageSekretar : Page
    {
        public ObservableCollection<Pacijent> Korisnici
        {
            get;
            set;
        }

        public PageSekretar()
        {
            Korisnici = new ObservableCollection<Pacijent>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("podaci.txt").ToList();


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

        }

        private void KreirajNalog_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageSKreirajNalog());

        }

        private void ObrisiNalog_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);

            if (currentRowIndex != -1)
            {
                if (Korisnici.Count > 0)
                {
                    Korisnici.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                npk.Obrisi(currentRowIndex);
            }

        }

        private void IzmeniNalog_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);
            DataGridRow row = (DataGridRow)dataGridNalozi.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock ime = dataGridNalozi.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock prezime = dataGridNalozi.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock jmbg = dataGridNalozi.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock datum = dataGridNalozi.Columns[3].GetCellContent(row) as TextBlock;
            TextBlock brojTel = dataGridNalozi.Columns[4].GetCellContent(row) as TextBlock;
            string update = (ime.Text + "/" + prezime.Text + "/" + jmbg.Text + "/" + datum.Text + "/" + brojTel.Text);

            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
            npk.Update(update, currentRowIndex);

        }

        private void GuestNalog_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageGuestNalozi());
        }

        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        private void MedKarton_Click(object sender, RoutedEventArgs e)
        {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);
            this.NavigationService.Navigate(new PageMedKarton(currentRowIndex));
        }

        private void Termini_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTerminiSekretar());
        }

        private void HitnoZakazivanje_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageHitnoZakazivanje());
        }
    }
}
