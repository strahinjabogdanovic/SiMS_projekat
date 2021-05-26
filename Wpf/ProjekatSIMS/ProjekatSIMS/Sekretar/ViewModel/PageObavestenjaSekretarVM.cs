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

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageObavestenjaSekretarVM : ViewModels
    {
        public ObservableCollection<Obavestenja> Obavesti { get; set; }

        private RelayCommand nazad;
        private RelayCommand obrisi;
        private RelayCommand izmeni;
        private RelayCommand kreiraj;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
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

        public RelayCommand Kreiraj
        {
            get { return kreiraj; }
            set
            {
                kreiraj = value;
            }
        }

        private PageObavestenjaSekretar page;
        private DataGrid tabela = new DataGrid();

        public PageObavestenjaSekretarVM(PageObavestenjaSekretar page, DataGrid dataGridObavestenja)
        {
            this.page = page;
            tabela = dataGridObavestenja;

            Obavesti = new ObservableCollection<Obavestenja>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("obavestenja.txt").ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var obavestenja = new Obavestenja();
                obavestenja.naziv = termin[0].ToString();
                obavestenja.sadrzaj = termin[1].ToString();
                obavestenja.datum = termin[2].ToString();
                obavestenja.uloga = termin[3].ToString();

                Obavesti.Add(obavestenja);

            }

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Obrisi = new RelayCommand(Executed_Obrisi, CanExecute_NavigateCommand);
            this.Izmeni = new RelayCommand(Executed_Izmeni, CanExecute_NavigateCommand);
            this.Kreiraj = new RelayCommand(Executed_Kreiraj, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
        }

        public void Executed_Obrisi(object obj)
        {
            ObavestenjaKontroler ok = new ObavestenjaKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            if (currentRowIndex != -1)
            {
                if (Obavesti.Count > 0)
                {
                    Obavesti.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ok.Obrisi(currentRowIndex);
            }
        }

        public void Executed_Izmeni(object obj)
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock uloga = tabela.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock naziv = tabela.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock sadraj = tabela.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock datum = tabela.Columns[3].GetCellContent(row) as TextBlock;
            string update = (naziv.Text + "/" + sadraj.Text + "/" + datum.Text + "/" + uloga.Text);

            ObavestenjaKontroler ok = new ObavestenjaKontroler();
            ok.Update(update, currentRowIndex);
        }

        public void Executed_Kreiraj(object obj)
        {
            page.NavigationService.Navigate(new PageKreirajObavestenje());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
