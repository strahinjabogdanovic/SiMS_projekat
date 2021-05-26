using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class UpravnikPocetnaStranicaVM : BindableBase
    {
        private DataGrid tabela = new DataGrid();
        public ObservableCollection<Prostorije> Prostorije { get; set;}
        public MyICommand Kreiraj { get; set; }
        public MyICommand Obrisi { get; set; }
        public MyICommand Promeni { get; set; }
        public MyICommand Prikazi { get; set; }
        public MyICommand Oprema { get; set; }
        public MyICommand Rasporedjivanje { get; set; }
        public MyICommand Lekovi { get; set; }
        public MyICommand Pretrazi { get; set; }
        public MyICommand Renoviranje { get; set; }
        private string pretraga;
        public UpravnikPocetnaStranicaVM(DataGrid dgp)
        {
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
            Promeni = new MyICommand(PromeniProstoriju);
            Prikazi = new MyICommand(PrikaziProstoriju);
            Oprema = new MyICommand(OpremaTabela);
            Rasporedjivanje = new MyICommand(RasporediOpremu);
            Lekovi = new MyICommand(LekoviTabela);
            Pretrazi = new MyICommand(PretraziOpremu);
            Renoviranje = new MyICommand(RenoviranjeProstorije);
        }

        private void DodajProstoriju()
        {
            KreirajProstoriju kp = new KreirajProstoriju();
            kp.ShowDialog();
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

        private void PromeniProstoriju()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = tabela.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = tabela.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock t3 = tabela.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock t4 = tabela.Columns[3].GetCellContent(row) as TextBlock;
            string update = (t1.Text + "/" + t2.Text + "/" + t3.Text + "/" + t4.Text + "/");

            ProstorijeKontroler pk = new ProstorijeKontroler();
            pk.Update(update, currentRowIndex);
        }

        private void PrikaziProstoriju()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            ProstorijeKontroler pk = new ProstorijeKontroler();
            pk.Prikazi(currentRowIndex);
        }

        private void OpremaTabela()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            ProstorijeKontroler pk = new ProstorijeKontroler();
            pk.stvari(currentRowIndex);
        }

        private void RasporediOpremu()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            rasporedjivanje r = new rasporedjivanje(currentRowIndex);
            r.ShowDialog();
        }

        private void LekoviTabela()
        {
            Lekovi_U lu = new Lekovi_U();
            lu.ShowDialog();
        }

        private void PretraziOpremu()
        {
            FiltriranaOprema fo = new FiltriranaOprema(Pretraga);
            fo.ShowDialog();
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


    }
}
