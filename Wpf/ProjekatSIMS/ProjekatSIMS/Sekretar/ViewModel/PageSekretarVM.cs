using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageSekretarVM : ViewModels
    {

        public ObservableCollection<Pacijent> Korisnici { get; set; }

        private RelayCommand kreiraj;
        private RelayCommand obrisi;
        private RelayCommand izmeni;
        private RelayCommand guestNalog;
        private RelayCommand obavestenja;
        private RelayCommand medKarton;
        private RelayCommand termini;
        private RelayCommand hitnoZakazivanje;

        public RelayCommand Kreiraj
        {
            get { return kreiraj; }
            set
            {
                kreiraj = value;
            }
        }

        public RelayCommand Obrisi
        {
            get { return obrisi; }
            set
            {
                obrisi = value;
            }
        }

        public RelayCommand Izmeni
        {
            get { return izmeni; }
            set
            {
                izmeni = value;
            }
        }

        public RelayCommand GuestNalog
        {
            get { return guestNalog; }
            set
            {
                guestNalog = value;
            }
        }

        public RelayCommand Obavestenja
        {
            get { return obavestenja; }
            set
            {
                obavestenja = value;
            }
        }

        public RelayCommand MedKarton
        {
            get { return medKarton; }
            set
            {
                medKarton = value;
            }
        }

        public RelayCommand Termini
        {
            get { return termini; }
            set
            {
                termini = value;
            }
        }

        public RelayCommand HitnoZakazivanje
        {
            get { return hitnoZakazivanje; }
            set
            {
                hitnoZakazivanje = value;
            }
        }

        private PageSekretar page;
        private DataGrid tabela = new DataGrid();

        public PageSekretarVM(PageSekretar page, DataGrid dataGridNalozi)
        {
            tabela = dataGridNalozi;
            this.page = page;
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

            this.Kreiraj = new RelayCommand(Executed_Kreiraj, CanExecute_NavigateCommand);
            this.Obrisi = new RelayCommand(Executed_Obrisi, CanExecute_NavigateCommand);
            this.Izmeni = new RelayCommand(Executed_Izmeni, CanExecute_NavigateCommand);
            this.GuestNalog = new RelayCommand(Executed_GuestNalog, CanExecute_NavigateCommand);
            this.Obavestenja = new RelayCommand(Executed_Obavestenja, CanExecute_NavigateCommand);
            this.MedKarton = new RelayCommand(Executed_MedKarton, CanExecute_NavigateCommand);
            this.Termini = new RelayCommand(Executed_Termini, CanExecute_NavigateCommand);
            this.HitnoZakazivanje = new RelayCommand(Executed_HitnoZakazivanje, CanExecute_NavigateCommand);

        }

        public void Executed_Kreiraj(object obj)
        {
            page.NavigationService.Navigate(new PageSKreirajNalog());
        }

        public void Executed_Obrisi(object obj)
        {
            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);

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

        public void Executed_Izmeni(object obj)
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock ime = tabela.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock prezime = tabela.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock jmbg = tabela.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock datum = tabela.Columns[3].GetCellContent(row) as TextBlock;
            TextBlock brojTel = tabela.Columns[4].GetCellContent(row) as TextBlock;
            string update = (ime.Text + "/" + prezime.Text + "/" + jmbg.Text + "/" + datum.Text + "/" + brojTel.Text);

            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
            npk.Update(update, currentRowIndex);
        }

        public void Executed_GuestNalog(object obj)
        {
            page.NavigationService.Navigate(new PageGuestNalozi());
        }

        public void Executed_Obavestenja(object obj)
        {
            page.NavigationService.Navigate(new PageObavestenjaSekretar());
        }

        public void Executed_MedKarton(object obj)
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            page.NavigationService.Navigate(new PageMedKarton(currentRowIndex));
        }

        public void Executed_Termini(object obj)
        {
            page.NavigationService.Navigate(new PageTerminiSekretar());
        }

        public void Executed_HitnoZakazivanje(object obj)
        {
            page.NavigationService.Navigate(new PageHitnoZakazivanje());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
