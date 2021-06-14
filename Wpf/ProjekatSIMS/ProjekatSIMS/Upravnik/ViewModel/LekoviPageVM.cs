using ProjekatSIMS.Sekretar.ViewModel;
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
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class LekoviPageVM : ViewModels
    {
        private NavigationService navigationService;
        private Window window { get; set; }
        private LekoviPage page;
        private DataGrid tabela = new DataGrid();

        public LekoviPageVM(NavigationService navigationService, Window window)
        {
            this.navigationService = navigationService;
            this.window = window;
            this.navigationService.Navigate(new LekoviPage());
        }

        public ObservableCollection<Lek> Lek { get; set; }
        public MyICommand Kreiraj { get; set; }
        public MyICommand Obrisi { get; set; }
        public MyICommand Promeni { get; set; }

        public LekoviPageVM(LekoviPage page, DataGrid dgp)
        {
            this.page = page;
            tabela = dgp;

            Lek = new ObservableCollection<Lek>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("lekovi.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var lekovi = new Lek();
                lekovi.sifraleka = termin[0].ToString();
                lekovi.nazivleka = termin[1].ToString();
                lekovi.sastojci = termin[2].ToString();
                lekovi.zamena = termin[3].ToString();

                Lek.Add(lekovi);
            }
            Kreiraj = new MyICommand(DodajLek);
            Obrisi = new MyICommand(ObrisiLek);
            Promeni = new MyICommand(PromeniLek);
        }

        private void DodajLek()
        {
            page.NavigationService.Navigate(new DodavanjeLekaPage());
        }

        private void ObrisiLek()
        {
            LekoviKontroler lk = new LekoviKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            if (Lek.Count > 0)
            {
                Lek.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            lk.Obrisi(currentRowIndex);
        }

        private void PromeniLek()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = tabela.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = tabela.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock t3 = tabela.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock t4 = tabela.Columns[3].GetCellContent(row) as TextBlock;
            string update = (t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/");

            LekoviKontroler lk = new LekoviKontroler();
            lk.Izmeni(update, currentRowIndex);
        }
    }
}
