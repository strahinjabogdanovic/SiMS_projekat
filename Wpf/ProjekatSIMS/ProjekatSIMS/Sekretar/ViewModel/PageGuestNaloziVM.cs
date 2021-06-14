using ProjekatSIMS.Package1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Sekretar.View;
using System.IO;
using ProjekatSIMS.Package1.Kontroler;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageGuestNaloziVM : ViewModels
    {
        public ObservableCollection<GuestNalog> Guest { get; set; }

        private RelayCommand kreiraj;
        private RelayCommand obrisi;
        private RelayCommand nazad;

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

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        private PageGuestNalozi page;
        private DataGrid tabela = new DataGrid();

        public PageGuestNaloziVM(PageGuestNalozi page, DataGrid dataGridGuestNalozi)
        {
            tabela = dataGridGuestNalozi;
            this.page = page;

            Guest = new ObservableCollection<GuestNalog>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("naloziGuest.txt").ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var guest = new GuestNalog();
                guest.ime = termin[0].ToString();
                guest.prezime = termin[1].ToString();
                guest.jMBG = termin[2].ToString();

                Guest.Add(guest);
            }

            this.Kreiraj = new RelayCommand(Executed_Kreiraj, CanExecute_NavigateCommand);
            this.Obrisi = new RelayCommand(Executed_Obrisi, CanExecute_NavigateCommand);
            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
        }

        public void Executed_Kreiraj(object obj)
        {
            page.NavigationService.Navigate(new PageKreirajGuestNalog());
        }

        public void Executed_Obrisi(object obj)
        {
            GuestKontroler gk = new GuestKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            if (currentRowIndex != -1)
            {
                if (Guest.Count > 0)
                {
                    Guest.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                gk.Obrisi(currentRowIndex);
            }
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
