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
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class StvariVM : BindableBase
    {
        private OpremaPage page;
        public ObservableCollection<Oprema> Oprema{ get; set;}
        int redProstorije = 0;
        private string s1;
        private DataGrid tabela = new DataGrid();
        public MyICommand Dodaj { get; set; }
        public MyICommand Obrisi { get; set; }
        public MyICommand Izmeni { get; set; }
        public MyICommand Rasporedjivanje { get; set; }
        public StvariVM(OpremaPage page, DataGrid dgo,int currentRowIndex)
        {
            this.page = page;
            tabela = dgo;
            redProstorije = currentRowIndex;
            Oprema = new ObservableCollection<Oprema>();

            List<string> prostorije = new List<string>();
            prostorije = File.ReadAllLines("prostorije.txt").ToList();

            int idp = 0;
            foreach (string red in prostorije)
            {
                if (idp == currentRowIndex)
                {
                    string[] termin = red.Split('/');

                    string sala = termin[0];
                    S1 = sala;

                    string opreman = termin[3];
                    string[] priv = opreman.Split(',');
                    int s = priv.Length;

                    string kolic = termin[4];
                    string[] kolii = kolic.Split(',');

                    for (int i = 0; i < s; i++)
                    {
                        var oprema = new Oprema();
                        oprema.opreme = priv[i];
                        oprema.kolicina = kolii[i];
                        Oprema.Add(oprema);
                    }
                }
                idp++;
            }

            Dodaj = new MyICommand(DodajOpremu);
            Obrisi = new MyICommand(ObrisiOpremu);
            Izmeni = new MyICommand(IzmeniOpremu);
            Rasporedjivanje = new MyICommand(RasporediOpremu);
        }
        public string S1
        {
            get { return s1; }
            set
            {
                if (s1 != value)
                {
                    s1 = value;
                    OnPropertyChanged("S1");
                }
            }
        }

        private void DodajOpremu()
        {
            page.NavigationService.Navigate(new DodavanjeOpremePage(redProstorije));
        }

        private void ObrisiOpremu()
        {
            OpremaKontroler ok = new OpremaKontroler();
            int currentRowIndexO = tabela.Items.IndexOf(tabela.SelectedItem);

            if (Oprema.Count > 0)
            {
                Oprema.RemoveAt(currentRowIndexO);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ok.Obrisi(redProstorije, currentRowIndexO);
        }

        private void IzmeniOpremu()
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock t1 = tabela.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock t2 = tabela.Columns[1].GetCellContent(row) as TextBlock;

            OpremaKontroler ok = new OpremaKontroler();
            ok.Update(redProstorije, currentRowIndex, t1.Text, t2.Text);
        }

        private void RasporediOpremu()
        {
            page.NavigationService.Navigate(new RasporedjivanjePage(redProstorije));
        }
    }
}
