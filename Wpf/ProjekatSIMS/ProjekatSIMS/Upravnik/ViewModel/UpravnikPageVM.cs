using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.ViewModel;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class UpravnikPageVM : ViewModels
    {
        private UpravnikPage page;
        private DataGrid tabela = new DataGrid();
        public ObservableCollection<Prostorije> Prostorije { get; set; }
        public MyICommand Kreiraj { get; set; }
        public MyICommand Obrisi { get; set; }
        public MyICommand Prikazi { get; set; }
        public MyICommand Oprema { get; set; }
        public MyICommand Rasporedjivanje { get; set; }
        public MyICommand Pretrazi { get; set; }
        public MyICommand Renoviranje { get; set; }
        public MyICommand Izvestaj { get; set; }
        private string pretraga;

        public UpravnikPageVM(UpravnikPage page, DataGrid dgp)
        {
            this.page = page;
            tabela = dgp;
            Prostorije = new ObservableCollection<Prostorije>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("prostorije.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var prostorije = new Prostorije();
                prostorije.ime = termin[0].ToString();
                prostorije.oznaka = termin[1].ToString();
                prostorije.namena = termin[2].ToString();
                prostorije.oprema = termin[3].ToString();
                prostorije.renoviranje = termin[5].ToString();

                Prostorije.Add(prostorije);
            }

            Kreiraj = new MyICommand(DodajProstoriju);
            Obrisi = new MyICommand(ObrisiProstoriju);
            Prikazi = new MyICommand(PrikaziProstoriju);
            Oprema = new MyICommand(OpremaTabela);
            Rasporedjivanje = new MyICommand(RasporediOpremu);
            Pretrazi = new MyICommand(PretraziOpremu);
            Renoviranje = new MyICommand(RenoviranjeProstorije);
            Izvestaj = new MyICommand(IzvestajPrikaz);
        }

        private void DodajProstoriju()
        {
            page.NavigationService.Navigate(new DodavanjeProstorijePage());
        }

        private void ObrisiProstoriju()
        {
            ProstorijeKontroler pk = new ProstorijeKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            if (Prostorije.Count > 0)
            {
                Prostorije.RemoveAt(currentRowIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            pk.Obrisi(currentRowIndex);
        }

        private void PrikaziProstoriju()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            page.NavigationService.Navigate(new SveInfoPage(currentRowIndex));
        }

        private void OpremaTabela()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            page.NavigationService.Navigate(new OpremaPage(currentRowIndex));
        }

        private void RasporediOpremu()
        {
            /* int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
             rasporedjivanje r = new rasporedjivanje(currentRowIndex);
             r.ShowDialog();*/
        }

        private void PretraziOpremu()
        {
            page.NavigationService.Navigate(new FiltriranaPage(Pretraga));
        }
        public string Pretraga
        {
            get { return pretraga; }
            set
            {
                if (pretraga != value)
                {
                    pretraga = value;
                    OnPropertyChanged("Pretraga");
                }
            }
        }

        private void RenoviranjeProstorije()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = tabela.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = tabela.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock t3 = tabela.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock t4 = tabela.Columns[3].GetCellContent(row) as TextBlock;
            TextBlock t5 = tabela.Columns[6].GetCellContent(row) as TextBlock;
            string update = (t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/");

            ProstorijeKontroler pk = new ProstorijeKontroler();
            pk.renoviranje(update, currentRowIndex, t5.Text, t2.Text);
        }
        private void IzvestajPrikaz()
        {
            page.NavigationService.Navigate(new IzvestajPage());
        }


    }
}
